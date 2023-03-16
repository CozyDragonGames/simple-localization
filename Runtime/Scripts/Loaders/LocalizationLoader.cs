using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public abstract class LocalizationLoader : MonoBehaviour
    {
        public abstract void Init(string language);
        public void Init(SystemLanguage language) => Init(language.ToString());

        public void SetLanguage(string language) => LocalizationSystem.SetLanguage(language);
        public void SetLanguage(SystemLanguage language) => SetLanguage(language.ToString());

        protected void Init(ILocalizer localizer, string language)
        {
            LocalizationSystem.Init(localizer);
            SetLanguage(language);
        }
    }
}