using UnityEngine;
using UnityEditor;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteCreator))]
    public class NoteCreator_Editor : UnityEditor.Editor
    {
        private NoteCreator creator;
        private string noteName;
        private UnityEditor.Editor noteEditor;

        private void OnEnable()
        {
            creator = (NoteCreator)target;
        }

        public override void OnInspectorGUI()
        {
            if (AddNewNote())
                return;
            GUILayout.Space(10);

            if (!DrawNoteData())
                return;

            //GUILayout.Space(10);
            AddNewNoteComponent();

        }

        private bool AddNewNote()
        {
            if (creator.currentNote == null)
            {
                GUILayout.Label("Nova Nota");
                noteName = EditorGUILayout.TextField("Note", noteName);

                EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty(noteName));
                if (GUILayout.Button("Add Note"))
                {
                    string folder = "Assets/Notes";
                    NoteUtility.EnsureFolderExists(folder);

                    creator.currentNote = ScriptableObject.CreateInstance<NoteData>();

                    string path = $"{folder}/{noteName.ToUpper()}.asset";

                    UnityEditor.AssetDatabase.CreateAsset(creator.currentNote, path);
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
            if (creator.currentNote != null)
            {
                if (noteEditor == null || noteEditor.target != creator.currentNote)
                    UnityEditor.Editor.CreateCachedEditor(creator.currentNote, null, ref noteEditor);
            }
        }

        private bool DrawNoteData()
        {
            if (!noteEditor)
            {
                GetNoteEditor();
                return false;
            }

            noteEditor.OnInspectorGUI();

            return true;
        }

        private void AddNewNoteComponent()
        {
            if (GUILayout.Button("AddComponent"))
            {
                var menu = new GenericMenu();

                foreach (var type in NoteComponentRegistry.GetComponentTypes())
                {
                    string menuName = NoteUtility.GetMenuName(type);

                    bool alreadyHas = creator.currentNote.HasComponent(type);

                    if (alreadyHas)
                        menu.AddDisabledItem(new GUIContent(menuName));
                    else
                        menu.AddItem(new GUIContent(menuName), false, () =>
                        {
                            creator.currentNote.AddComponent(type, menuName);
                        });
                }

                menu.ShowAsContext();
            }
        }

        private void OnDisable()
        {
            if (noteEditor != null)
                DestroyImmediate(noteEditor);
        }
    }
}
