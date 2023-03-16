using UnityEngine;
using UnityEditor;
using Kaynir.Localization.Google;

namespace Kaynir.Localization.Editors
{
    [CustomEditor(typeof(GoogleExporter))]
    public class GoogleExporterEditor : Editor
    {
        private SerializedProperty _tableID;
        private SerializedProperty _resourceFolder;
        private GoogleExporter _target;

        private void OnEnable()
        {
            _target = (GoogleExporter)target;
            _tableID = serializedObject.FindProperty(nameof(_tableID));
            _resourceFolder = serializedObject.FindProperty(nameof(_resourceFolder));
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (string.IsNullOrEmpty(_tableID.stringValue)) return;
            if (!_resourceFolder.objectReferenceValue) return;

            DrawExportButton();
        }

        private void DrawExportButton()
        {
            EditorGUILayout.Space();

            if (GUILayout.Button("Export Spreadsheet"))
            {
                _target.ExportSheet();
            }
        }
    }
}