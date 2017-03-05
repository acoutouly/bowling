using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bowling
{
    public class ControlThreadingHelper
    {
        //This method exists in order to avoid cross-thread exceptions. Indeed, as we don't only modify models after graphic events we have to pay attention
        public static void InvokeControlAction<t>(t control, Action action) where t : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action<t, Action>(InvokeControlAction), new object[] { control, action });
            else
                action();
        }
    }
}
