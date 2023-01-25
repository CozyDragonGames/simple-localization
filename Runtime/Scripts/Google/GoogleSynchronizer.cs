using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Kaynir.Localization.Google
{
    public class GoogleSynchronizer : MonoBehaviour
    {
        private const string URL_FORMAT = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&gid={1}";
        private const string CSV_FORMAT = ".csv";

        [SerializeField] private string _tableID = string.Empty;
        [SerializeField] private Object _resourceFolder = null;
        [SerializeField] private List<GoogleSheet> _sheets = new List<GoogleSheet>();

#if UNITY_EDITOR
        [ContextMenu("Download Sheets")]
        public void DownloadSheets()
        {
            StopAllCoroutines();
            StartCoroutine(DownloadRoutine());
        }

        private IEnumerator DownloadRoutine()
        {
            string folder = UnityEditor.AssetDatabase.GetAssetPath(_resourceFolder);
            var requests = new Dictionary<string, UnityWebRequest>();

            foreach (GoogleSheet sheet in _sheets)
            {
                string url = string.Format(URL_FORMAT, _tableID, sheet.id);
                UnityWebRequest request = UnityWebRequest.Get(url);
                
                Debug.Log($"<color=yellow>Downloading from URL: {url}.</color>");
                
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    SaveSheetToFile(sheet, folder, request.downloadHandler.data);
                }
            }

            UnityEditor.AssetDatabase.Refresh();
            
            Debug.Log("<color=yellow>Download completed.</color>");
        }

        private void SaveSheetToFile(GoogleSheet sheet, string folder, byte[] data)
        {
            string path = $"{folder}/{sheet.name}{CSV_FORMAT}";
            File.WriteAllBytes(path, data);
            Debug.Log($"Sheet {sheet.name} downloaded to <color=green>{path}</color>");
        }
#endif
    }
}