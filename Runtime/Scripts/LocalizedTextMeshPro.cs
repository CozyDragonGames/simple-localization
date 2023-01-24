using UnityEngine;
using TMPro;

namespace Kaynir.Localization
{
    public class LocalizedTextMeshPro : MonoBehaviour
    {
        [SerializeField] private string _key = "Key.Name";
        [SerializeField] private TMP_Text _textField = null;

        private void Start()
        {
            UpdateTextField();
            LocalizationSystem.OnLanguageChanged += UpdateTextField;
        }

        private void OnDestroy()
        {
            LocalizationSystem.OnLanguageChanged -= UpdateTextField;
        }

        private void UpdateTextField()
        {
            _textField.SetText(_key.Localize());
        }
    }
}