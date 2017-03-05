using System;
using System.Windows.Forms;

namespace Bowling
{
    public partial class GameControl : UserControl
    {
        private Game game;
        private Player player;

        public GameControl(Game game, Player player)
        {
            InitializeComponent();
            this.game = game;
            this.player = player;
            Init();
        }

        private void Init()
        {
            playerLabel.Text = player.Name;
            gameOverLabel.Visible = false;
            game.PropertyChanged += Game_PropertyChanged;
            unsubscriptionBtn.Visible = false;

            foreach (Frame frame in game.frames)
            {
                framesPanel.Controls.Add(new FrameControl(frame));
            }
        }

        private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Over"))
            {
                ControlThreadingHelper.InvokeControlAction(knockedDownPinsTextBox, () =>
                {
                    knockedDownPinsTextBox.Visible = !game.Over;
                });
                ControlThreadingHelper.InvokeControlAction(rollBtn, () =>
                {
                    rollBtn.Visible = !game.Over;
                });
                ControlThreadingHelper.InvokeControlAction(gameOverLabel, () =>
                {
                    gameOverLabel.Visible = game.Over;
                });
            }
        }

        private void rollBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 knockedDownPins;
                if (!Int16.TryParse(knockedDownPinsTextBox.Text, out knockedDownPins))
                {
                    MessageBox.Show("Only integers are valid values", "Error");
                    return;
                }
                try
                {
                    BowlingService.Instance.OnRoll(player.Id, knockedDownPins);
                    knockedDownPinsTextBox.Clear();
                }
                catch (Exception ex)
                {
                    knockedDownPinsTextBox.SelectAll();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            knockedDownPinsTextBox.Focus();
        }

        public event EventHandler<Tuple<Player, bool>> PlayerSubscription;
        protected virtual void OnPlayerSubscription(Player player, bool subscribed)
        {
            PlayerSubscription?.Invoke(this, new Tuple<Player, bool>(player, subscribed));
        }

        private void subscriptionBtn_Click(object sender, EventArgs e)
        {
            OnPlayerSubscription(player,true);
            subscriptionBtn.Visible = false;
            unsubscriptionBtn.Visible = true;
        }

        private void restartGameBtn_Click(object sender, EventArgs e)
        {
            this.game.Restart();
        }

        private void unsubscriptionBtn_Click(object sender, EventArgs e)
        {
            OnPlayerSubscription(player, false);
            subscriptionBtn.Visible = true;
            unsubscriptionBtn.Visible = false;
        }
    }
}
