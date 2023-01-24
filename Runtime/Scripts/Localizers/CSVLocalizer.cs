using System.Collections.Generic;
using Kaynir.Localization.Tools;
using UnityEngine;

namespace Kaynir.Localization.Localizers
{
    public class CSVLocalizer : ILocalizer
    {
        private const string FILE_NAME = "Localization";
        private const string KEY_HEADER = "Key";

        private Dictionary<string, string> _localization;

        public CSVLocalizer(Language language)
        {
            LoadLanguage(language);
        }

        public string GetString(string key)
        {
            return _localization.TryGetValue(key, out string value) ? value : key;
        }

        public void LoadLanguage(Language language)
        {
            _localization = new Dictionary<string, string>();

            TextAsset file = Resources.Load<TextAsset>(GetFilePath());

            foreach (var entry in CSVReader.FromCSV(file))
            {
                if (!entry.TryGetValue(KEY_HEADER, out string key)) continue;
                if (!entry.TryGetValue(language.ID, out string value)) continue;

                _localization[key] = value;
            }
        }

        private string GetFilePath()
        {
            return $"{LocalizationSystem.FOLDER_NAME}/{FILE_NAME}";
        }
    }
}