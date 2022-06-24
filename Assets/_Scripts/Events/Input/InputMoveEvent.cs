using ShockSprint.Controllers;

namespace ShockSprint.Events
{
    public class InputMoveEvent : IControllerEventWithArgs<float>
    {
        public float Value { get; private set; }

        public InputMoveEvent(float value)
        {
            Value = value;
        }

        public void Update(float value)
        {
            Value = value;
        }
    }
}
