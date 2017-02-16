using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class SpareBonusCallBack : BonusCallBack
    {
        public SpareBonusCallBack(Frame frame) : base(frame)
        {
        }

        protected override int GetBonusRollsQuantity()
        {
            return 1;
        }
    }
}
