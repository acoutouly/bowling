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
        private List<Control> additionalTextBoxesTofill;
        private List<Control> additionalTextBoxesFilled;
        private static int additionalWidthPerAdditionalBox = 25;

        public FrameControl(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            Init();
        }

        private void Init()
        {
            frame.PropertyChanged += Frame_PropertyChanged;
            strikePictureBox.Visible = false;
            sparePictureBox.Visible = false;

            //Last frame case
            if (frame.Last)
            {
                //there might be additional shots
                additionalTextBoxesFilled = new List<Control>();
                additionalTextBoxesTofill = new List<Control>();
                Frame.ScoreChanged += Frame_ScoreChanged;
                frame.BonusChanges += Frame_BonusChanges;    
            }
        }

        //Binding is now different, I integrated the ControlThreadingHelper that avoid cross-thread exception
        private void Frame_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FirstOpportunityResult"))
            {
                ControlThreadingHelper.InvokeControlAction(firstShotResultTextBox, () =>
                {
                    firstShotResultTextBox.Text = frame.FirstOpportunityResult.ToString();
                });
                ControlThreadingHelper.InvokeControlAction(firstShotResultTextBox, () =>
                {
                    firstShotResultTextBox.Visible = !frame.Strike;
                });
                ControlThreadingHelper.InvokeControlAction(strikePictureBox, () =>
                {
                    strikePictureBox.Visible = frame.Strike;
                });
            }
            else if (e.PropertyName.Equals("SecondOpportunityResult"))
            {
                ControlThreadingHelper.InvokeControlAction(secondShotResultTextBox, () =>
                {
                    secondShotResultTextBox.Text = frame.SecondOpportunityResult.ToString();
                });
                ControlThreadingHelper.InvokeControlAction(sparePictureBox, () =>
                {
                    sparePictureBox.Visible = frame.Spare;
                });
                ControlThreadingHelper.InvokeControlAction(secondShotResultTextBox, () =>
                {
                    secondShotResultTextBox.Visible = !frame.Spare;
                });
            }
            else if (e.PropertyName.Equals("AggregatedAmount"))
            {
                ControlThreadingHelper.InvokeControlAction(totalAmountTextBox, () =>
                {
                    totalAmountTextBox.Text = frame.AggregatedAmount.ToString();
                });
            }
        }
        

        private void Frame_ScoreChanged(object sender, int e)
        {
            //if it's the last frame whose score is updated and if we have not already provided the additional textboxes
            if (e == frame.Position && (!needAdditionalShots || frame.FirstOpportunityResult == null))
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

                if (nbCasesToAdd == 0)
                {
                    foreach (Control additionalBox in additionalTextBoxesFilled)
                    {
                        ControlThreadingHelper.InvokeControlAction(this, () =>
                        {
                            Controls.Remove(additionalBox);
                            Width -= additionalWidthPerAdditionalBox;
                        });
                    }
                    additionalTextBoxesFilled.Clear();
                    needAdditionalShots = false;
                }

                else
                {
                    for (int i = 1; i <= nbCasesToAdd; i++)
                    {
                        additionalTextBoxesTofill.Add(addAdditionalCase());
                    }
                    if (nbCasesToAdd > 0)
                    {
                        needAdditionalShots = true;
                    }
                }
            }
        }

        private void Frame_BonusChanges(object sender, Tuple<int, int> e)
        {
            if (e.Item2 != 0)
            {
                if (additionalTextBoxesTofill.Count == 0)
                {
                    throw new Exception("No boxes is provided to receive the bonus value");
                }
                ControlThreadingHelper.InvokeControlAction(additionalTextBoxesTofill[0], () =>
                {
                    additionalTextBoxesTofill[0].Text = (e.Item2 - e.Item1).ToString();
                });

                additionalTextBoxesFilled.Add(additionalTextBoxesTofill[0]);
                additionalTextBoxesTofill.RemoveAt(0);
            }
        }

        private Control addAdditionalCase()
        {
            Control additionalTextBox = GetAdditionalTextBox();
            
            ControlThreadingHelper.InvokeControlAction(this, () =>
            {
                this.Width += additionalWidthPerAdditionalBox;
                this.Controls.Add(additionalTextBox);
                //vertical align with other boxes
                additionalTextBox.Top = firstShotResultTextBox.Top;
                additionalTextBox.Left = this.Width - additionalWidthPerAdditionalBox + 5;
            });          
            
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
