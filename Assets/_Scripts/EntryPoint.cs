using ShockSprint.Controllers;
using ShockSprint.Managers;
using UnityEngine;
using Mirror;

namespace ShockSprint
{
    public class EntryPoint : MonoBehaviour
    {
        void Awake()
        {
            var goInputProvider = new GameObject("Keyboard Input Provider");
            var inputProvider = goInputProvider.AddComponent<KeyboardInputProvider>();
            var network = FindObjectOfType<NetworkManager>();

            ControllerManager.CreateController<GameController>();
            ControllerManager.CreateController<PlayerController>();
            ControllerManager.CreateController<UIController>();
            var networkController = ControllerManager.CreateController<NetworkController>();
            networkController.SetNetwork(network);
            var inputController = ControllerManager.CreateController<InputController>();
            inputController.SetProvider(inputProvider);
        }

        private void OnDestroy()
        {
            ControllerManager.RemoveController<GameController>();
            ControllerManager.RemoveController<PlayerController>();
            ControllerManager.RemoveController<UIController>();
            ControllerManager.RemoveController<NetworkController>();
            ControllerManager.RemoveController<InputController>();
        }
    }
}