using System;
using UnityEngine;

namespace PUCPR.SceneDocs
{
    [Serializable]
    public class CameraView
    {
        public Vector3 position;
        public Quaternion rotation;
        public float size;
        public bool isOrthographic;
    }
}
