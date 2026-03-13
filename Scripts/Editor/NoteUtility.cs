using System;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;

namespace PUCPR.SceneDocs.Editor
{
    public static class NoteUtility
    {
        #region AssetsAndFolders
        public static void EnsureFolderExists(string path)
        {
            if (AssetDatabase.IsValidFolder(path))
                return;

            string[] parts = path.Split('/');
            string current = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                string next = $"{current}/{parts[i]}";
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                }

                current = next;
            }
        }
        #endregion

        #region NoteComponents
        static Dictionary<Type, string> cache = new();

        public static string GetMenuName(Type type)
        {
            if (cache.TryGetValue(type, out var name))
                return name;

            var attr = type.GetCustomAttribute<NoteComponentMenuAttribute>();

            name = attr != null ? attr.menu : type.Name;

            cache[type] = name;

            return name;
        }
        #endregion
    }
}
