using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] private Localizer _localizer = null;
        [SerializeField] private SystemLanguage _defaultLanguage = SystemLanguage.English;

        private void Awake()
        {
            LocalizationSystem.SetLanguage(_localizer, _defaultLanguage);
        }
    }
}