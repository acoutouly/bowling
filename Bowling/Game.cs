using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game : INotifyPropertyChanged
    {
        private static readonly int FRAMES_QUANTITY = 10;

        //Constains the frames for the game
        private List<Frame> _frames = new List<Frame>();
        public List<Frame> frames
        {
            get
            {
                return _frames;
            }
            private set { _frames = value; }
        }

        //Index of the current frame, start with first frame, so 0
        private int currentFrameIndex = 0;

        //Bonus callbacks in case of strike or spare
        private List<BonusCallBack> bonusCallBacks = new List<BonusCallBack>();

        //We instantiate the game with all the frames
        public Game()
        { 
            for (int i = 1; i <= FRAMES_QUANTITY; i++)
            {
                Frame frame = new Frame(this, i);
                if (i == FRAMES_QUANTITY)
                {
                    frame.Last = true;
                }
                frames.Add(frame);
            }
        }

        //Called everytime the player rolls a ball
        public void roll(int knockedDownPins)
        {
            //The player should not throw a ball if the game is over
            if (Over)
            {
                throw new Exception("Game is over");
            }

            Frame currentFrame = currentFrameIndex < FRAMES_QUANTITY ? frames[currentFrameIndex] : null;
            //We get a bonus callback (or null)
            BonusCallBack bonusCallBack = currentFrame != null ? currentFrame.roll(knockedDownPins) : null;

            //We feed all the callbacks
            //We put this after the frame.roll call (if any) to make sure the move is valid, if not, frame.roll throws an exception and this is not called
            for (int i = bonusCallBacks.Count - 1; i >= 0; i--)
            {
                BonusCallBack bcbk = bonusCallBacks[i];
                //we feed the callback with the bonus
                if (knockedDownPins <= Frame.MAX_PINS_ON_TRACK)
                {
                    bcbk.addBonus(knockedDownPins);
                    //Each callback expects a certain quantity of additional shots, when they are done, the isDone(à method of the callback return true
                    if (bcbk.isDone())
                    {
                        //We remove the callback (in order to not keep it in the list for nothing, even if the addBonus method would not do anything anymore)
                        bonusCallBacks.RemoveAt(i);
                    }
                }
                else
                {
                    throw new Exception("Cannot knock down more than " + Frame.MAX_PINS_ON_TRACK + " pins");
                }
            }

            //if bonus callback is not null (strike or spare) we add it to the list
            if (bonusCallBack != null)
            {
                bonusCallBacks.Add(bonusCallBack);
            }
            //if we have played all shots for the frame, we go to the next one
            if (currentFrame != null && currentFrame.IsDone())
            {
                currentFrameIndex++;
            }
            Over = isOver();
        }

        //Return the total score of the game
        public int score()
        {
            return frames.Sum(f => f.Score);
        }

        //over property
        private bool over;
        public bool Over
        {
            get
            {
                return over;
            }
            set
            {
                over = value;
                OnPropertyChanged();
            }
        }
        //Returns true if the game is over <=> all the frames have been 10played and the additional shots too
        private bool isOver()
        {
            return currentFrameIndex == FRAMES_QUANTITY && frames[FRAMES_QUANTITY - 1].IsDone() && bonusCallBacks.Count == 0;
        }

        public void Restart()
        {
            currentFrameIndex = 0;
            bonusCallBacks.Clear();
            foreach (Frame frame in frames)
            {
                frame.reset();
            }
            Over = false;
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(
        [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
