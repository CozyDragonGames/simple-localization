using System.Collections.Generic;
using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public class LanguageSelection : MonoBehaviour
    {
        [SerializeField] private Localizer _localizer = null;
        [SerializeField] private List<SystemLanguage> _languageList = new List<SystemLanguage>();

        public void SetLanguage(int index)
        {
            SetLanguage(_languageList[index]);
        }

        public void SetLanguage(SystemLanguage language)
        {
            _localizer.SetLanguage(language);
        }
    }
}