using ShockSprint.Controllers;

namespace ShockSprint.Events
{
    public class InputRotateEvent : IControllerEventWithArgs<float>
    {
        public float Value { get; private set; }

        public InputRotateEvent(float value)
        {
            Value = value;
        }

        public void Update(float value)
        {
            Value = value;
        }
    }
}
