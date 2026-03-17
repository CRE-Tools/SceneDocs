using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteData))]
    public class NoteDataEditor : UnityEditor.Editor
    {
        private NoteData noteData;

        private Dictionary<ANoteComponent, UnityEditor.Editor> cachedEditors = new();
        private Dictionary<ANoteComponent, bool> foldouts = new();


        private void OnEnable()
        {
            noteData = (NoteData)target;
        }

        public override void OnInspectorGUI()
        {
            DrawNoteData();

            GUILayout.Space(10);

            DrawComponents();
        }

        private void DrawNoteData()
        {
            base.OnInspectorGUI();

        }

        private void DrawComponents()
        {
            EditorGUILayout.LabelField("Components", EditorStyles.boldLabel);

            foreach (var component in noteData.Components)
            {
                if (component == null) 
                    continue;
                var editor = SetupFoldoutAndEditor(component);

                EditorGUILayout.BeginVertical("box");

                FoldoutComponentHeader(component, out bool isRemoved);
                if (isRemoved)
                    return;

                if (foldouts[component])
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.Space();
                    editor.OnInspectorGUI();
                    EditorGUI.indentLevel--;
                }

                EditorGUILayout.EndVertical();
            }
        }

        private UnityEditor.Editor SetupFoldoutAndEditor(ANoteComponent component)
        {
            if (!foldouts.ContainsKey(component))
                foldouts[component] = true;

            UnityEditor.Editor editor;
            cachedEditors.TryGetValue(component, out editor);
            UnityEditor.Editor.CreateCachedEditor(component, null, ref editor);
            cachedEditors[component] = editor;

            return editor;
        }

        private void FoldoutComponentHeader(ANoteComponent component, out bool isRemoved)
        {
            string menuName = NoteUtility.GetMenuName(component.GetType());

            EditorGUILayout.BeginHorizontal();

            foldouts[component] = EditorGUILayout.Foldout(
                foldouts[component],
                menuName,
                true,
                EditorStyles.foldoutHeader);

            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Remove"))
            {
                noteData.RemoveComponent(component.GetType());
                isRemoved = true;
                return;
            }

            EditorGUILayout.EndHorizontal();
            isRemoved = false;
        }

        private void OnDisable()
        {
            foreach (var editor in cachedEditors.Values)
            {
                if (editor != null)
                    DestroyImmediate(editor);
            }
            cachedEditors.Clear();
        }
    }
}
