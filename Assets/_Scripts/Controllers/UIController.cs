﻿using ShockSprint.Events;
using ShockSprint.Views.Game;

namespace ShockSprint.Controllers
{
    public class UIController : IController
    {
        //UIView view;

        public UIController()
        {
            //view = UnityEngine.Object.FindObjectOfType<UIView>();
        }

        public void Dispose()
        {
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            
        }
    }
}