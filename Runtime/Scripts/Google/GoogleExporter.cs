using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Kaynir.Localization.Google
{
    public class GoogleExporter : MonoBehaviour
    {
        private const string URL_FORMAT = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&gid={1}";
        private const string FILE_FORMAT = ".csv";

        [Header("Spreadsheet Settings:")]
        [SerializeField] private string _tableID = string.Empty;
        [SerializeField, Min(0)] private int _sheetID = 0;

        [Header("Export Settings:")]
        [SerializeField] private Object _resourceFolder = null;
        [SerializeField] private string _fileName = "Localization";

#if UNITY_EDITOR
        public void ExportSheet()
        {
            StopAllCoroutines();
            StartCoroutine(ExportRoutine());
        }

        private IEnumerator ExportRoutine()
        {
            string url = string.Format(URL_FORMAT, _tableID, _sheetID);
            UnityWebRequest request = UnityWebRequest.Get(url);

            Debug.Log($"<color=yellow>Exporting from URL: {url}.</color>");

            yield return request.SendWebRequest();

            if (request.result == Result.Success)
            {
                WriteToFile(request.downloadHandler.data);
            }

            Debug.Log($"<color=yellow>Export completed with result: {request.result}.</color>");
        }

        private void WriteToFile(byte[] data)
        {
            string folder = AssetDatabase.GetAssetPath(_resourceFolder);
            string path = $"{folder}/{_fileName}{FILE_FORMAT}";

            File.WriteAllBytes(path, data);
            AssetDatabase.Refresh();
        }
#endif
    }
}