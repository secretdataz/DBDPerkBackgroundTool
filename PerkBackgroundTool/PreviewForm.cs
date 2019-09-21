using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerkBackgroundTool
{
    public partial class PreviewForm : Form
    {
        private List<Perk> _Perks = new List<Perk>();
        private string _BackgroundPath = "_TEMPLATE.png";
        private string _PerksPath = "";

        public PreviewForm(string dbdPath, string backgroundPath, List<Perk> perks)
        {
            InitializeComponent();

            _Perks = perks;
            _BackgroundPath = backgroundPath;
            _PerksPath = dbdPath;
            perkComboBox.DataSource = _Perks;
            perkComboBox.DisplayMember = "DisplayName";
            //perkComboBox.ValueMember = "PerkName";
        }

        private void ReRender()
        {
            pictureBox1.Image = ImageUtil.Render(_BackgroundPath, ((Perk)perkComboBox.SelectedValue).GetPath(_PerksPath));
            pictureBox1.Update();
        }

        private void PerkComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ReRender();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
