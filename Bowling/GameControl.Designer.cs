namespace Bowling
{
    partial class GameControl
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
            this.knockedDownPinsTextBox = new System.Windows.Forms.TextBox();
            this.rollBtn = new System.Windows.Forms.Button();
            this.framesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // knockedDownPinsTextBox
            // 
            this.knockedDownPinsTextBox.Location = new System.Drawing.Point(62, 11);
            this.knockedDownPinsTextBox.Name = "knockedDownPinsTextBox";
            this.knockedDownPinsTextBox.Size = new System.Drawing.Size(44, 20);
            this.knockedDownPinsTextBox.TabIndex = 1;
            // 
            // rollBtn
            // 
            this.rollBtn.Location = new System.Drawing.Point(112, 9);
            this.rollBtn.Name = "rollBtn";
            this.rollBtn.Size = new System.Drawing.Size(75, 23);
            this.rollBtn.TabIndex = 3;
            this.rollBtn.Text = "Roll";
            this.rollBtn.UseVisualStyleBackColor = true;
            this.rollBtn.Click += new System.EventHandler(this.rollBtn_Click);
            // 
            // framesPanel
            // 
            this.framesPanel.Location = new System.Drawing.Point(62, 81);
            this.framesPanel.Name = "framesPanel";
            this.framesPanel.Size = new System.Drawing.Size(1378, 100);
            this.framesPanel.TabIndex = 4;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.gameOverLabel.Location = new System.Drawing.Point(561, 20);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(121, 24);
            this.gameOverLabel.TabIndex = 5;
            this.gameOverLabel.Text = "Game is over";
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.framesPanel);
            this.Controls.Add(this.rollBtn);
            this.Controls.Add(this.knockedDownPinsTextBox);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(1455, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox knockedDownPinsTextBox;
        private System.Windows.Forms.Button rollBtn;
        private System.Windows.Forms.FlowLayoutPanel framesPanel;
        private System.Windows.Forms.Label gameOverLabel;
    }
}
