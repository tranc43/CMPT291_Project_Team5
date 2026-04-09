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
            welcome_title = new Label();
            logged_in_as_label = new Label();
            reports_button = new Button();
            SuspendLayout();
            // 
            // log_out_button
            // 
            log_out_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            log_out_button.Location = new Point(421, 335);
            log_out_button.Name = "log_out_button";
            log_out_button.Size = new Size(177, 86);
            log_out_button.TabIndex = 0;
            log_out_button.Text = "Log Out";
            log_out_button.UseVisualStyleBackColor = true;
            log_out_button.Click += log_out_button_Click;
            // 
            // manage_customers
            // 
            manage_customers.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            manage_customers.Location = new Point(310, 142);
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
            manage_movies.Location = new Point(523, 142);
            manage_movies.Name = "manage_movies";
            manage_movies.Size = new Size(188, 74);
            manage_movies.TabIndex = 2;
            manage_movies.Text = "Manage Movies";
            manage_movies.UseVisualStyleBackColor = true;
            manage_movies.Click += manage_movies_Click;
            // 
            // orders
            // 
            orders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orders.Location = new Point(310, 245);
            orders.Name = "orders";
            orders.Size = new Size(188, 74);
            orders.TabIndex = 3;
            orders.Text = "Movie Rentals";
            orders.UseVisualStyleBackColor = true;
            orders.Click += orders_Click;
            // 
            // welcome_title
            // 
            welcome_title.AutoSize = true;
            welcome_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            welcome_title.Location = new Point(272, 34);
            welcome_title.Name = "welcome_title";
            welcome_title.Size = new Size(467, 37);
            welcome_title.TabIndex = 5;
            welcome_title.Text = "Employee Movie Rental Dashboard";
            // 
            // logged_in_as_label
            // 
            logged_in_as_label.AutoSize = true;
            logged_in_as_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            logged_in_as_label.Location = new Point(421, 80);
            logged_in_as_label.Name = "logged_in_as_label";
            logged_in_as_label.Size = new Size(158, 20);
            logged_in_as_label.TabIndex = 6;
            logged_in_as_label.Text = "Logged in as: nobody";
            // 
            // reports_button
            // 
            reports_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            reports_button.Location = new Point(523, 245);
            reports_button.Name = "reports_button";
            reports_button.Size = new Size(188, 74);
            reports_button.TabIndex = 6;
            reports_button.Text = "Movie Reports";
            reports_button.UseVisualStyleBackColor = true;
            reports_button.Click += reports_button_Click;
            // 
            // Dashboard_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 716);
            Controls.Add(logged_in_as_label);
            Controls.Add(reports_button);
            Controls.Add(welcome_title);
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
        private Label welcome_title;
        private Label logged_in_as_label;
        private Button reports_button;
    }
}
