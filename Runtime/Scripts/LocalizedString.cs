using System;
using UnityEngine;

namespace Kaynir.SimpleLocalization
{
    [Serializable]
    public class LocalizedString
    {
        [SerializeField] private string _key = "Key";

        public string Value => LocalizationSystem.GetLocalizedString(_key);
    }
}