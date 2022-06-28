using ShockSprint.Events;
using ShockSprint.Managers;
using Mirror;

namespace ShockSprint.Controllers
{
    public class NetworkController : IController
    {
        private NetworkManager _networkManger;
        

        public NetworkController()
        {
            
        }

        public void SetNetwork(NetworkManager manager)
        {
            _networkManger = manager;
        }

        public void Dispose()
        {
            
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            if (controllerEvent.GetType() == typeof(StartHostGameEvent))
            {
                _networkManger.StartHost();
                ControllerManager.DispatchEvent<GameController>(ControllerEventPool.CreateEvent<GameStartEvent>());
            }
        }
    }
}
