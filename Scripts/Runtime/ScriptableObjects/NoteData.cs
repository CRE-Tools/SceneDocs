using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PUCPR.SceneDocs
{
    public class NoteData : ScriptableObject
    {
        #region MainData
        public string id;
        public string title;
        public string description;

        //Scene
        public string sceneName;
        public Vector3 scenePosition;

        //User
        public string user_author;
        public string user_lastUpdate;

        //DateTime
        public string date_created;
        public string date_lastUpdate;
        #endregion

        #region NoteComponets
        private List<ANoteComponent> components = new();
        public IReadOnlyList<ANoteComponent> Components => components;

        public bool HasComponent<T>() where T : ANoteComponent
        {
            foreach (var c in components)
            {
                if (c is T)
                    return true;
            }
            return false;
        }

        public T GetComponent<T>() where T : ANoteComponent
        {
            foreach (var c in components)
            {
                if (c is T t)
                    return t;
            }
            return null;
        }

        public List<ANoteComponent> GetComponents() => components;

        public T AddComponent<T>(string fileName) where T : ANoteComponent
        {
            return (T)AddComponent(typeof(T), fileName);
        }

        public ANoteComponent AddComponent(System.Type type, string fileName)
        {
            if (!typeof(ANoteComponent).IsAssignableFrom(type))
                throw new System.Exception($"{type} is not a ANoteComponent");


            if (HasComponent(type))
            {
                Debug.LogWarning($"Note already has component {type.Name}");
                return null;
            }

            var comp = ScriptableObject.CreateInstance(type) as ANoteComponent;
            comp.name = fileName;

            components.Add(comp);

#if UNITY_EDITOR
            AssetDatabase.AddObjectToAsset(comp, this);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
#endif

            return comp;
        }

        public bool HasComponent(System.Type type)
        {
            foreach (var c in components)
            {
                if (c.GetType() == type)
                    return true;
            }
            return false;
        }

        public void RemoveComponent<T>() where T : ANoteComponent
        {
            RemoveComponent(typeof(T));
        }

        public void RemoveComponent(System.Type type)
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                var c = components[i];

                if (c.GetType() == type)
                {
                    components.RemoveAt(i);

#if UNITY_EDITOR
                    AssetDatabase.RemoveObjectFromAsset(c);
                    EditorUtility.SetDirty(this);
                    Object.DestroyImmediate(c, true);
                    AssetDatabase.SaveAssets();
#endif
                }
            }
        }

        #endregion

        /*
        //public List<string> comments = new List<string>();
        */
    }
}
