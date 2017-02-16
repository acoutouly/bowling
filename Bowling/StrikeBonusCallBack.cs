using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class StrikeBonusCallBack : BonusCallBack
    {
        public StrikeBonusCallBack(Frame frame) : base(frame)
        {
        }

        protected override int GetBonusRollsQuantity()
        {
            return 2;
        }
    }
}
