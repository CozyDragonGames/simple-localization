using UnityEngine;

namespace Kaynir.Localization
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Localization/Language")]
    public class LocalizationLanguage : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; } = "Russian";

        public static implicit operator string(LocalizationLanguage language)
        {
            return language.ID;
        }
    }
}