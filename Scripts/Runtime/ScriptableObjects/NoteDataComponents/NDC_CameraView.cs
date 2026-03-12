using UnityEngine;

namespace PUCPR.SceneDocs
{
    [CreateAssetMenu(fileName = "NDC_CameraView")]
    public class NDC_CameraView : NoteDataComponent
    {
        public Vector3 position;
        public Quaternion rotation;
        public float size;
        public bool isOrthographic = false;
    }
}
