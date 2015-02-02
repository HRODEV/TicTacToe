namespace TicTacToe.Winforms
{
    partial class GameStartScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HasBot = new System.Windows.Forms.CheckBox();
            this.comboBoxBotNames = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HasBot
            // 
            this.HasBot.AutoSize = true;
            this.HasBot.Location = new System.Drawing.Point(136, 36);
            this.HasBot.Name = "HasBot";
            this.HasBot.Size = new System.Drawing.Size(42, 17);
            this.HasBot.TabIndex = 0;
            this.HasBot.Text = "Bot";
            this.HasBot.UseVisualStyleBackColor = true;
            this.HasBot.CheckedChanged += new System.EventHandler(this.HasBot_CheckedChanged);
            // 
            // comboBoxBotNames
            // 
            this.comboBoxBotNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBotNames.Enabled = false;
            this.comboBoxBotNames.FormattingEnabled = true;
            this.comboBoxBotNames.Location = new System.Drawing.Point(220, 34);
            this.comboBoxBotNames.Name = "comboBoxBotNames";
            this.comboBoxBotNames.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBotNames.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(220, 189);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "start game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GameStartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 258);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.comboBoxBotNames);
            this.Controls.Add(this.HasBot);
            this.Name = "GameStartScreen";
            this.Text = "GameStartScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox HasBot;
        private System.Windows.Forms.ComboBox comboBoxBotNames;
        private System.Windows.Forms.Button startButton;
    }
}