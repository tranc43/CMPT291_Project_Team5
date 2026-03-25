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
            title_search = new TextBox();
            input_movie_title = new Label();
            fee_field = new TextBox();
            distribution_fee = new Label();
            copies_label = new Label();
            num_copies = new TextBox();
            load_movies = new Button();
            controls = new Label();
            add_movie = new Button();
            update_movie = new Button();
            delete_movie = new Button();
            clear_button = new Button();
            back_button = new Button();
            movie_grid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)movie_grid).BeginInit();
            SuspendLayout();
            // 
            // movie_dashboardd_title
            // 
            movie_dashboardd_title.AutoSize = true;
            movie_dashboardd_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            movie_dashboardd_title.Location = new Point(268, 9);
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
            genre_dropdown.Location = new Point(351, 112);
            genre_dropdown.Name = "genre_dropdown";
            genre_dropdown.Size = new Size(121, 23);
            genre_dropdown.TabIndex = 1;
            genre_dropdown.Text = "Select Genre";
            // 
            // title_search
            // 
            title_search.Location = new Point(492, 112);
            title_search.Name = "title_search";
            title_search.PlaceholderText = "Enter Movie Name..";
            title_search.Size = new Size(124, 23);
            title_search.TabIndex = 2;
            // 
            // input_movie_title
            // 
            input_movie_title.AutoSize = true;
            input_movie_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            input_movie_title.Location = new Point(45, 63);
            input_movie_title.Name = "input_movie_title";
            input_movie_title.Size = new Size(150, 37);
            input_movie_title.TabIndex = 3;
            input_movie_title.Text = "Movie List";
            // 
            // fee_field
            // 
            fee_field.Location = new Point(492, 184);
            fee_field.Name = "fee_field";
            fee_field.PlaceholderText = "Enter fee cost";
            fee_field.Size = new Size(124, 23);
            fee_field.TabIndex = 4;
            // 
            // distribution_fee
            // 
            distribution_fee.AutoSize = true;
            distribution_fee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            distribution_fee.Location = new Point(338, 182);
            distribution_fee.Name = "distribution_fee";
            distribution_fee.Size = new Size(134, 21);
            distribution_fee.TabIndex = 5;
            distribution_fee.Text = "Distribution fee:";
            // 
            // copies_label
            // 
            copies_label.AutoSize = true;
            copies_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            copies_label.Location = new Point(325, 219);
            copies_label.Name = "copies_label";
            copies_label.Size = new Size(147, 21);
            copies_label.TabIndex = 6;
            copies_label.Text = "number of copies:";
            // 
            // num_copies
            // 
            num_copies.Location = new Point(492, 221);
            num_copies.Name = "num_copies";
            num_copies.PlaceholderText = "Enter num of copies";
            num_copies.Size = new Size(124, 23);
            num_copies.TabIndex = 7;
            // 
            // load_movies
            // 
            load_movies.Location = new Point(366, 319);
            load_movies.Name = "load_movies";
            load_movies.Size = new Size(106, 38);
            load_movies.TabIndex = 8;
            load_movies.Text = "Load Movies";
            load_movies.UseVisualStyleBackColor = true;
            load_movies.Click += load_movies_Click;
            // 
            // controls
            // 
            controls.AutoSize = true;
            controls.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            controls.Location = new Point(544, 63);
            controls.Name = "controls";
            controls.Size = new Size(122, 37);
            controls.TabIndex = 15;
            controls.Text = "controls";
            // 
            // add_movie
            // 
            add_movie.Location = new Point(366, 266);
            add_movie.Name = "add_movie";
            add_movie.Size = new Size(106, 38);
            add_movie.TabIndex = 16;
            add_movie.Text = "Add Movie";
            add_movie.UseVisualStyleBackColor = true;
            add_movie.Click += add_movie_Click;
            // 
            // update_movie
            // 
            update_movie.Location = new Point(492, 266);
            update_movie.Name = "update_movie";
            update_movie.Size = new Size(106, 38);
            update_movie.TabIndex = 17;
            update_movie.Text = "Update Movie";
            update_movie.UseVisualStyleBackColor = true;
            update_movie.Click += update_movie_Click;
            // 
            // delete_movie
            // 
            delete_movie.Location = new Point(492, 319);
            delete_movie.Name = "delete_movie";
            delete_movie.Size = new Size(106, 38);
            delete_movie.TabIndex = 18;
            delete_movie.Text = "Delete Movie";
            delete_movie.UseVisualStyleBackColor = true;
            delete_movie.Click += delete_movie_Click;
            // 
            // clear_button
            // 
            clear_button.Location = new Point(650, 206);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(106, 38);
            clear_button.TabIndex = 19;
            clear_button.Text = "Clear Fields";
            clear_button.UseVisualStyleBackColor = true;
            clear_button.Click += clear_button_Click;
            // 
            // back_button
            // 
            back_button.Location = new Point(671, 400);
            back_button.Name = "back_button";
            back_button.Size = new Size(106, 38);
            back_button.TabIndex = 21;
            back_button.Text = "Back";
            back_button.UseVisualStyleBackColor = true;
            back_button.Click += back_button_Click;
            // 
            // movie_grid
            // 
            movie_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movie_grid.Location = new Point(33, 112);
            movie_grid.Name = "movie_grid";
            movie_grid.Size = new Size(162, 245);
            movie_grid.TabIndex = 22;
            movie_grid.CellContentClick += movie_grid_CellContentClick;
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(movie_grid);
            Controls.Add(back_button);
            Controls.Add(clear_button);
            Controls.Add(delete_movie);
            Controls.Add(update_movie);
            Controls.Add(add_movie);
            Controls.Add(controls);
            Controls.Add(load_movies);
            Controls.Add(num_copies);
            Controls.Add(copies_label);
            Controls.Add(distribution_fee);
            Controls.Add(fee_field);
            Controls.Add(input_movie_title);
            Controls.Add(title_search);
            Controls.Add(genre_dropdown);
            Controls.Add(movie_dashboardd_title);
            Name = "MovieForm";
            Text = "MovieForm";
            Load += MovieForm_Load;
            ((System.ComponentModel.ISupportInitialize)movie_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label movie_dashboardd_title;
        private ComboBox genre_dropdown;
        private TextBox title_search;
        private Label input_movie_title;
        private TextBox fee_field;
        private Label distribution_fee;
        private Label copies_label;
        private TextBox num_copies;
        private Button load_movies;
        private Label controls;
        private Button add_movie;
        private Button update_movie;
        private Button delete_movie;
        private Button clear_button;
        private Button back_button;
        private DataGridView movie_grid;
    }
}