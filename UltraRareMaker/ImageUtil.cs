using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace UltraRareMaker
{
    class ImageUtil
    {
        private static string lastBackgroundPath = "";
        private static Image lastBackground = null;

        public static void OverlayPerk(string backgroundPath, string perkPath)
        {
            if (!File.Exists(backgroundPath) || !File.Exists(perkPath))
            {
                MessageBox.Show($"Background image {backgroundPath} or perk image {perkPath} is missing.");
                return;
            }

            var background =  backgroundPath.Equals(lastBackgroundPath) ? lastBackground : Image.FromFile(backgroundPath);
            lastBackground = background;
            lastBackgroundPath = backgroundPath;
            var perk = Image.FromFile(perkPath);
            Image result = new Bitmap(background.Width, background.Height);
            using (var graphic = Graphics.FromImage(result))
            {
                graphic.DrawImage(background, new Point(0, 0));
                graphic.DrawImage(perk, new Point(0, 0));
            }
            perk.Dispose();
            result.Save(perkPath, ImageFormat.Png);
        }
    }
}
