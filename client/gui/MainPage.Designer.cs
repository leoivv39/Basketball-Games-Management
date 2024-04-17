namespace client
{
    partial class MainPage
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
            gamesPanel = new Panel();
            showAvailableGamesCheckbox = new CheckBox();
            logoutButton = new Button();
            SuspendLayout();
            // 
            // gamesPanel
            // 
            gamesPanel.Location = new Point(71, 41);
            gamesPanel.Name = "gamesPanel";
            gamesPanel.Size = new Size(909, 491);
            gamesPanel.TabIndex = 0;
            // 
            // showAvailableGamesCheckbox
            // 
            showAvailableGamesCheckbox.AutoSize = true;
            showAvailableGamesCheckbox.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showAvailableGamesCheckbox.Location = new Point(111, 559);
            showAvailableGamesCheckbox.Name = "showAvailableGamesCheckbox";
            showAvailableGamesCheckbox.Size = new Size(265, 29);
            showAvailableGamesCheckbox.TabIndex = 1;
            showAvailableGamesCheckbox.Text = "Show Available Games Only";
            showAvailableGamesCheckbox.UseVisualStyleBackColor = true;
            showAvailableGamesCheckbox.CheckedChanged += showAvailableGamesCheckbox_CheckedChanged;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.FromArgb(192, 0, 0);
            logoutButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutButton.ForeColor = SystemColors.Control;
            logoutButton.Location = new Point(461, 628);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(128, 62);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "LOG OUT";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1141, 702);
            Controls.Add(logoutButton);
            Controls.Add(showAvailableGamesCheckbox);
            Controls.Add(gamesPanel);
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gamesPanel;
        private CheckBox showAvailableGamesCheckbox;
        private Button logoutButton;
    }
}