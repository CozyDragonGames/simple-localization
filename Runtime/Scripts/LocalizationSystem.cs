using System;
using System.Collections.Generic;
using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public static class LocalizationSystem
    {
        public static event Action OnLanguageChanged;

        public static string Language { get; private set; } = "Russian";

        private static Dictionary<string, string> _localization = new Dictionary<string, string>();

        public static void SetLanguage(Localizer localizer, string language)
        {
            _localization = localizer.GetLocalization(language.ToString());

            Language = language;
            OnLanguageChanged?.Invoke();
        }

        public static string GetString(string key)
        {
            if (_localization.TryGetValue(key, out string value)) return value;
            Debug.Log($"{Language} translation for {key} not found.");
            return key;
        }

        public static string GetString(string key, params object[] args)
        {
            return string.Format(GetString(key), args);
        }
    }
}