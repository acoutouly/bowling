using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingService
    {

        private static readonly BowlingService instance = new BowlingService();
        public static BowlingService Instance
        {
            get { return instance; }
        }

        private Thread eventsThread;
        private BowlingService()
        {
            eventsThread = new Thread(processEvents);
            eventsThread.Name = "Events Processor Thread";
            eventsThread.IsBackground = true;
            eventsThread.Start();
        }

        private void processEvents()
        {
            //would be good replacing true by a variable and give possibility to kill the thread
            while (true)
            {
                try
                {
                    PlayerRollsEvent playerRollsEvent = rollEventsQueue.Take();
                    if (playerRollsEvent != null)
                    {

                        Game game = GameService.Instance.GetGameForPlayerId(playerRollsEvent.PlayerId);
                        if (game == null)
                        {
                            throw new Exception("Trying to roll with null game. PlayerId=" + playerRollsEvent.PlayerId);
                        }
                        Action<int> action;
                        //only if we have a listener on the thread we execute the callback
                        if (playerIdsToListener.TryGetValue(playerRollsEvent.PlayerId, out action))
                        {
                            action(game.score());
                        }
                    }
                }
                //Here we don't want this thread to stop, we prefer to log the error
                catch (Exception e)
                {
                    Console.WriteLine("Error while dealing with roll event", e);
                }
            }
        }

        //contains the callback for each player
        private Dictionary<int, Action<int>> playerIdsToListener = new Dictionary<int, Action<int>>();
        //blocking colelction, take method is blocking, aboid the thread iterating all the time
        private BlockingCollection<PlayerRollsEvent> rollEventsQueue = new BlockingCollection<PlayerRollsEvent>();

        //Add player
        public Player AddPlayer(string playerName)
        {
            int playerId = PlayerService.Instance.AddPlayer(playerName);
            //also starts a game for this player
            GameService.Instance.StartGameForPlayer(playerId);
            return PlayerService.Instance.GetPlayerById(playerId);
        }

        //Subscribe to a player roll event
        public void Subscribe(int playerId, Action<int> scoreUpdateCallback)
        {
            playerIdsToListener[playerId] = scoreUpdateCallback;
        }

        public void Unsubscribe(int playerId)
        {
            playerIdsToListener.Remove(playerId);
        }

        //When a player has just rolled a ball
        /*Here I kept the game.roll method here cause from my understanding,
         * as it doesn't cost much we can keep it here.
         * What we don't want is having the callback executed here, cause we can suppose
         * the callback execution costs a lot, that's why we prefer it to occur in another thread
         */
        public void OnRoll(int playerId, int pins)
        {
            Game game = GameService.Instance.GetGameForPlayerId(playerId);
            if (game == null)
            {
                throw new Exception("Trying to roll with null game. PlayerId=" + playerId);
            }
            game.roll(pins);
            //adds an event that is handled by another thread
            rollEventsQueue.Add(new Bowling.PlayerRollsEvent(playerId, pins));
        }
    }
}
