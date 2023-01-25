using UnityEngine;
using TMPro;

namespace Kaynir.Localization
{
    public class LocalizedTextMeshPro : LocalizedBehaviour
    {
        [SerializeField] private TMP_Text _textField = null;

        protected override void Localize()
        {
            _textField.SetText(_localizationKey.Localize());
        }
    }
}