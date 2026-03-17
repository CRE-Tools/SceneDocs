using UnityEditor;
using UnityEngine;


namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteComponent_Example))]
    public class Editor_Example : ANoteComponentEditor
    {
        protected override void DrawInspectorTool()
        {
            base.DrawDefaultInspector();
        }
    }
}
