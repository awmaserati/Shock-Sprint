using ShockSprint.Controllers;
using ShockSprint.Managers;
using UnityEngine;

namespace ShockSprint
{
    public class EntryPoint : MonoBehaviour
    {
        void Start()
        {
            var goInputProvider = new GameObject("Keyboard Input Provider");
            var inputProvider = goInputProvider.AddComponent<KeyboardInputProvider>();

            ControllerManager.CreateController<GameController>();
            ControllerManager.CreateController<PlayerController>();
            ControllerManager.CreateController<UIController>();
            ControllerManager.CreateController<NetworkController>();
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