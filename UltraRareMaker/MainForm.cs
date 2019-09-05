using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UltraRareMaker
{
    // Yes, this is a "god" class. Refactor later if a huge improvement is needed.
    public partial class MainForm : Form
    {
        private static string PROFILE_DIR = Path.Combine(Directory.GetCurrentDirectory(), "profiles");
        private static string LAST_PROFILE = Path.Combine(PROFILE_DIR, "__LASTPROFILE.json");
        private List<Perk> _Perks = new List<Perk>();
        private List<Chapter> _Chapters;
        private string _DbdPath = "";
        private string _PerksPath = "";

        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(PROFILE_DIR))
            {
                Directory.CreateDirectory(PROFILE_DIR);
            }

            _Chapters = JsonConvert.DeserializeObject<List<Chapter>>(File.ReadAllText("Chapters.json"));
            _Perks = JsonConvert.DeserializeObject<List<Perk>>(File.ReadAllText("Perks.json"));

            foreach(var chapter in _Chapters)
            {
                foreach(var perkName in chapter.Perks)
                {
                    var perk = _Perks.Find(p => p.PerkName.Equals(perkName));
                    if (perk != null) // Ignore null perk. Perk is present in Chapters.json but not in Perks.json
                    {
                        perk.DlcName = chapter.Path;
                        perk.DlcDisplayName = chapter.DisplayName;
                        perk.DlcNumber = chapter.Number;
                    }
                }
            }

            RefreshPerkList();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeRows = false;

            // Set column properties
            dataGridView1.Columns["Selected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView1.Columns["Selected"].HeaderText = "Apply";
            dataGridView1.Columns["DisplayName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["DlcDisplayName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["DlcDisplayName"].HeaderText = "Chapter";

            // Hide internal properties
            dataGridView1.Columns["PerkName"].Visible = false;
            dataGridView1.Columns["DlcName"].Visible = false;
            dataGridView1.Columns["DlcNumber"].Visible = false;
        }

        private Tuple<string, string> LocateDbd(string requestedPath)
        {
            var perksPath = Path.Combine(requestedPath, "DeadByDaylight", "Content", "UI", "Icons", "Perks");
            if (Directory.Exists(perksPath))
            {
                return new Tuple<string, string>(requestedPath, perksPath);
            }
            else
            {
                return null;
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var paths = LocateDbd(fbd.SelectedPath);
                    if (paths != null)
                    {
                        _DbdPath = paths.Item1;
                        DbdPathTextBox.Text = _DbdPath;
                        _PerksPath = paths.Item2;

                        ApplyButton.Enabled = true;
                    } else
                    {
                        MessageBox.Show("Not DBD directory", "Error");
                    }
                }
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Just copy the list 4Head
            _Perks = dataGridView1.DataSource as List<Perk>;
        }

        private IEnumerable<Perk> GetSelectedPerks()
        {
            return _Perks.Where(p => p.Selected);
        }

        private void RefreshPerkList()
        {
            dataGridView1.DataSource = _Perks.OrderBy(p => p.DlcNumber).ToList();
        }

        private void SaveProfile(string TargetPath)
        {
            string[] selectedPerkNames = GetSelectedPerks().Select(p => p.PerkName).ToArray();
            string json = JsonConvert.SerializeObject(selectedPerkNames, Formatting.Indented);
            File.WriteAllText(TargetPath, json);
        }

        private void LoadProfile(string TargetPath)
        {
            string[] selectedPerkNames = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(TargetPath));
            foreach(var perkName in selectedPerkNames)
            {
                var perk = _Perks.Find(p => p.PerkName.Equals(perkName));
                if (perk != null)
                {
                    perk.Selected = true;
                }
            }

            RefreshPerkList();
        }

        private async Task DoApply()
        {
            await Task.Run(() =>
            {
                var selectedPerks = GetSelectedPerks();
                var count = selectedPerks.Count();
                int processed = 0;
                foreach (var perk in selectedPerks)
                {
                    ImageUtil.OverlayPerk(templatePathTextBox.Text, Path.Combine(_PerksPath, perk.DlcName, $"iconPerks_{perk.PerkName}.png"));
                    processed++;
                    Action func = () => {
                        ProgressLabel.Text = $"Progress {processed}/{count}";
                        progressBar1.Value = processed / count * 100;
                    };
                    if (InvokeRequired)
                    {
                        Invoke(func);
                    } else
                    {
                        func();
                    }
                }
            });
            SaveProfile(LAST_PROFILE);
            MessageBox.Show("Done!");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            _ = DoApply();
        }

        private void LoadProfileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = PROFILE_DIR;
            ofd.Filter = "JSON File|*.json";
            ofd.Title = "Load profile";
            ofd.DefaultExt = "json";
            ofd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(ofd.FileName))
            {
                LoadProfile(ofd.FileName);
            }
        }

        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = PROFILE_DIR;
            sfd.Filter = "JSON File|*.json";
            sfd.Title = "Save profile";
            sfd.DefaultExt = "json";
            sfd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(sfd.FileName))
            {
                SaveProfile(sfd.FileName);
            }
        }

        private void LoadLastProfileButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(LAST_PROFILE))
            {
                LoadProfile(LAST_PROFILE);
            }
            else
            {
                MessageBox.Show("Last applied profile not found", "Error");
            }
        }
    }
}
