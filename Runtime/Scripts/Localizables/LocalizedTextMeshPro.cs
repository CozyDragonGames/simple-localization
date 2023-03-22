using UnityEngine;
using TMPro;

namespace Kaynir.Localization.Localizables
{
    public class LocalizedTextMeshPro : LocalizedBehaviour
    {
        [SerializeField] private TMP_Text _textField = null;
        [SerializeField] private LocalizedString _localizedString = new LocalizedString("Key");

        protected override void Localize(string language)
        {
            _textField.SetText(_localizedString);
        }
    }
}