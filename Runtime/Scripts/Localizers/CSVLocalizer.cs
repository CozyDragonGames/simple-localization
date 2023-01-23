using System.Collections.Generic;
using Kaynir.Localization.Tools;
using UnityEngine;

namespace Kaynir.Localization
{
    public class CSVLocalizer : Localizer
    {
        private const string KEY_HEADER = "Key";

        [SerializeField] private TextAsset _file = null;

        public override Dictionary<string, string> GetLocalization(string languageID)
        {
            Dictionary<string, string> localization = new Dictionary<string, string>();

            foreach (var entry in CSVReader.FromCSV(_file))
            {
                if (!entry.TryGetValue(KEY_HEADER, out string key)) continue;
                if (!entry.TryGetValue(languageID, out string value)) continue;

                localization[key] = value;
            }

            return localization;
        }
    }
}