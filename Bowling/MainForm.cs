using System;
using System.Windows.Forms;

namespace Bowling
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private Control gamesPanel;
        private ListBox followedPlayersScores;

        private void Init()
        {
            //Adds the players control
            PlayersControl playersControl = new PlayersControl();
            this.Controls.Add(playersControl);
            playersControl.Dock = DockStyle.Top;
            //listen to the player added event
            playersControl.PlayerAdded += PlayersControl_PlayerAdded;

            FlowLayoutPanel gamesPanel = new FlowLayoutPanel();
            Controls.Add(gamesPanel);
            gamesPanel.Dock = DockStyle.Fill;
            gamesPanel.AutoScroll = true;
            gamesPanel.AutoSize = true;
            gamesPanel.FlowDirection = FlowDirection.TopDown;
            gamesPanel.WrapContents = false;
            this.gamesPanel = gamesPanel;
            gamesPanel.BringToFront();

            ListBox followedPlayersScores = new ListBox();
            Controls.Add(followedPlayersScores);
            followedPlayersScores.Dock = DockStyle.Right;
            followedPlayersScores.Width = Convert.ToInt16(Width * 0.25);
            this.followedPlayersScores = followedPlayersScores;
        }

        //when ap layer is added, we add a game for this player
        private void PlayersControl_PlayerAdded(object sender, Player player)
        {
            GameControl gameControl = new GameControl(GameService.Instance.GetGameForPlayerId(player.Id), player);
            gamesPanel.Controls.Add(gameControl);
            gameControl.PlayerSubscription += GameControl_PlayerSubscription;
        }

        private void GameControl_PlayerSubscription(object sender, Tuple<Player, bool> playerAndSubscribed)
        {
            System.Action<int> action = score =>
            {
                ControlThreadingHelper.InvokeControlAction(followedPlayersScores, () =>
                {
                    followedPlayersScores.Items.Add(playerAndSubscribed.Item1.Name + " score now is " + score);
                });
            };
            if (playerAndSubscribed.Item2)
            {
                BowlingService.Instance.Subscribe(playerAndSubscribed.Item1.Id, action);
            }
            else
            {
                BowlingService.Instance.Unsubscribe(playerAndSubscribed.Item1.Id);
            }
        }
    }
}
