using ShockSprint.Controllers;
using UnityEngine;

namespace ShockSprint.Events.Player
{
    public class PlayerMoveEvent : IControllerEventWithArgs<Vector3>
    {
        public Vector3 Direction = Vector3.zero;

        public PlayerMoveEvent(Vector3 direction)
        {
            Direction = direction;
        }

        public void Update(Vector3 direction)
        {
            Direction = direction;
        }
    }
}
