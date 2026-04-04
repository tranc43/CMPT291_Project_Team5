namespace MovieRental_Team5
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpGettingStartedToolStripMenuItem = new ToolStripMenuItem();
            helpLoginToolStripMenuItem = new ToolStripMenuItem();
            helpAboutToolStripMenuItem = new ToolStripMenuItem();
            Title = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Email_SIN_Label = new Label();
            EmailField = new TextBox();
            PasswordLabel = new Label();
            PasswordField = new TextBox();
            LoginButton = new Button();
            label2 = new Label();
            Exit_Application = new Button();
            CustomerPortalButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(967, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpGettingStartedToolStripMenuItem, helpLoginToolStripMenuItem, helpAboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpGettingStartedToolStripMenuItem
            // 
            helpGettingStartedToolStripMenuItem.Name = "helpGettingStartedToolStripMenuItem";
            helpGettingStartedToolStripMenuItem.Size = new Size(153, 22);
            helpGettingStartedToolStripMenuItem.Text = "Getting Started";
            helpGettingStartedToolStripMenuItem.Click += helpGettingStartedToolStripMenuItem_Click;
            // 
            // helpLoginToolStripMenuItem
            // 
            helpLoginToolStripMenuItem.Name = "helpLoginToolStripMenuItem";
            helpLoginToolStripMenuItem.Size = new Size(153, 22);
            helpLoginToolStripMenuItem.Text = "Login Screen";
            helpLoginToolStripMenuItem.Click += helpLoginToolStripMenuItem_Click;
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.Size = new Size(153, 22);
            helpAboutToolStripMenuItem.Text = "About";
            helpAboutToolStripMenuItem.Click += helpAboutToolStripMenuItem_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            Title.Location = new Point(294, 36);
            Title.Name = "Title";
            Title.Size = new Size(415, 54);
            Title.TabIndex = 0;
            Title.Text = "Movie Rental Project";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Email_SIN_Label
            // 
            Email_SIN_Label.AutoSize = true;
            Email_SIN_Label.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Email_SIN_Label.Location = new Point(232, 162);
            Email_SIN_Label.Name = "Email_SIN_Label";
            Email_SIN_Label.Size = new Size(182, 37);
            Email_SIN_Label.TabIndex = 2;
            Email_SIN_Label.Text = "Employee SIN";
            // 
            // EmailField
            // 
            EmailField.Font = new Font("Segoe UI", 10F);
            EmailField.Location = new Point(420, 175);
            EmailField.Name = "EmailField";
            EmailField.PlaceholderText = "Enter Employee SIN";
            EmailField.Size = new Size(185, 25);
            EmailField.TabIndex = 4;
            EmailField.Click += EmailAddressInput;
            EmailField.TextChanged += EmailAddressInput;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(264, 217);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(128, 37);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Password";
            // 
            // PasswordField
            // 
            PasswordField.Font = new Font("Segoe UI", 10F);
            PasswordField.Location = new Point(420, 229);
            PasswordField.Name = "PasswordField";
            PasswordField.PasswordChar = '*';
            PasswordField.PlaceholderText = "Enter Password";
            PasswordField.Size = new Size(185, 25);
            PasswordField.TabIndex = 6;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LoginButton.Location = new Point(420, 277);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(185, 66);
            LoginButton.TabIndex = 7;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(274, 146);
            label2.Name = "label2";
            label2.Size = new Size(0, 37);
            label2.TabIndex = 3;
            // 
            // Exit_Application
            // 
            Exit_Application.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            Exit_Application.Location = new Point(420, 449);
            Exit_Application.Name = "Exit_Application";
            Exit_Application.Size = new Size(182, 77);
            Exit_Application.TabIndex = 8;
            Exit_Application.Text = "Exit Application";
            Exit_Application.UseVisualStyleBackColor = true;
            Exit_Application.Click += Exit_Application_Click;
            // 
            // CustomerPortalButton
            // 
            CustomerPortalButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            CustomerPortalButton.Location = new Point(420, 365);
            CustomerPortalButton.Name = "CustomerPortalButton";
            CustomerPortalButton.Size = new Size(182, 66);
            CustomerPortalButton.TabIndex = 10;
            CustomerPortalButton.Text = "Customer Portal";
            CustomerPortalButton.UseVisualStyleBackColor = true;
            CustomerPortalButton.Click += CustomerPortalButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 586);
            Controls.Add(menuStrip1);
            Controls.Add(CustomerPortalButton);
            Controls.Add(Exit_Application);
            Controls.Add(LoginButton);
            Controls.Add(PasswordField);
            Controls.Add(PasswordLabel);
            Controls.Add(EmailField);
            Controls.Add(label2);
            Controls.Add(Email_SIN_Label);
            Controls.Add(Title);
            MainMenuStrip = menuStrip1;
            Name = "LoginForm";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpGettingStartedToolStripMenuItem;
        private ToolStripMenuItem helpLoginToolStripMenuItem;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
        private Button CustomerPortalButton;
        private Label Title;
        private ContextMenuStrip contextMenuStrip1;
        private Label Email_SIN_Label;
        private TextBox EmailField;
        private Label PasswordLabel;
        private TextBox PasswordField;
        private Button LoginButton;
        private Label label2;
        private Button Exit_Application;
    }
}
