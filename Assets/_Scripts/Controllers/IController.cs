namespace ShockSprint.Controllers
{
    public interface IController : IDisposableManaged
    {
        void ReceiveEvent(IControllerEvent controllerEvent);
    }
}