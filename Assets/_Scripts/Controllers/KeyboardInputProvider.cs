using System;
using UnityEngine;

namespace ShockSprint.Controllers
{
    public class KeyboardInputProvider : MonoBehaviour
    {
        public event Action<float> OnMove = null;
        public event Action<float> OnRotate = null;
        public event Action OnStop = null;
        public event Action OnSprint = null;

        private bool _isAnyKeyPressed = false;

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
            float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

            if (moveX == 0 && moveZ == 0)
            {
                OnStop?.Invoke();
            }
            else
            {
                OnMove?.Invoke(moveZ);
                OnRotate?.Invoke(moveX);
            }

            if(Input.GetMouseButtonDown(0))
            {
                OnSprint?.Invoke();
            }
        }
    }
}
