using System;
using System.Collections.Generic;
using UnityEngine;
using ShockSprint.Configs;
using ShockSprint.Network;

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
        private PlayerNetwork _networkPart = null;
        [SerializeField]
        private List<RuntimeAnimatorController> _controllers = null;
        private Animator _animator = null;
        private Vector2 _currentMoving = Vector2.zero;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            Camera.main.transform.SetParent(transform.parent);
            Camera.main.transform.localPosition = MainConfig.Instance.CameraOffset;
        }

        public void Stop()
        {
            if (_networkPart.IsLocalPlayer)
                return;

            _currentMoving = Vector2.zero;
            _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Idle];
        }

        public void Move(float value)
        {
            if (_networkPart.IsLocalPlayer)
                return;

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
            if (!_networkPart.IsLocalPlayer)
                return;

            if (_currentMoving.x == 0.0f)
            {
                _animator.runtimeAnimatorController = _controllers[(int)AnimationType.Rotate];
            }

            _currentMoving.y = value;
            transform.Rotate(0, value, 0);
        }

        public void Sprint()
        {
            if (!_networkPart.IsLocalPlayer)
                return;

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
            //if (!_networkPart.isLocalPlayer)
            //    return;

        }

        private void OnCollisionEnter(Collision collision)
        {
            //if (!_networkPart.isLocalPlayer)
            //    return;

        }
    }
}
