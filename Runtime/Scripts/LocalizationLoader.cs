using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CozyDragon.Localization
{
    public class LocalizationLoader : MonoBehaviour
    {
        [SerializeField] private List<LocalizationFile> _files = new List<LocalizationFile>();

        public SystemLanguage Language => LocalizationSystem.Language;

        public int LanguageIndex { get; private set; }

        public void SetLanguage(SystemLanguage language)
        {
            if (!IsLanguageSupported(language)) return;

            LocalizationFile file = _files.Find(f => f.Language == language);
            SetLanguage(file);
        }

        public void SetLanguage(int fileIndex)
        {
            SetLanguage(_files[fileIndex]);
        }

        public bool IsLanguageSupported(SystemLanguage language)
        {
            if (_files.Exists(f => f.Language == language))
            {
                return true;
            }

            Debug.Log($"Language {language} is not supported.");
            return false;
        }

        private void SetLanguage(LocalizationFile file)
        {
            LanguageIndex = _files.IndexOf(file); 
            LocalizationSystem.SetLanguage(file.Language, file.GetLocalization());
        }

        [ContextMenu("Create Localization Files")]
        private void CreateLocalizationFiles()
        {
            for (int i = 0; i < _files.Count; i++)
            {
                string path = _files[i].GetFullPath();
                string defaultValue = _files[i].Language.ToString();

                Localization localization = new Localization("Language", defaultValue);

                if (File.Exists(path)) continue;

                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, JsonUtility.ToJson(localization, true));
            }
        }
    }
}