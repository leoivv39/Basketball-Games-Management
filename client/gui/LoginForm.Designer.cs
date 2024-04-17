namespace client
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            loginButton = new Button();
            label2 = new Label();
            passwordField = new TextBox();
            label1 = new Label();
            usernameField = new TextBox();
            Login = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(loginButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(passwordField);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(usernameField);
            panel1.Controls.Add(Login);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.Highlight;
            loginButton.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButton.ForeColor = SystemColors.ButtonHighlight;
            loginButton.Location = new Point(354, 302);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(112, 59);
            loginButton.TabIndex = 5;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(257, 209);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // passwordField
            // 
            passwordField.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordField.ForeColor = SystemColors.InfoText;
            passwordField.Location = new Point(367, 211);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(221, 29);
            passwordField.TabIndex = 3;
            passwordField.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(257, 161);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // usernameField
            // 
            usernameField.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameField.Location = new Point(367, 158);
            usernameField.Name = "usernameField";
            usernameField.Size = new Size(221, 29);
            usernameField.TabIndex = 1;
            // 
            // Login
            // 
            Login.AutoSize = true;
            Login.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Login.ForeColor = Color.FromArgb(64, 0, 64);
            Login.Location = new Point(228, 51);
            Login.Name = "Login";
            Login.Size = new Size(408, 42);
            Login.TabIndex = 0;
            Login.Text = "Log in to your account";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Login;
        private Label label1;
        private TextBox usernameField;
        private TextBox passwordField;
        private Label label2;
        private Button loginButton;
    }
}
