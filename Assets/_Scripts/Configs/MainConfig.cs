using UnityEngine;

namespace ShockSprint.Configs
{
    public class MainConfig : MonoBehaviour
    {
        public static MainConfig Instance = null;

        [Header("Player Animation")]
        public float MoveCoeff = 4f;
        public float RotateCoeff = 110f;
        public float SprintDistance = 3f;
        public float SprintTime = 0.2f;

        [Header("Camera Settings")]
        public Vector3 CameraOffset = new Vector3(0, 2, -4);



        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
