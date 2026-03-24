namespace MovieRental_Team5
{
    partial class Dashboard_Form
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
            log_out_button = new Button();
            manage_customers = new Button();
            manage_movies = new Button();
            orders = new Button();
            button1 = new Button();
            welcome_title = new Label();
            SuspendLayout();
            // 
            // log_out_button
            // 
            log_out_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            log_out_button.Location = new Point(377, 396);
            log_out_button.Name = "log_out_button";
            log_out_button.Size = new Size(188, 74);
            log_out_button.TabIndex = 0;
            log_out_button.Text = "Log Out";
            log_out_button.UseVisualStyleBackColor = true;
            // 
            // manage_customers
            // 
            manage_customers.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            manage_customers.Location = new Point(272, 114);
            manage_customers.Name = "manage_customers";
            manage_customers.Size = new Size(188, 74);
            manage_customers.TabIndex = 1;
            manage_customers.Text = "Manage Customers";
            manage_customers.UseVisualStyleBackColor = true;
            manage_customers.Click += manage_customers_Click;
            // 
            // manage_movies
            // 
            manage_movies.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            manage_movies.Location = new Point(491, 114);
            manage_movies.Name = "manage_movies";
            manage_movies.Size = new Size(188, 74);
            manage_movies.TabIndex = 2;
            manage_movies.Text = "Manage Movies";
            manage_movies.UseVisualStyleBackColor = true;
            // 
            // orders
            // 
            orders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orders.Location = new Point(272, 218);
            orders.Name = "orders";
            orders.Size = new Size(188, 74);
            orders.TabIndex = 3;
            orders.Text = "Record Order";
            orders.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(491, 218);
            button1.Name = "button1";
            button1.Size = new Size(188, 74);
            button1.TabIndex = 4;
            button1.Text = "Record Order";
            button1.UseVisualStyleBackColor = true;
            // 
            // welcome_title
            // 
            welcome_title.AutoSize = true;
            welcome_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            welcome_title.Location = new Point(272, 50);
            welcome_title.Name = "welcome_title";
            welcome_title.Size = new Size(334, 37);
            welcome_title.TabIndex = 5;
            welcome_title.Text = "Movie Rental Dashboard";
            welcome_title.Click += Title_Click;
            // 
            // Dashboard_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 526);
            Controls.Add(welcome_title);
            Controls.Add(button1);
            Controls.Add(orders);
            Controls.Add(manage_movies);
            Controls.Add(manage_customers);
            Controls.Add(log_out_button);
            Name = "Dashboard_Form";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button log_out_button;
        private Button manage_customers;
        private Button manage_movies;
        private Button orders;
        private Button button1;
        private Label welcome_title;
    }
}