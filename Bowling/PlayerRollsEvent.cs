using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class PlayerRollsEvent
    {
        public int PlayerId { get; set; }
        public int NbPins { get; set; }

        public PlayerRollsEvent(int playerId, int nbPins)
        {
            PlayerId = playerId;
            NbPins = nbPins;
        }
    }
}
