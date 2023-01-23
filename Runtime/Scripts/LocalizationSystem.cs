using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.Localization
{
    public static class LocalizationSystem
    {
        public static event Action OnLanguageChanged;

        private static Dictionary<string, string> _localization = new Dictionary<string, string>();

        public static void SetLanguage(LocalizationLanguage language, Localizer localizer)
        {
            _localization = localizer.GetLocalization(language);
            OnLanguageChanged?.Invoke();
        }

        public static string GetLocalizedString(string key)
        {
            if (!_localization.TryGetValue(key, out string value))
            {
                Debug.Log($"Localization for {key} is missing.");
                return key;
            }

            return value;
        }
    }
}