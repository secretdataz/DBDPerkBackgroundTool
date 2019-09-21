using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PerkBackgroundTool
{
    class ImageUtil
    {
        private static string lastBackgroundPath = "";
        private static Image lastBackground = null;

        public static void OverlayPerk(string backgroundPath, string perkPath)
        {
            var result = Render(backgroundPath, perkPath);
            if (result == null)
            {
                MessageBox.Show($"Background image {backgroundPath} or perk image {perkPath} is missing.");
                return;
            }

            result.Save(perkPath, ImageFormat.Png);
        }

        private static Image Resize(Image img)
        {
            var bitmap = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(img, 0, 0, 256, 256);
            }

            return bitmap;
        }

        public static Image Render(string backgroundPath, string perkPath)
        {
            if (!File.Exists(backgroundPath) || !File.Exists(perkPath))
            {
                return null;
            }

            var background = backgroundPath.Equals(lastBackgroundPath) ? lastBackground : Resize(Image.FromFile(backgroundPath));
            lastBackground = background;
            lastBackgroundPath = backgroundPath;
            var perk = Image.FromFile(perkPath);
            Image result = new Bitmap(256, 256); // Force the result image size to be 256x256 pixels
            using (var graphic = Graphics.FromImage(result))
            {
                graphic.DrawImage(background, new Point(0, 0));
                graphic.DrawImage(perk, new Point(0, 0));
            }
            perk.Dispose();
            return result;
        }
    }
}
