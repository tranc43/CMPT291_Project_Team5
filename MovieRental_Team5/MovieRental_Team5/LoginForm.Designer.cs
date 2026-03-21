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
            label1 = new Label();
            label2 = new Label();
            EmailField = new TextBox();
            PasswordField = new TextBox();
            button1 = new Button();
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
            Title.Click += label1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(320, 78);
            label1.Name = "label1";
            label1.Size = new Size(82, 37);
            label1.TabIndex = 2;
            label1.Text = "Email";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(274, 146);
            label2.Name = "label2";
            label2.Size = new Size(128, 37);
            label2.TabIndex = 3;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // EmailField
            // 
            EmailField.Font = new Font("Segoe UI", 10F);
            EmailField.Location = new Point(420, 90);
            EmailField.Name = "EmailField";
            EmailField.Size = new Size(185, 25);
            EmailField.TabIndex = 4;
            // 
            // PasswordField
            // 
            PasswordField.Font = new Font("Segoe UI", 10F);
            PasswordField.Location = new Point(420, 158);
            PasswordField.Name = "PasswordField";
            PasswordField.Size = new Size(185, 25);
            PasswordField.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.Location = new Point(420, 205);
            button1.Name = "button1";
            button1.Size = new Size(185, 66);
            button1.TabIndex = 6;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 534);
            Controls.Add(button1);
            Controls.Add(PasswordField);
            Controls.Add(EmailField);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private TextBox EmailField;
        private TextBox PasswordField;
        private Button button1;
    }
}
