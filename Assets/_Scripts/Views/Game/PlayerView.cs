using System;
using UnityEngine;

namespace ShockSprint.Views.Game
{
    public class PlayerView : MonoBehaviour
    {
        public event Action OnKnockOut = null;



        private void Awake()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0.5f, -3);
        }

        public void Stop()
        {
            
        }

        public void Move(float value)
        { 

        }

        public void Rotate(float value)
        {

        }

        public void Sprint()
        {

        }

        public void KnockOuted()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
