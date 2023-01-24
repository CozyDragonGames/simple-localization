using UnityEngine;

namespace Kaynir.Localization.Localizers
{
    public class POLocalizer : ILocalizer
    {
        private LocalizationAsset localization;

        public POLocalizer(Language language)
        {
            LoadLanguage(language);
        }

        public string GetString(string key)
        {
            return localization.GetLocalizedString(key);
        }

        public void LoadLanguage(Language language)
        {
            localization = Resources.Load<LocalizationAsset>(GetFilePath(language.ID));
        }

        private string GetFilePath(string languageID)
        {
            return $"{LocalizationSystem.FOLDER_NAME}/{languageID}";
        }
    }
}