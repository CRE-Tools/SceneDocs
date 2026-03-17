using UnityEngine;
using UnityEditor;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteComponent_CameraViewState))]
    public class Editor_CameraViewState : ANoteComponentEditor
    {
        protected override void DrawInspectorTool()
        {
            base.DrawDefaultInspector();
        }
    }
}
