using ShockSprint.Controllers;
using ShockSprint.Managers;
using UnityEngine;
using UnityEngine.UI;
using ShockSprint.Events;

namespace ShockSprint.Views
{
    public class UIView : MonoBehaviour
    {
        private Button _button = null;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            ControllerManager.DispatchEvent<NetworkController>(ControllerEventPool.CreateEvent<StartHostGameEvent>());
        }
    }
}
