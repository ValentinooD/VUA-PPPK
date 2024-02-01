namespace Task01
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbServer = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            lbError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 43);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Server:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 72);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 101);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // tbServer
            // 
            tbServer.Location = new Point(112, 40);
            tbServer.Name = "tbServer";
            tbServer.Size = new Size(283, 23);
            tbServer.TabIndex = 3;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(112, 69);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(283, 23);
            tbUsername.TabIndex = 4;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(112, 98);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(283, 23);
            tbPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(320, 127);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(42, 135);
            lbError.Name = "lbError";
            lbError.Size = new Size(125, 15);
            lbError.TabIndex = 7;
            lbError.Text = "Error placeholder label";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 193);
            Controls.Add(lbError);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbServer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbServer;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
        private Label lbError;
    }
}