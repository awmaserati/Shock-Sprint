using ShockSprint.Managers;
using ShockSprint.Events;

namespace ShockSprint.Controllers
{
    public class InputController : IController
    {
        private KeyboardInputProvider _inputProvider = null;

        public InputController()
        {
            
        }

        public void SetProvider(KeyboardInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            DisposeEventHandlers();
            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            _inputProvider.OnMove += OnMoveEvent;
            _inputProvider.OnRotate += OnRotateEvent;
            _inputProvider.OnStop += OnStopEvent;
            _inputProvider.OnSprint += OnSprintEvent;
        }

        private void DisposeEventHandlers()
        {
            _inputProvider.OnMove -= OnMoveEvent;
            _inputProvider.OnRotate -= OnRotateEvent;
            _inputProvider.OnStop -= OnStopEvent;
            _inputProvider.OnSprint -= OnSprintEvent;
        }

        public void Dispose()
        {
            DisposeEventHandlers();
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            
        }

        private void OnMoveEvent(float value)
        {
            ControllerManager.DispatchEvent<PlayerController>(ControllerEventPool.CreateEvent<InputMoveEvent, float>(value));
        }

        private void OnRotateEvent(float value)
        {
            ControllerManager.DispatchEvent<PlayerController>(ControllerEventPool.CreateEvent<InputRotateEvent, float>(value));
        }

        private void OnStopEvent()
        {
            ControllerManager.DispatchEvent<PlayerController>(ControllerEventPool.CreateEvent<InputStopEvent>());
        }

        private void OnSprintEvent()
        {
            ControllerManager.DispatchEvent<PlayerController>(ControllerEventPool.CreateEvent<InputSprintEvent>());
        }
    }
}
