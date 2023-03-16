using UnityEngine;

namespace Kaynir.Localization.Localizables
{
    public abstract class LocalizedBehaviour : MonoBehaviour
    {
        protected virtual void Start()
        {
            Localize(LocalizationSystem.Language);
            LocalizationSystem.OnLanguageChanged += Localize;
        }

        protected virtual void OnDestroy()
        {
            LocalizationSystem.OnLanguageChanged -= Localize;
        }

        protected abstract void Localize(string language);
    }
}