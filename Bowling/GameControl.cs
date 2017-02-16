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
    public partial class GameControl : UserControl
    {
        private Game game;

        public GameControl(Game game)
        {
            InitializeComponent();
            this.game = game;
            Init();
        }

        private void Init()
        {
            Binding knockedDownPinsTextBoxBinding = new Binding("Visible", game, "Over");
            knockedDownPinsTextBoxBinding.Format += (sender, args) => args.Value = (bool)args.Value != true;
            knockedDownPinsTextBoxBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            knockedDownPinsTextBoxBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            knockedDownPinsTextBox.DataBindings.Add(knockedDownPinsTextBoxBinding);

            Binding rollBtnBinding = new Binding("Visible", game, "Over");
            rollBtnBinding.Format += (sender, args) => args.Value = (bool)args.Value != true;
            rollBtnBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            rollBtnBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            rollBtn.DataBindings.Add(rollBtnBinding);

            Binding visibleWhenGameIsOverBinding = new Binding("Visible", game, "Over");
            visibleWhenGameIsOverBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            visibleWhenGameIsOverBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            gameOverLabel.DataBindings.Add(visibleWhenGameIsOverBinding);

            foreach (Frame frame in game.frames)
            {
                framesPanel.Controls.Add(new FrameControl(frame));
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
                game.roll(Convert.ToInt16(knockedDownPinsTextBox.Text));
                knockedDownPinsTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            knockedDownPinsTextBox.Focus();
        }
    }
}
