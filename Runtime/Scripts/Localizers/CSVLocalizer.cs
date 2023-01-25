using System.Collections.Generic;
using Kaynir.Localization.Tools;
using UnityEngine;

namespace Kaynir.Localization.Localizers
{
    public class CSVLocalizer : Localizer
    {
        private const string KEY_HEADER = "Key";

        [SerializeField] private TextAsset _textSheet = null;

        public override Dictionary<string, string> GetLocalization(string language)
        {
            Dictionary<string, string> localization = new Dictionary<string, string>();

            foreach (var entry in CSVReader.FromCSV(_textSheet))
            {
                if (!entry.TryGetValue(KEY_HEADER, out string key)) continue;
                if (!entry.TryGetValue(language, out string value)) continue;

                localization[key] = value;
            }

            return localization;
        }
    }
}