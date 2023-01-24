using System;
using Kaynir.Localization.Localizers;

namespace Kaynir.Localization
{
    public static class LocalizationSystem
    {
        public const string FOLDER_NAME = "Localization";

        public static event Action OnLanguageChanged;

        private static ILocalizer _localizer;

        public static void Initialize(ILocalizer localizer)
        {
            _localizer = localizer;
            OnLanguageChanged?.Invoke();
        }

        public static void SetLanguage(Language language)
        {
            _localizer.LoadLanguage(language);
            OnLanguageChanged?.Invoke();
        }

        public static string GetString(string key)
        {
            return _localizer.GetString(key);
        }
    }
}