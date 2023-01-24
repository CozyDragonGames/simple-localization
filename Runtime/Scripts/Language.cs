using UnityEngine;

namespace Kaynir.Localization
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Localization/Language")]
    public class Language : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; } = "ru_RU";

        public static implicit operator string(Language language)
        {
            return language.ID;
        }
    }
}