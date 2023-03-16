using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.Localization.Localizers
{
    public class CSVLocalizer : ILocalizer
    {
        private const string KEY_HEADER = "Key";

        private TextAsset _textSheet;
        private Dictionary<string, string> _localization;

        public CSVLocalizer(TextAsset textSheet)
        {
            _textSheet = textSheet;
            _localization = new Dictionary<string, string>();
        }

        public bool TryGetString(string key, out string value)
        {
            return _localization.TryGetValue(key, out value);
        }

        public void SetLanguage(string language)
        {
            _localization = new Dictionary<string, string>();

            foreach (var entry in CSVReader.FromCSV(_textSheet))
            {
                if (!entry.TryGetValue(KEY_HEADER, out string key)) continue;
                if (!entry.TryGetValue(language, out string value)) continue;

                _localization[key] = value;
            }
        }
    }
}