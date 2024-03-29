﻿using System;
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

namespace PerkBackgroundTool
{
    // Yes, this is a "god" class. Refactor later if a huge improvement is needed.
    public partial class MainForm : Form
    {
        private static readonly string PROFILE_DIR = Path.Combine(Directory.GetCurrentDirectory(), "profiles");
        private static readonly string LAST_PROFILE = Path.Combine(PROFILE_DIR, "__LASTPROFILE.json");
        private List<Perk> _Perks = new List<Perk>();
        private readonly List<Chapter> _Chapters;
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

        private bool InitializeDbdPath(string DbdPath)
        {
            var paths = LocateDbd(DbdPath);
            if (paths != null)
            {
                _DbdPath = paths.Item1;
                DbdPathTextBox.Text = _DbdPath;
                _PerksPath = paths.Item2;

                ApplyButton.Enabled = true;
                PreviewBtn.Enabled = true;
                Properties.Settings.Default.LastDbdPath = DbdPath;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
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
                    if (!InitializeDbdPath(fbd.SelectedPath))
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
                    ImageUtil.OverlayPerk(templatePathTextBox.Text, perk.GetPath(_PerksPath));
                    processed++;
                    Action progressBarUpdate = () => {
                        ProgressLabel.Text = $"Progress {processed}/{count}";
                        progressBar1.Value = processed / count * 100;
                    };
                    if (InvokeRequired)
                    {
                        Invoke(progressBarUpdate);
                    } else
                    {
                        progressBarUpdate();
                    }
                }
            });
            SaveProfile(LAST_PROFILE);
            Action enableButton = () => {
                ApplyButton.Enabled = true;
            };
            if (InvokeRequired)
            {
                Invoke(enableButton);
            }
            else
            {
                enableButton();
            }
            MessageBox.Show("Done!");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            _ = DoApply();
            ApplyButton.Enabled = false;
        }

        private void LoadProfileButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                InitialDirectory = PROFILE_DIR,
                Filter = "JSON File|*.json",
                Title = "Load profile",
                DefaultExt = "json"
            })
            {
                ofd.ShowDialog();

                if (!string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    LoadProfile(ofd.FileName);
                }
            }
        }

        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog
            {
                InitialDirectory = PROFILE_DIR,
                Filter = "JSON File|*.json",
                Title = "Save profile",
                DefaultExt = "json"
            })
            {
                sfd.ShowDialog();

                if (!string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    SaveProfile(sfd.FileName);
                }
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

        private void TemplatePathBrowseButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "PNG Image|*.png",
                Title = "Load template background image",
                DefaultExt = "png"
            })
            {
                ofd.ShowDialog();

                if (!string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    templatePathTextBox.Text = ofd.FileName;
                }
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            new PreviewForm(_PerksPath, templatePathTextBox.Text, _Perks).Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _ = InitializeDbdPath(Properties.Settings.Default.LastDbdPath);
            string commit = "Unknown commit";
            string version = "Unknown version";
            if (File.Exists(".commit"))
            {
                commit = File.ReadAllText(".commit");
            }

            if (File.Exists(".version"))
            {
                version = File.ReadAllText(".version");
            }
            Text += $" - Version: {version}";
            VersionLabel.Text = $"Version: {version}     Commit: {commit}";
        }
    }
}
