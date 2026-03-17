using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PUCPR.SceneDocs.Editor
{

    public class AEditor<T> : UnityEditor.Editor where T : class
    {
        private bool IsBeginDrawDirectly()
        {
            return Selection.activeObject == target;
        }
    }
}
