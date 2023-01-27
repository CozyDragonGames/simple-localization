using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] protected string _defaultLanguage = "Russian";
        [SerializeField] protected TextAsset _textSheet = null;

        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            LocalizationSystem.Initialize(new CSVLocalizer(_textSheet));
            LocalizationSystem.SetLanguage(_defaultLanguage);
        }
    }
}