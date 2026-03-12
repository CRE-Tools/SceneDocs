using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PUCPR.SceneDocs
{
    public class NoteData : ScriptableObject
    {
        //DATA
        public string id;
        public string title;
        public string description;

        [SerializeField]
        private List<NoteDataComponent> components = new List<NoteDataComponent>();

        public T GetNoteComponent<T>() where T : NoteDataComponent
        {
            foreach (var c in components)
            {
                if (c is T t)
                    return t;
            }
            return null;
        }

#if UNITY_EDITOR
        public T AddComponent<T>() where T : NoteDataComponent
        {
            T comp = ScriptableObject.CreateInstance<T>();
            comp.owner = this;

            components.Add(comp);

            AssetDatabase.AddObjectToAsset(comp, this);
            AssetDatabase.SaveAssets();

            return comp;
        }
#endif
        /*
        //public List<string> comments = new List<string>();

        //Scene
        public string sceneName;
        public Vector3 scenePosition;

        //camera view
        public CameraView cameraView;

        //user
        public string user_author;
        public string user_lastUpdate;

        //DateTime
        public string date_created;
        public string date_lastUpdate;
        */
    }
}
