using UnityEngine;

namespace PUCPR.SceneDocs
{
    [NoteComponentMenu("Camera State")]
    public class NoteComponent_CameraViewState : ANoteComponent
    {
        public Vector3 position;
        public Quaternion rotation;
        public float size;
        public bool isOrthographic;
    }
}
