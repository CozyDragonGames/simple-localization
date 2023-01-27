using UnityEngine;

namespace Kaynir.Localization
{
    public class LanguageSelection : MonoBehaviour
    {
        public void SetLanguage(string language)
        {
            LocalizationSystem.SetLanguage(language);   
        }
    }
}