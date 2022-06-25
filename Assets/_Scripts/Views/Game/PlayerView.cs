using System;
using System.Collections.Generic;
using UnityEngine;
using ShockSprint.Configs;

namespace ShockSprint.Views.Game
{
    public class PlayerView : MonoBehaviour
    {

        /// <summary>
        /// я знаю, что подход не самый лучший
        /// </summary>
        public enum AnimationType
        {
            Idle = 0,
            MoveForvard = 1,
            MoveBack = 2,
            Rotate = 3,
            Sprint = 4,
        }

        public event Action OnKnockOut = null;
        public event Action OnSprintEnded = null;

        [SerializeField]
        private List<RuntimeAnimatorController> _controllers = null;
        private Animator _animator = null;
        private Vector2 _currentMoving = Vector2.zero;


        private void Awake()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = MainConfig.Instance.CameraOffset;
            _animator = GetComponent<Animator>();
        }

        public void Stop()
        {
            _currentMoving = Vector2.zero;
            _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Idle];
        }

        public void Move(float value)
        {
            _currentMoving = new Vector2(value, 0.0f);

            if (value == 0.0f)
            {
                return;
            }
            
            _animator.runtimeAnimatorController = (value > 0.0f) 
                ? _controllers[(int)AnimationType.MoveForvard]
                : _controllers[(int)AnimationType.MoveBack];

            transform.Translate(0, 0, value);
        }

        public void Rotate(float value)
        {
            if(_currentMoving.x == 0.0f)
            {
                _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Rotate];
            }

            _currentMoving.y = value;
            transform.Rotate(0, value, 0);
        }

        public void Sprint()
        {
            _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Sprint];
            StartCoroutine(SprintCoroutine());
        }

        private IEnumerator<object> SprintCoroutine()
        {
            var time = 0.0f;
            var prevValue = Vector3.zero;
            var currentValue = Vector3.zero;

            do
            {
                time += Time.deltaTime;
                currentValue = Vector3.Lerp(Vector3.zero, new Vector3(0, 0, MainConfig.Instance.SprintDistance), 
                    time / MainConfig.Instance.SprintTime);
                transform.Translate(currentValue - prevValue, Space.Self);
                prevValue = currentValue;
                yield return null;
            } while (time < MainConfig.Instance.SprintTime);

            _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Idle];
            OnSprintEnded?.Invoke();
        }

        public void KnockOuted()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
