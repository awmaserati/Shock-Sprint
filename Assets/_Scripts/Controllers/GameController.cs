using System;
using ShockSprint.Data;

namespace ShockSprint.Controllers
{
    public class GameController : IController
    {
        private GameData.GameState _gameState = GameData.GameState.PreGame;

        public GameController()
        { 

        }

        public void StartGame()
        {
            _gameState = GameData.GameState.Game;
        }

        public void RestartGame()
        {
            _gameState = GameData.GameState.Game;
        }

        public void EndGame()
        {
            _gameState = GameData.GameState.EndGame;
        }

        public void Dispose()
        {
            
        }

        public void ReceiveEvent(IControllerEvent controllerEvent)
        {
            throw new NotImplementedException();
        }
    }
}
