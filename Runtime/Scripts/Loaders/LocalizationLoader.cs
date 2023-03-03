using UnityEngine;

namespace Kaynir.Localization.Loaders
{
    public abstract class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] private SystemLanguage _defaultLanguage = SystemLanguage.Russian;

        public abstract void Init(SystemLanguage language);

        [ContextMenu("Init")]
        public void Init() => Init(_defaultLanguage);
    }
}