namespace Bowling
{
    partial class FrameControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstShotResultTextBox = new System.Windows.Forms.TextBox();
            this.secondShotResultTextBox = new System.Windows.Forms.TextBox();
            this.sparePictureBox = new System.Windows.Forms.PictureBox();
            this.strikePictureBox = new System.Windows.Forms.PictureBox();
            this.totalAmountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sparePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strikePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // firstShotResultTextBox
            // 
            this.firstShotResultTextBox.Enabled = false;
            this.firstShotResultTextBox.Location = new System.Drawing.Point(0, 0);
            this.firstShotResultTextBox.Name = "firstShotResultTextBox";
            this.firstShotResultTextBox.ReadOnly = true;
            this.firstShotResultTextBox.Size = new System.Drawing.Size(20, 20);
            this.firstShotResultTextBox.TabIndex = 0;
            this.firstShotResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // secondShotResultTextBox
            // 
            this.secondShotResultTextBox.Enabled = false;
            this.secondShotResultTextBox.Location = new System.Drawing.Point(35, 0);
            this.secondShotResultTextBox.Name = "secondShotResultTextBox";
            this.secondShotResultTextBox.ReadOnly = true;
            this.secondShotResultTextBox.Size = new System.Drawing.Size(20, 20);
            this.secondShotResultTextBox.TabIndex = 1;
            this.secondShotResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sparePictureBox
            // 
            this.sparePictureBox.Image = global::Bowling.Properties.Resources.spare;
            this.sparePictureBox.Location = new System.Drawing.Point(35, 0);
            this.sparePictureBox.Name = "sparePictureBox";
            this.sparePictureBox.Size = new System.Drawing.Size(20, 20);
            this.sparePictureBox.TabIndex = 2;
            this.sparePictureBox.TabStop = false;
            // 
            // strikePictureBox
            // 
            this.strikePictureBox.Image = global::Bowling.Properties.Resources.strike;
            this.strikePictureBox.Location = new System.Drawing.Point(35, -1);
            this.strikePictureBox.Name = "strikePictureBox";
            this.strikePictureBox.Size = new System.Drawing.Size(20, 20);
            this.strikePictureBox.TabIndex = 3;
            this.strikePictureBox.TabStop = false;
            // 
            // totalAmountTextBox
            // 
            this.totalAmountTextBox.Enabled = false;
            this.totalAmountTextBox.Location = new System.Drawing.Point(3, 40);
            this.totalAmountTextBox.Name = "totalAmountTextBox";
            this.totalAmountTextBox.ReadOnly = true;
            this.totalAmountTextBox.Size = new System.Drawing.Size(48, 20);
            this.totalAmountTextBox.TabIndex = 4;
            this.totalAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.totalAmountTextBox);
            this.Controls.Add(this.strikePictureBox);
            this.Controls.Add(this.sparePictureBox);
            this.Controls.Add(this.secondShotResultTextBox);
            this.Controls.Add(this.firstShotResultTextBox);
            this.Name = "FrameControl";
            this.Size = new System.Drawing.Size(55, 63);
            ((System.ComponentModel.ISupportInitialize)(this.sparePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strikePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstShotResultTextBox;
        private System.Windows.Forms.TextBox secondShotResultTextBox;
        private System.Windows.Forms.PictureBox sparePictureBox;
        private System.Windows.Forms.PictureBox strikePictureBox;
        private System.Windows.Forms.TextBox totalAmountTextBox;
    }
}
