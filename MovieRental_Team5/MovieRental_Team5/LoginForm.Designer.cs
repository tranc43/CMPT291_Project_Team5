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
            Title = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Email_SIN_Label = new Label();
            EmailField = new TextBox();
            LoginButton = new Button();
            label2 = new Label();
            Exit_Application = new Button();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            Title.Location = new Point(294, 9);
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
            Email_SIN_Label.Location = new Point(232, 145);
            Email_SIN_Label.Name = "Email_SIN_Label";
            Email_SIN_Label.Size = new Size(182, 37);
            Email_SIN_Label.TabIndex = 2;
            Email_SIN_Label.Text = "Employee SIN";
            // 
            // EmailField
            // 
            EmailField.Font = new Font("Segoe UI", 10F);
            EmailField.Location = new Point(420, 158);
            EmailField.Name = "EmailField";
            EmailField.PlaceholderText = "Enter Employee SIN";
            EmailField.Size = new Size(185, 25);
            EmailField.TabIndex = 4;
            EmailField.Click += EmailAddressInput;
            EmailField.TextChanged += EmailAddressInput;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LoginButton.Location = new Point(420, 205);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(185, 66);
            LoginButton.TabIndex = 6;
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
            Exit_Application.Location = new Point(420, 307);
            Exit_Application.Name = "Exit_Application";
            Exit_Application.Size = new Size(182, 77);
            Exit_Application.TabIndex = 7;
            Exit_Application.Text = "Exit Application";
            Exit_Application.UseVisualStyleBackColor = true;
            Exit_Application.Click += Exit_Application_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 586);
            Controls.Add(Exit_Application);
            Controls.Add(LoginButton);
            Controls.Add(EmailField);
            Controls.Add(label2);
            Controls.Add(Email_SIN_Label);
            Controls.Add(Title);
            Name = "LoginForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private ContextMenuStrip contextMenuStrip1;
        private Label Email_SIN_Label;
        private TextBox EmailField;
        private Button LoginButton;
        private Label label2;
        private Button Exit_Application;
    }
}
