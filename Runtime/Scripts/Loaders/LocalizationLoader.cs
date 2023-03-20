using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public abstract class LocalizationLoader : MonoBehaviour
    {
        public abstract void SetLanguage(string language);
        public void SetLanguage(SystemLanguage language) => SetLanguage(language.ToString());

        protected void SetLanguage(ILocalizer localizer, string language)
        {
            LocalizationSystem.Init(localizer);
            LocalizationSystem.SetLanguage(language);
        }
    }
}