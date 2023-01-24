using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] private LocalizerType _localizerType = LocalizerType.None;
        [SerializeField] private Language _defaultLanguage = null;

        private void Awake()
        {
            if (_localizerType == LocalizerType.None) return;
            LocalizationSystem.Initialize(CreateLocalizer());
        }

        public void SetLanguage(Language language)
        {
            LocalizationSystem.SetLanguage(language);
        }

        private ILocalizer CreateLocalizer()
        {
            switch (_localizerType)
            {
                default: return null;
                case LocalizerType.CSV: return new CSVLocalizer(_defaultLanguage);
                case LocalizerType.PO: return new POLocalizer(_defaultLanguage);
            }
        }
    }
}