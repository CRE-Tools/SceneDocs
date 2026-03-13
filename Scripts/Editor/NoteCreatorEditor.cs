using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteCreator))]
    public class NoteCreatorEditor : UnityEditor.Editor
    {
        private NoteCreator creator;
        private string noteName;

        private void OnEnable()
        {
            creator = (NoteCreator)target;
        }

        public override void OnInspectorGUI()
        {
            if (NewNote())
                return;
            GUILayout.Space(10);
            AddNewNoteComponent();

        }

        private bool NewNote()
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
                return true;
            }
            return false;
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
    }
}
