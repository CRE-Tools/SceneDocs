using UnityEngine;
using UnityEditor;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(Note))]
    public class NoteEditor : UnityEditor.Editor
    {
        private Note _note;
        private string _noteName;
        private UnityEditor.Editor _noteEditor;

        private void OnEnable()
        {
            _note = (Note)target;
        }

        public override void OnInspectorGUI()
        {
            if (AddNewNote())
                return;
            GUILayout.Space(10);

            if (!DrawNoteData())
                return;

            AddNewNoteComponent();
        }

        private bool AddNewNote()
        {
            if (_note.currentNote == null)
            {
                GUILayout.Label("New Note", EditorStyles.boldLabel);
                _noteName = EditorGUILayout.TextField("Title", _noteName);

                EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty(_noteName));
                if (GUILayout.Button("Create"))
                {
                    string folder = "Assets/Notes";
                    NoteUtility.EnsureFolderExists(folder);

                    _note.currentNote = ScriptableObject.CreateInstance<NoteData>();

                    string path = $"{folder}/{_noteName}.asset";

                    UnityEditor.AssetDatabase.CreateAsset(_note.currentNote, path);
                    PopulateNewNote();
                    UnityEditor.AssetDatabase.SaveAssets();
                }
                EditorGUI.EndDisabledGroup();

                GetNoteEditor();

                return true;
            }
            return false;
        }

        private void GetNoteEditor()
        {
            if (_note.currentNote != null)
            {
                if (_noteEditor == null || _noteEditor.target != _note.currentNote)
                    UnityEditor.Editor.CreateCachedEditor(_note.currentNote, null, ref _noteEditor);
            }
        }

        private bool DrawNoteData()
        {
            if (!_noteEditor)
            {
                GetNoteEditor();
                return false;
            }

            _noteEditor.OnInspectorGUI();

            return true;
        }

        private void AddNewNoteComponent()
        {
            if (GUILayout.Button("Add Note Component"))
            {
                var menu = new GenericMenu();

                foreach (var type in NoteComponentRegistry.GetComponentTypes())
                {
                    string menuName = NoteUtility.GetMenuName(type);

                    bool alreadyHas = _note.currentNote.HasComponent(type);

                    if (alreadyHas)
                        menu.AddDisabledItem(new GUIContent(menuName));
                    else
                        menu.AddItem(new GUIContent(menuName), false, () =>
                        {
                            _note.currentNote.AddComponent(type, menuName);
                        });
                }

                menu.ShowAsContext();
            }
        }

        private void PopulateNewNote()
        {
            _note.currentNote.title = _noteName;
            //_note.currentNote.sceneName = 
            //_note.currentNote.user_author = 
            //_note.currentNote.date_created =
            //_note.currentNote.date_lastUpdate = 
        }

        private void OnDisable()
        {
            if (_noteEditor != null)
                DestroyImmediate(_noteEditor);
        }
    }
}
