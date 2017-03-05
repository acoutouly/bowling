using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class PlayerService
    {
        private static readonly PlayerService instance = new PlayerService();
        public static PlayerService Instance
        {
            get { return instance; }
        }

        private int id = 1;
        private Dictionary<int, Player> idToPlayer = new Dictionary<int, Player>();
        private Object locker = new Object();

        public int AddPlayer(string playerName)
        {
            Player player = new Bowling.Player();
            player.Name = playerName;
            lock(locker)
            {
                player.Id = id;
                id++;
            }
            idToPlayer.Add(player.Id, player);
            return player.Id;
        }

        public Player GetPlayerById(int playerId)
        {
            Player result;
            if (idToPlayer.TryGetValue(playerId, out result))
            {
                return result;
            }
            return null;
        }
    }
}
