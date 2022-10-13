using System;
using UnityEngine;

namespace Kaynir.SimpleLocalization
{
    [Serializable]
    public class LocalizationFile
    {
        private static string FOLDER_NAME = "Localization";

        [SerializeField] private SystemLanguage _language = SystemLanguage.Unknown;

        public SystemLanguage Language => _language;
        public string Path => $"{FOLDER_NAME}/{_language}";

        public Localization GetLocalization()
        {
            TextAsset file = Resources.Load<TextAsset>(Path);

            if (file)
            {
                return JsonUtility.FromJson<Localization>(file.text);
            }

            Debug.Log($"Localization file for {_language} is missing.");
            return new Localization();
        }
    }
}