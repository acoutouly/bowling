using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    //Implements INotifyPropertyChanged for binding with FrameControl
    public class Frame : INotifyPropertyChanged
    {
        public static int MAX_PINS_ON_TRACK = 10;

        public bool Last { get;  set;}

        //Stores the amount of this frames and the ones with smaller position
        private int? aggregatedAmount;
        public int? AggregatedAmount
        {
            get
            {
                return aggregatedAmount;
            }
            set
            {
                aggregatedAmount = value;
                OnPropertyChanged();
            }
        }

        //this will store the first shot result and is null as long as the player didn't roll the first ball
        private int? firstOpportunityResult = null;
        public int? FirstOpportunityResult
        {
            get
            {
                return firstOpportunityResult;
            }
            private set
            {
                firstOpportunityResult = value;
                OnPropertyChanged();
                OnScoreChanged();
            }
        }

        //this will store the second shot result and is null as long as the player didn't roll the second ball
        private int? secondOpportunityResult = null;
        public int? SecondOpportunityResult
        {
            get
            {
                return secondOpportunityResult;
            }
            private set
            {
                secondOpportunityResult = value;
                OnPropertyChanged();
                OnScoreChanged();
            }
        }

        //This will store the additional points in case of spare or strike
        private int? bonus = null;
        public int Bonus
        {
            get
            {
                return bonus == null ? 0 : bonus.Value;
            }
            set
            {
                OnBonusChanges(bonus, value);
                bonus = value;
                OnScoreChanged();
            }
        }

        //Frame position among the list of 10 frames
        public int Position { get; set; }
        private Game game;
        
        public Frame(Game game, int position)
        {
            this.game = game;
            Position = position;
            Frame.ScoreChanged += Frame_ScoreChanged;
        }

        //Return a bonus callback if needed (spare, strike), null otherwise
        public BonusCallBack roll(int knockedDownPins)
        {
            //Cannot knock down more than 10 pins
            if (knockedDownPins > MAX_PINS_ON_TRACK)
            {
                throw new Exception("Cannot knock down more than " + MAX_PINS_ON_TRACK + " pins");
            }
            //Only two shots per frame
            if (secondOpportunityResult != null)
            {
                throw new Exception("Cannot roll more than 2 times per frame");
            }
            if (firstOpportunityResult == null)
            {
                FirstOpportunityResult = knockedDownPins;
                if (Strike)
                {
                    return new StrikeBonusCallBack(this);
                }
            }
            else if (secondOpportunityResult == null)
            {
                if (firstOpportunityResult + knockedDownPins > MAX_PINS_ON_TRACK)
                {
                    throw new Exception("Cannot knock down more than " + MAX_PINS_ON_TRACK + " pins");
                }
                SecondOpportunityResult = knockedDownPins;
                if (Spare)
                {
                    return new SpareBonusCallBack(this);
                }
            }
            return null;
        }

        //Returns if a strike was made in this frame <=> if all pins were knocked down at first try
        public bool Strike
        {
            get
            {
                return firstOpportunityResult == MAX_PINS_ON_TRACK;
            }
        }

        //Returns if a spare was made in this frame <=> if all pins were knocked down after two tries
        public bool Spare
        {
            get
            {
                return firstOpportunityResult + secondOpportunityResult == MAX_PINS_ON_TRACK;
            }
        }

        //Tells if all shots have been made for the frame <=> strike or two shots (we don't incluse bonus shots in this)
        public bool IsDone()
        {
            return Strike || secondOpportunityResult != null;
        }

        //Returns the score for this frame <=> number of knocked down pins + bonuses
        public int Score
        {
            get
            {
                return (FirstOpportunityResult == null ? 0 : FirstOpportunityResult.Value) + (SecondOpportunityResult == null ? 0 : SecondOpportunityResult.Value) + Bonus;
            }            
        }

        /////EVENTS PART

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

        //Notifies that the bonus has changed
        public event EventHandler<Tuple<int, int>> BonusChanges;
        protected virtual void OnBonusChanges(int? formerValue, int newValue)
        {
            BonusChanges?.Invoke(this, new Tuple<int, int>(formerValue == null ? 0 : formerValue.Value, newValue));
        }

        //Notifies the control but also other frames for update total amount
        public static event EventHandler<int> ScoreChanged;
        protected virtual void OnScoreChanged()
        {
            OnPropertyChanged("Score");
            ScoreChanged?.Invoke(this, this.Position);
        }

        //When a frame score change, if this frame is before this one, then the total amount of the frame after is changed
        private void Frame_ScoreChanged(object sender, int e)
        {
            if (e <= this.Position)
            {
                //In order to not show the aggregated amount on frame that have not been played yet
                if (FirstOpportunityResult != null)
                {
                    AggregatedAmount = game.frames.FindAll(f => f.Position <= this.Position).Sum(f => f.Score);
                }
            }
        }
    }
}
