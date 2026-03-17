using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteComponent_Example))]
    public class NC_ExampleEditor : UnityEditor.Editor
    {

        private bool IsBeginDrawDirectly()
        {
            return Selection.activeObject == target;
        }

        public override void OnInspectorGUI()
        {
            if (IsBeginDrawDirectly())
            {
                DrawDefaultInspector();
                return;
            }

            GUILayout.Button("teste de exemplo");
        }
    }
}
