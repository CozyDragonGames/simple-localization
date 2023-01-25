using UnityEngine;

namespace Kaynir.Localization
{
    public abstract class LocalizedBehaviour : MonoBehaviour
    {
        [SerializeField] protected string _localizationKey = "Key";

        protected virtual void Start()
        {
            Localize();
            LocalizationSystem.OnLanguageChanged += Localize;
        }

        protected virtual void OnDestroy()
        {
            LocalizationSystem.OnLanguageChanged -= Localize;
        }

        protected abstract void Localize();
    }
}