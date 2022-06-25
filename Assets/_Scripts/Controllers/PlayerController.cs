using ShockSprint.Events;
using ShockSprint.Models.Game;
using ShockSprint.Views.Game;

namespace ShockSprint.Controllers
{
    public class PlayerController : IController
    {
        private PlayerModel _playerModel = null;
        private PlayerView _playerView = null;

        public PlayerController()
        {
            _playerView = UnityEngine.Object.FindObjectOfType<PlayerView>();
            _playerModel = new PlayerModel();
            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            _playerModel.OnStay += _playerView.Stop;
            _playerModel.OnMove += _playerView.Move;
            _playerModel.OnRotate += _playerView.Rotate;
            _playerModel.OnSprint += _playerView.Sprint;
            _playerView.OnSprintEnded += _playerModel.SprintEnd;
            _playerModel.OnKnockOuted += _playerView.KnockOuted;
            _playerView.OnKnockOut += _playerModel.KnockOut;
        }

        private void RemoveEventHandlers()
        {
            _playerModel.OnStay -= _playerView.Stop;
            _playerModel.OnMove -= _playerView.Move;
            _playerModel.OnRotate -= _playerView.Rotate;
            _playerModel.OnSprint -= _playerModel.Sprint;
            _playerView.OnSprintEnded -= _playerModel.SprintEnd;
            _playerModel.OnKnockOuted -= _playerView.KnockOuted;
            _playerView.OnKnockOut -= _playerModel.KnockOut;
        }

        public void Dispose()
        {
            RemoveEventHandlers();
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            if(controllerEvent.GetType() == typeof(InputMoveEvent))
            {
                _playerModel.Move(((InputMoveEvent)controllerEvent).Value);
            }
            else if(controllerEvent.GetType() == typeof(InputRotateEvent))
            {
                _playerModel.Rotate(((InputRotateEvent)controllerEvent).Value);
            }
            else if(controllerEvent.GetType() == typeof(InputSprintEvent))
            {
                _playerModel.Sprint();
            }
            else if(controllerEvent.GetType() == typeof(InputStopEvent))
            {
                _playerModel.Stop();
            }
        }
    }
}
