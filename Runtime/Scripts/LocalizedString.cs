using System;
using UnityEngine;

namespace CozyDragon.Localization
{
    [Serializable]
    public class LocalizedString
    {
        [SerializeField] private string _key = "Key";

        public string Value => LocalizationSystem.GetLocalizedString(_key);
    }
}