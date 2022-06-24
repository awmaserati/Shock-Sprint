using System;
using ShockSprint.Data;
using UnityEngine;

namespace ShockSprint.Models.Game
{
    public class PlayerModel
    {
        public event Action OnStay = null;
        public event Action<float> OnMove = null;
        public event Action<float> OnRotate = null;
        public event Action OnSprint = null;
        public event Action OnKnockOuted = null;

        private GameData.PlayerState _playerState = GameData.PlayerState.Idle;
        public int KnockOutCount { get; private set; }

        public bool IsStay => _playerState == GameData.PlayerState.Idle;
        public bool IsMove => _playerState == GameData.PlayerState.Move;
        public bool IsSprint => _playerState == GameData.PlayerState.Sprint;
        public bool IsUntouchable => _playerState == GameData.PlayerState.Untouchable;

        public PlayerModel()
        {
            Stop();
        }

        public void Stop()
        {
            _playerState = GameData.PlayerState.Idle;
            OnStay?.Invoke();
        }

        public void Move(float value)
        {
            _playerState = GameData.PlayerState.Move;
            OnMove?.Invoke(value);
        }

        public void Rotate(float value)
        {
            _playerState = GameData.PlayerState.Move;
            OnRotate?.Invoke(value);
        }

        public void Sprint()
        {
            _playerState = GameData.PlayerState.Sprint;
            OnSprint?.Invoke();
        }

        public void KnockOut()
        {
            if (_playerState == GameData.PlayerState.Sprint)
            {
                KnockOutCount++;
                return;
            }

            _playerState = GameData.PlayerState.Untouchable;
            OnKnockOuted?.Invoke();
        }
    }
}
