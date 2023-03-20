using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public class CSVLocalizationLoader : LocalizationLoader
    {
        [SerializeField] private TextAsset _textSheet = null;

        public override void SetLanguage(string language)
        {
            SetLanguage(new CSVLocalizer(_textSheet), language);
        }
    }
}