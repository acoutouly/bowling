using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bowling
{
    public partial class MainForm : Form
    {
        private GameControl gameControl;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gameControl = new GameControl(new Bowling.Game());
            
            this.Controls.Add(gameControl);
            gameControl.Dock = DockStyle.Fill;
            //To not be hidden by top panel
            gameControl.BringToFront();
        }

        private void restartGameBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(gameControl);
            Init();
        }
    }
}
