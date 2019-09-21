using System.IO;

namespace PerkBackgroundTool
{
    public class Perk
    {
        public bool Selected { get; set; }
        public string PerkName { get; set; }
        public string DisplayName { get; set; }
        public string DlcName { get; set; }
        public string DlcDisplayName { get; set; }
        public int DlcNumber { get; set; }

        public string GetPath(string BasePath = "./")
        {
            return Path.Combine(BasePath, DlcName, $"iconPerks_{PerkName}.png");
        }
    }
}
