using System;
using UnityEngine;

namespace Kaynir.Localization.Localizables
{
    [Serializable]
    public struct LocalizedString
    {
        [SerializeField] private string _key;

        public string Value => LocalizationSystem.GetString(_key);

        public LocalizedString(string key) => _key = key;

        public static implicit operator string(LocalizedString ls) => ls.Value;
        public static explicit operator LocalizedString(string key) => new LocalizedString(key);
    }
}