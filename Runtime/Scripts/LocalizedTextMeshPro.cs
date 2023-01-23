using UnityEngine;
using TMPro;

namespace Kaynir.Localization
{
    public class LocalizedTextMeshPro : MonoBehaviour
    {
        [SerializeField] private string _key = "UI.Key";
        [SerializeField] private TMP_Text _textField = null;

        private void OnEnable()
        {
            UpdateTextField();
            LocalizationSystem.OnLanguageChanged += UpdateTextField;
        }

        private void OnDisable()
        {
            LocalizationSystem.OnLanguageChanged -= UpdateTextField;
        }

        private void UpdateTextField()
        {
            _textField.SetText(_key.Localize());
        }
    }
}