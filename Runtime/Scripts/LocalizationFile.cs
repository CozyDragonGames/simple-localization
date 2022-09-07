using System;
using System.IO;
using UnityEngine;

namespace CozyDragon.Localization
{
    [Serializable]
    public class LocalizationFile
    {
        [SerializeField] private SystemLanguage _language = SystemLanguage.Unknown;
        [SerializeField] private string _folderPath = "Localization/";

        public SystemLanguage Language => _language;

        public Localization GetLocalization()
        {
            string path = GetFullPath();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<Localization>(json);
            }

            Debug.Log($"Localization file for {_language} is missing.");
            return new Localization();
        }

        public string GetFullPath()
        {
            return $"{Application.dataPath}/{_folderPath}/{_language}.json";
        }
    }
}