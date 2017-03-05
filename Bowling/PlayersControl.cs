using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bowling
{
    public partial class PlayersControl : UserControl
    {

        public PlayersControl()
        {
            InitializeComponent();
        }

        private void addPlayerBtn_Click(object sender, EventArgs e)
        {
            string playerName = playerNameTextBox.Text;
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Cannot add a player with null or empty name");
                return;
            }
            Player player = BowlingService.Instance.AddPlayer(playerName);
            OnPlayerAdded(player);
            playerNameTextBox.Clear();
        }

        //Notifies that a player was added
        public event EventHandler<Player> PlayerAdded;
        protected virtual void OnPlayerAdded(Player player)
        {
            PlayerAdded?.Invoke(this, player);
        }
    }
}
