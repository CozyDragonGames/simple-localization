using System;
using System.Collections.Generic;
using UnityEngine;

namespace CozyDragon.Localization
{
    public static class LocalizationSystem
    {
        public static event Action<SystemLanguage> OnLanguageChanged;

        private static Dictionary<string, string> _localization = new Dictionary<string, string>();

        public static SystemLanguage Language { get; private set; } = SystemLanguage.English;

        public static void SetLanguage(SystemLanguage language, Localization localization)
        {
            Language = language;
            CreateLocalization(localization.strings);
            OnLanguageChanged?.Invoke(Language);
        }

        public static string GetLocalizedString(string key)
        {
            if (_localization.ContainsKey(key))
            {
                return _localization[key];
            }

            Debug.Log($"Localization for {key} is missing.");
            return string.Empty;
        }

        private static void CreateLocalization(List<LocalizationString> strings)
        {
            _localization = new Dictionary<string, string>();

            for (int i = 0; i < strings.Count; i++)
            {
                if (!_localization.ContainsKey(strings[i].key))
                {
                    _localization.Add(strings[i].key, strings[i].value);
                }
            }
        }
    }
}