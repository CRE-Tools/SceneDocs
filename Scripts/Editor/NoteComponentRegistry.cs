using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;


namespace PUCPR.SceneDocs.Editor
{
    public class NoteComponentRegistry
    {
        static List<Type> cached;

        public static List<Type> GetComponentTypes()
        {
            if (cached != null)
                return cached;

            cached = TypeCache.GetTypesDerivedFrom<ANoteComponent>()
                .Where(t => !t.IsAbstract)
                .ToList();

            return cached;
        }
    }
}
