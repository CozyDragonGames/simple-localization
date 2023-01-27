using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization
{
    public class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] protected string _defaultLanguage = "Russian";

        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            TextAsset sheet = Resources.Load<TextAsset>("Localization/");

            LocalizationSystem.Initialize(new CSVLocalizer(sheet));
            LocalizationSystem.SetLanguage(_defaultLanguage);
        }
    }
}