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
    public partial class FrameControl : UserControl
    {
        private Frame frame;

        //for last frame only
        private bool needAdditionalShots;
        private List<Control> additionalTextBoxes;

        public FrameControl(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            Init();
        }

        private void Init()
        {
            //First shot bindings
            Binding firstShotValueBinding = new Binding("Text", frame, "FirstOpportunityResult");
            firstShotValueBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            firstShotValueBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            firstShotResultTextBox.DataBindings.Add(firstShotValueBinding);

            Binding firstShotVisibilityBinding = new Binding("Visible", frame, "Strike");
            firstShotVisibilityBinding.Format += (sender, args) => args.Value = (bool)args.Value != true;
            firstShotVisibilityBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            firstShotVisibilityBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            firstShotResultTextBox.DataBindings.Add(firstShotVisibilityBinding);

            //Spare box bindings
            Binding sparePictureBoxVisibilityBinding = new Binding("Visible", frame, "Spare");
            sparePictureBoxVisibilityBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            sparePictureBoxVisibilityBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            sparePictureBox.DataBindings.Add(sparePictureBoxVisibilityBinding);

            //Strike box bindings
            Binding strikePictureBoxVisibilityBinding = new Binding("Visible", frame, "Strike");
            strikePictureBoxVisibilityBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            strikePictureBoxVisibilityBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            strikePictureBox.DataBindings.Add(strikePictureBoxVisibilityBinding);

            //Second shot bindings
            Binding secondShotValueBinding = new Binding("Text", frame, "SecondOpportunityResult");
            secondShotValueBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            secondShotValueBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            secondShotResultTextBox.DataBindings.Add(secondShotValueBinding);

            Binding secondShotVisibilityBinding = new Binding("Visible", sparePictureBox, "Visible");
            secondShotVisibilityBinding.Format += (sender, args) => args.Value = (bool)args.Value != true;
            secondShotVisibilityBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            secondShotVisibilityBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            secondShotResultTextBox.DataBindings.Add(secondShotVisibilityBinding);

            //Total amount binding
            Binding totalAmountValueBinding = new Binding("Text", frame, "AggregatedAmount");
            totalAmountValueBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            totalAmountValueBinding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            totalAmountTextBox.DataBindings.Add(totalAmountValueBinding);

            //Last frame case
            if (frame.Last)
            {
                //there might be additional shots
                additionalTextBoxes = new List<Control>();
                Frame.ScoreChanged += Frame_ScoreChanged;
                frame.BonusChanges += Frame_BonusChanges;    
            }
        }

        private void Frame_ScoreChanged(object sender, int e)
        {
            //if it's the last frame whose score is updated and if we have not already provided the additional textboxes
            if (e == frame.Position && !needAdditionalShots)
            {
                int nbCasesToAdd = 0;
                if (frame.Spare)
                {
                    nbCasesToAdd = 1;
                }
                else if (frame.Strike)
                {
                    nbCasesToAdd = 2;
                }
                for (int i = 1; i <= nbCasesToAdd; i++)
                {
                    additionalTextBoxes.Add(addAdditionalCase());
                }
                if (nbCasesToAdd > 0)
                {
                    needAdditionalShots = true;
                }
            }
        }

        private void Frame_BonusChanges(object sender, Tuple<int, int> e)
        {
            if (additionalTextBoxes.Count == 0)
            {
                throw new Exception("No boxes is provided to receive the bonus value");
            }
            additionalTextBoxes[0].Text = (e.Item2 - e.Item1).ToString();
            additionalTextBoxes.RemoveAt(0);
        }

        private Control addAdditionalCase()
        {
            int additionalWidth = 25;
            this.Width += additionalWidth;
            Control additionalTextBox = GetAdditionalTextBox();
            this.Controls.Add(additionalTextBox);
            //vertical align with other boxes
            additionalTextBox.Top = firstShotResultTextBox.Top;
            additionalTextBox.Left = this.Width - additionalWidth + 5;
            return additionalTextBox;
        }

        private Control GetAdditionalTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Width = 20;
            textBox.Height = 20;
            textBox.Enabled = false;
            textBox.ReadOnly = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            return textBox;
        }
    }
}
