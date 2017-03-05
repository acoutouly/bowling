using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class GameService
    {
        private static readonly GameService instance = new GameService();
        public static GameService Instance
        {
            get { return instance; }
        }

        private Dictionary<int, Game> playerIdToGame = new Dictionary<int, Game>();
        
        public void StartGameForPlayer(int playerId)
        {
            Game game = new Bowling.Game();
            playerIdToGame.Add(playerId, game);
        }

        public Game GetGameForPlayerId(int playerId)
        {
            Game game;
            if (playerIdToGame.TryGetValue(playerId, out game))
            {
                return game;
            }
            return null;
        }
    }
}
