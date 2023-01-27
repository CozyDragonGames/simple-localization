using System;
using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public static class LocalizationSystem
    {
        public static event Action OnLanguageChanged;

        public static string Language { get; private set; } = "Russian";

        private static ILocalizer _localizer;

        public static void Initialize(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public static void SetLanguage(string language)
        {
            _localizer.SetLanguage(language);

            Language = language;
            OnLanguageChanged?.Invoke();
        }

        public static string GetString(string key)
        {
            if (_localizer.TryGetString(key, out string value)) return value;
            Debug.Log($"{Language} translation for {key} not found.");
            return key;
        }

        public static string GetString(string key, params object[] args)
        {
            return string.Format(GetString(key), args);
        }
    }
}