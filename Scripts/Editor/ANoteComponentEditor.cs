using System;
using UnityEditor;
using UnityEngine;

namespace PUCPR.SceneDocs.Editor
{
    public abstract class ANoteComponentEditor : UnityEditor.Editor
    {
        protected bool IsBeginDrawDirectly() =>
            Selection.activeObject == target;

        public override void OnInspectorGUI()
        {
            if (IsBeginDrawDirectly())
            {
                DrawDefaultInspector();
                return;
            }
            DrawBase(DrawInspectorTool);
        }

        protected abstract void DrawInspectorTool();

        private void DrawBase(Action draw)
        {
            GUI.backgroundColor = new Color(0.85f, 1f, 0.85f);
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUI.backgroundColor = Color.white;
            draw?.Invoke();
            EditorGUILayout.EndVertical();
        }
    }
}
