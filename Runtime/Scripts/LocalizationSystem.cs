using System;
using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public static class LocalizationSystem
    {
        public static event Action<string> OnLanguageChanged;
        
        public static string Language { get; private set; }

        private static ILocalizer _localizer;

        public static void Init(ILocalizer localizer) => _localizer = localizer;

        public static void SetLanguage(string language)
        {
            _localizer.SetLanguage(language);

            Language = language;
            OnLanguageChanged?.Invoke(Language);
        }

        public static void SetLanguage(SystemLanguage language) => SetLanguage(language.ToString());

        public static string GetString(string key)
        {
            if (_localizer.TryGetString(key, out string value)) return value;
            Debug.LogWarning($"{Language} translation for [{key}] not found.");
            return key;
        }
    }
}