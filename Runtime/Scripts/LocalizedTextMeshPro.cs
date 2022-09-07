using UnityEngine;
using TMPro;

namespace CozyDragon.Localization
{
    public class LocalizedTextMeshPro : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textField = null;
        [SerializeField] private LocalizedString _text = new LocalizedString();

        private void OnEnable()
        {
            LocalizationSystem.OnLanguageChanged += UpdateTextField;
            UpdateTextField(LocalizationSystem.Language);
        }

        private void OnDisable()
        {
            LocalizationSystem.OnLanguageChanged -= UpdateTextField;
        }

        private void UpdateTextField(SystemLanguage language)
        {
            _textField.SetText(_text.Value);
        }
    }
}