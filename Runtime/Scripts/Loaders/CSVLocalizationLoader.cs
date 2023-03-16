using Kaynir.Localization.Localizers;
using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public class CSVLocalizationLoader : LocalizationLoader
    {
        [SerializeField] private TextAsset _textSheet = null;

        public override void Init(string language)
        {
            Init(new CSVLocalizer(_textSheet), language);
        }
    }
}