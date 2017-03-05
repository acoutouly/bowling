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
            this.playerLabel = new System.Windows.Forms.Label();
            this.subscriptionBtn = new System.Windows.Forms.Button();
            this.restartGameBtn = new System.Windows.Forms.Button();
            this.unsubscriptionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // knockedDownPinsTextBox
            // 
            this.knockedDownPinsTextBox.Location = new System.Drawing.Point(211, 20);
            this.knockedDownPinsTextBox.Name = "knockedDownPinsTextBox";
            this.knockedDownPinsTextBox.Size = new System.Drawing.Size(44, 20);
            this.knockedDownPinsTextBox.TabIndex = 1;
            // 
            // rollBtn
            // 
            this.rollBtn.Location = new System.Drawing.Point(261, 18);
            this.rollBtn.Name = "rollBtn";
            this.rollBtn.Size = new System.Drawing.Size(75, 23);
            this.rollBtn.TabIndex = 3;
            this.rollBtn.Text = "Roll";
            this.rollBtn.UseVisualStyleBackColor = true;
            this.rollBtn.Click += new System.EventHandler(this.rollBtn_Click);
            // 
            // framesPanel
            // 
            this.framesPanel.Location = new System.Drawing.Point(62, 60);
            this.framesPanel.Name = "framesPanel";
            this.framesPanel.Size = new System.Drawing.Size(1378, 100);
            this.framesPanel.TabIndex = 4;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.gameOverLabel.Location = new System.Drawing.Point(561, 27);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(121, 24);
            this.gameOverLabel.TabIndex = 5;
            this.gameOverLabel.Text = "Game is over";
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(71, 23);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(35, 13);
            this.playerLabel.TabIndex = 6;
            this.playerLabel.Text = "label1";
            // 
            // subscriptionBtn
            // 
            this.subscriptionBtn.Location = new System.Drawing.Point(783, 16);
            this.subscriptionBtn.Name = "subscriptionBtn";
            this.subscriptionBtn.Size = new System.Drawing.Size(75, 23);
            this.subscriptionBtn.TabIndex = 7;
            this.subscriptionBtn.Text = "Subscribe";
            this.subscriptionBtn.UseVisualStyleBackColor = true;
            this.subscriptionBtn.Click += new System.EventHandler(this.subscriptionBtn_Click);
            // 
            // restartGameBtn
            // 
            this.restartGameBtn.Location = new System.Drawing.Point(565, 3);
            this.restartGameBtn.Name = "restartGameBtn";
            this.restartGameBtn.Size = new System.Drawing.Size(113, 23);
            this.restartGameBtn.TabIndex = 8;
            this.restartGameBtn.Text = "Restart Game";
            this.restartGameBtn.UseVisualStyleBackColor = true;
            this.restartGameBtn.Click += new System.EventHandler(this.restartGameBtn_Click);
            // 
            // unsubscriptionBtn
            // 
            this.unsubscriptionBtn.Location = new System.Drawing.Point(864, 16);
            this.unsubscriptionBtn.Name = "unsubscriptionBtn";
            this.unsubscriptionBtn.Size = new System.Drawing.Size(75, 23);
            this.unsubscriptionBtn.TabIndex = 7;
            this.unsubscriptionBtn.Text = "Unsubscribe";
            this.unsubscriptionBtn.UseVisualStyleBackColor = true;
            this.unsubscriptionBtn.Click += new System.EventHandler(this.unsubscriptionBtn_Click);
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.restartGameBtn);
            this.Controls.Add(this.unsubscriptionBtn);
            this.Controls.Add(this.subscriptionBtn);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.framesPanel);
            this.Controls.Add(this.rollBtn);
            this.Controls.Add(this.knockedDownPinsTextBox);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(1455, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox knockedDownPinsTextBox;
        private System.Windows.Forms.Button rollBtn;
        private System.Windows.Forms.FlowLayoutPanel framesPanel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Button subscriptionBtn;
        private System.Windows.Forms.Button restartGameBtn;
        private System.Windows.Forms.Button unsubscriptionBtn;
    }
}
