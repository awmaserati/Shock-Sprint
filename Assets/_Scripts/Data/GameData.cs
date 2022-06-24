using System;

namespace ShockSprint.Data
{
    public class GameData
    {
        public enum PlayerState
        {
            Idle = 0,
            Move = 1,
            Sprint = 2,
            Untouchable = 3,
        }

        public enum GameState
        {
            PreGame = 0,
            Game = 1,
            EndGame = 2,
        }
    }
}
