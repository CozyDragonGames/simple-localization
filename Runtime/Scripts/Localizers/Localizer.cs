using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.Localization
{
    public abstract class Localizer : MonoBehaviour
    {
        [SerializeField] private LocalizationLanguage _startLanguage = null;

        private void Start()
        {
            if (_startLanguage) 
            {
                SetLanguage(_startLanguage);
            }
        }

        public void SetLanguage(LocalizationLanguage language)
        {
            LocalizationSystem.SetLanguage(language, this);
        }

        public abstract Dictionary<string, string> GetLocalization(string languageID);
    }
}