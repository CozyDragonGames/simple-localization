using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public class CSVLocalizationLoader : LocalizationLoader
    {
        [SerializeField] private TextAsset _textAsset = null;

        public override void Init(SystemLanguage language)
        {
            LocalizationSystem.Init(new CSVLocalizer(_textAsset));
            LocalizationSystem.SetLanguage(language);
        }
    }
}