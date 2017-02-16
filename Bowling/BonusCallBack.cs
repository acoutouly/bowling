using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public abstract class BonusCallBack
    {
        protected abstract int GetBonusRollsQuantity();
        private int bonusRollsDone = 0;
        private Frame frame;

        public BonusCallBack(Frame frame)
        {
            this.frame = frame;
        }

        public void addBonus(int knockedDownPins)
        {
            if (!isDone())
            {
                frame.Bonus += knockedDownPins;
                bonusRollsDone++;
            }
        }

        public bool isDone()
        {
            return bonusRollsDone == GetBonusRollsQuantity();
        }
    }
}
