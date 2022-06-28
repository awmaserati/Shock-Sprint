using ShockSprint.Events;
using ShockSprint.Data;

namespace ShockSprint.Controllers
{
    public class GameController : IController
    {
        public GameData.GameState GameState { get; private set; }

        public GameController()
        {
            GameState = GameData.GameState.PreGame;
        }

        public void StartGame()
        {
            GameState = GameData.GameState.Game;
        }

        public void RestartGame()
        {
            GameState = GameData.GameState.Game;
        }

        public void EndGame()
        {
            GameState = GameData.GameState.EndGame;
        }

        public void Dispose()
        {
            
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            if (controllerEvent.GetType() == typeof(GameStartEvent))
            {
                StartGame();
            }
        }
    }
}
