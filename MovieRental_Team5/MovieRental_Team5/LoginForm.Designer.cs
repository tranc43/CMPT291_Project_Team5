namespace MovieRental_Team5
{
    partial class Login_Form
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
            title = new Label();
            email_sin_label = new Label();
            email_field = new TextBox();
            password_label = new Label();
            password_field = new TextBox();
            login_button = new Button();
            label_2 = new Label();
            exit_application = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            title.Location = new Point(294, 36);
            title.Name = "title";
            title.Size = new Size(415, 54);
            title.TabIndex = 0;
            title.Text = "Movie Rental Project";
            // 
            // email_sin_label
            // 
            email_sin_label.AutoSize = true;
            email_sin_label.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email_sin_label.Location = new Point(232, 162);
            email_sin_label.Name = "email_sin_label";
            email_sin_label.Size = new Size(182, 37);
            email_sin_label.TabIndex = 2;
            email_sin_label.Text = "Employee ID";
            // 
            // email_field
            // 
            email_field.Font = new Font("Segoe UI", 10F);
            email_field.Location = new Point(420, 175);
            email_field.Name = "email_field";
            email_field.PlaceholderText = "Enter Employee ID";
            email_field.Size = new Size(185, 25);
            email_field.TabIndex = 4;
            email_field.Click += email_address_input;
            email_field.TextChanged += email_address_input;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password_label.Location = new Point(264, 217);
            password_label.Name = "password_label";
            password_label.Size = new Size(128, 37);
            password_label.TabIndex = 5;
            password_label.Text = "Password";
            // 
            // password_field
            // 
            password_field.Font = new Font("Segoe UI", 10F);
            password_field.Location = new Point(420, 229);
            password_field.Name = "password_field";
            password_field.PasswordChar = '*';
            password_field.PlaceholderText = "Enter Password";
            password_field.Size = new Size(185, 25);
            password_field.TabIndex = 6;
            // 
            // login_button
            // 
            login_button.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            login_button.Location = new Point(420, 277);
            login_button.Name = "login_button";
            login_button.Size = new Size(185, 66);
            login_button.TabIndex = 7;
            login_button.Text = "Login";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_click;
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_2.Location = new Point(274, 146);
            label_2.Name = "label_2";
            label_2.Size = new Size(0, 37);
            label_2.TabIndex = 3;
            // 
            // exit_application
            // 
            exit_application.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            exit_application.Location = new Point(420, 359);
            exit_application.Name = "exit_application";
            exit_application.Size = new Size(182, 77);
            exit_application.TabIndex = 8;
            exit_application.Text = "Exit Application";
            exit_application.UseVisualStyleBackColor = true;
            exit_application.Click += exit_application_click;
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 586);
            Controls.Add(exit_application);
            Controls.Add(login_button);
            Controls.Add(password_field);
            Controls.Add(password_label);
            Controls.Add(email_field);
            Controls.Add(label_2);
            Controls.Add(email_sin_label);
            Controls.Add(title);
            Name = "Login_Form";
            Text = "Form1";
            Load += form_1_load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label email_sin_label;
        private TextBox email_field;
        private Label password_label;
        private TextBox password_field;
        private Button login_button;
        private Label label_2;
        private Button exit_application;
    }
}
