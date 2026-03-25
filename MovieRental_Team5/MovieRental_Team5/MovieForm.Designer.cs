namespace MovieRental_Team5
{
    partial class MovieForm
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
            movie_dashboardd_title = new Label();
            genre_dropdown = new ComboBox();
            genre_search = new TextBox();
            input_movie_title = new Label();
            fee_field = new TextBox();
            distribution_fee = new Label();
            copies_label = new Label();
            num_copies = new TextBox();
            SuspendLayout();
            // 
            // movie_dashboardd_title
            // 
            movie_dashboardd_title.AutoSize = true;
            movie_dashboardd_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            movie_dashboardd_title.Location = new Point(273, 24);
            movie_dashboardd_title.Name = "movie_dashboardd_title";
            movie_dashboardd_title.Size = new Size(245, 37);
            movie_dashboardd_title.TabIndex = 0;
            movie_dashboardd_title.Text = "Movie Dashboard";
            // 
            // genre_dropdown
            // 
            genre_dropdown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            genre_dropdown.FormattingEnabled = true;
            genre_dropdown.Items.AddRange(new object[] { "Comedy", "Action", "Drama", "Foreign" });
            genre_dropdown.Location = new Point(34, 134);
            genre_dropdown.Name = "genre_dropdown";
            genre_dropdown.Size = new Size(121, 23);
            genre_dropdown.TabIndex = 1;
            genre_dropdown.Text = "Select Genre";
            // 
            // genre_search
            // 
            genre_search.Location = new Point(175, 134);
            genre_search.Name = "genre_search";
            genre_search.PlaceholderText = "Enter Movie Name..";
            genre_search.Size = new Size(124, 23);
            genre_search.TabIndex = 2;
            // 
            // input_movie_title
            // 
            input_movie_title.AutoSize = true;
            input_movie_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            input_movie_title.Location = new Point(103, 76);
            input_movie_title.Name = "input_movie_title";
            input_movie_title.Size = new Size(196, 37);
            input_movie_title.TabIndex = 3;
            input_movie_title.Text = "Input a Movie";
            // 
            // fee_field
            // 
            fee_field.Location = new Point(175, 203);
            fee_field.Name = "fee_field";
            fee_field.PlaceholderText = "Enter fee cost";
            fee_field.Size = new Size(124, 23);
            fee_field.TabIndex = 4;
            // 
            // distribution_fee
            // 
            distribution_fee.AutoSize = true;
            distribution_fee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            distribution_fee.Location = new Point(21, 201);
            distribution_fee.Name = "distribution_fee";
            distribution_fee.Size = new Size(134, 21);
            distribution_fee.TabIndex = 5;
            distribution_fee.Text = "Distribution fee:";
            // 
            // copies_label
            // 
            copies_label.AutoSize = true;
            copies_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            copies_label.Location = new Point(12, 244);
            copies_label.Name = "copies_label";
            copies_label.Size = new Size(147, 21);
            copies_label.TabIndex = 6;
            copies_label.Text = "number of copies:";
            // 
            // num_copies
            // 
            num_copies.Location = new Point(175, 244);
            num_copies.Name = "num_copies";
            num_copies.PlaceholderText = "Enter num of copies";
            num_copies.Size = new Size(124, 23);
            num_copies.TabIndex = 7;
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(num_copies);
            Controls.Add(copies_label);
            Controls.Add(distribution_fee);
            Controls.Add(fee_field);
            Controls.Add(input_movie_title);
            Controls.Add(genre_search);
            Controls.Add(genre_dropdown);
            Controls.Add(movie_dashboardd_title);
            Name = "MovieForm";
            Text = "MovieForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label movie_dashboardd_title;
        private ComboBox genre_dropdown;
        private TextBox genre_search;
        private Label input_movie_title;
        private TextBox fee_field;
        private Label distribution_fee;
        private Label copies_label;
        private TextBox num_copies;
    }
}