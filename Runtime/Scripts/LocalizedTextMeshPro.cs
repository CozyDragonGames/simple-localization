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
            UpdateTextField(LocalizationSystem.Language);
            
            LocalizationSystem.OnLanguageChanged += UpdateTextField;
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