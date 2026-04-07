namespace MovieRental_Team5
{
    partial class MovieForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            movie_dashboardd_title = new Label();
            input_movie_title = new Label();
            movie_grid = new DataGridView();
            search_label = new Label();
            search_movie_field = new TextBox();
            genre_search_label = new Label();
            genre_search_dropdown = new ComboBox();
            search_button = new Button();
            movie_info = new Label();
            distribution_fee = new Label();
            copies_label = new Label();
            title_label = new Label();
            genre_label = new Label();
            fee_field = new TextBox();
            num_copies = new TextBox();
            title_field = new TextBox();
            genre_dropdown = new ComboBox();
            load_movies = new Button();
            add_movie = new Button();
            update_movie = new Button();
            delete_movie = new Button();
            clear_button = new Button();
            back_button = new Button();
            actor_controls_label = new Label();
            actor_dropdown = new ComboBox();
            assign_actor_button = new Button();
            remove_actor_button = new Button();
            movie_actor_grid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)movie_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movie_actor_grid).BeginInit();
            SuspendLayout();
            // movie_dashboardd_title
            // 
            movie_dashboardd_title.AutoSize = true;
            movie_dashboardd_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            movie_dashboardd_title.Location = new Point(387, 24);
            movie_dashboardd_title.Name = "movie_dashboardd_title";
            movie_dashboardd_title.Size = new Size(245, 37);
            movie_dashboardd_title.TabIndex = 27;
            movie_dashboardd_title.Text = "Movie Dashboard";
            // 
            // input_movie_title
            // 
            input_movie_title.AutoSize = true;
            input_movie_title.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            input_movie_title.Location = new Point(27, 72);
            input_movie_title.Name = "input_movie_title";
            input_movie_title.Size = new Size(110, 28);
            input_movie_title.TabIndex = 26;
            input_movie_title.Text = "Movie List";
            // 
            // movie_grid
            // 
            movie_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movie_grid.Location = new Point(27, 135);
            movie_grid.Name = "movie_grid";
            movie_grid.Size = new Size(640, 255);
            movie_grid.TabIndex = 25;
            movie_grid.CellClick += movie_grid_CellContentClick;
            movie_grid.CellContentClick += movie_grid_CellContentClick;
            // 
            // search_label
            // 
            search_label.AutoSize = true;
            search_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            search_label.Location = new Point(27, 104);
            search_label.Name = "search_label";
            search_label.Size = new Size(98, 19);
            search_label.TabIndex = 24;
            search_label.Text = "Search Name";
            // 
            // search_movie_field
            // 
            search_movie_field.Location = new Point(124, 103);
            search_movie_field.Name = "search_movie_field";
            search_movie_field.Size = new Size(180, 23);
            search_movie_field.TabIndex = 23;
            // 
            // genre_search_label
            // 
            genre_search_label.AutoSize = true;
            genre_search_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            genre_search_label.Location = new Point(322, 104);
            genre_search_label.Name = "genre_search_label";
            genre_search_label.Size = new Size(49, 19);
            genre_search_label.TabIndex = 22;
            genre_search_label.Text = "Genre";
            // 
            // genre_search_dropdown
            // 
            genre_search_dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            genre_search_dropdown.Items.AddRange(new object[] { "All", "Action", "Comedy", "Drama", "Foreign" });
            genre_search_dropdown.Location = new Point(374, 103);
            genre_search_dropdown.Name = "genre_search_dropdown";
            genre_search_dropdown.Size = new Size(121, 23);
            genre_search_dropdown.TabIndex = 21;
            // 
            // search_button
            // 
            search_button.Location = new Point(517, 99);
            search_button.Name = "search_button";
            search_button.Size = new Size(90, 30);
            search_button.TabIndex = 20;
            search_button.Text = "Search";
            search_button.Click += search_button_Click;
            // 
            // movie_info
            // 
            movie_info.AutoSize = true;
            movie_info.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            movie_info.Location = new Point(105, 413);
            movie_info.Name = "movie_info";
            movie_info.Size = new Size(143, 28);
            movie_info.TabIndex = 19;
            movie_info.Text = "Movie Details";
            // 
            // distribution_fee
            // 
            distribution_fee.AutoSize = true;
            distribution_fee.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            distribution_fee.Location = new Point(42, 517);
            distribution_fee.Name = "distribution_fee";
            distribution_fee.Size = new Size(121, 20);
            distribution_fee.TabIndex = 16;
            distribution_fee.Text = "Distribution Fee";
            // 
            // copies_label
            // 
            copies_label.AutoSize = true;
            copies_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            copies_label.Location = new Point(42, 553);
            copies_label.Name = "copies_label";
            copies_label.Size = new Size(138, 20);
            copies_label.TabIndex = 15;
            copies_label.Text = "Number Of Copies";
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            title_label.Location = new Point(42, 445);
            title_label.Name = "title_label";
            title_label.Size = new Size(40, 20);
            title_label.TabIndex = 18;
            title_label.Text = "Title";
            // 
            // genre_label
            // 
            genre_label.AutoSize = true;
            genre_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            genre_label.Location = new Point(42, 481);
            genre_label.Name = "genre_label";
            genre_label.Size = new Size(51, 20);
            genre_label.TabIndex = 17;
            genre_label.Text = "Genre";
            // 
            // fee_field
            // 
            fee_field.Location = new Point(172, 516);
            fee_field.Name = "fee_field";
            fee_field.Size = new Size(157, 23);
            fee_field.TabIndex = 12;
            // 
            // num_copies
            // 
            num_copies.Location = new Point(186, 552);
            num_copies.Name = "num_copies";
            num_copies.Size = new Size(143, 23);
            num_copies.TabIndex = 11;
            // 
            // title_field
            // 
            title_field.Location = new Point(139, 444);
            title_field.Name = "title_field";
            title_field.Size = new Size(190, 23);
            title_field.TabIndex = 14;
            // 
            // genre_dropdown
            // 
            genre_dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            genre_dropdown.Location = new Point(139, 480);
            genre_dropdown.Name = "genre_dropdown";
            genre_dropdown.Size = new Size(190, 23);
            genre_dropdown.TabIndex = 13;
            // 
            // load_movies
            // 
            load_movies.Location = new Point(387, 444);
            load_movies.Name = "load_movies";
            load_movies.Size = new Size(106, 38);
            load_movies.TabIndex = 10;
            load_movies.Text = "Load Movies";
            load_movies.Click += load_movies_Click;
            // 
            // add_movie
            // 
            add_movie.Location = new Point(517, 444);
            add_movie.Name = "add_movie";
            add_movie.Size = new Size(106, 38);
            add_movie.TabIndex = 9;
            add_movie.Text = "Add Movie";
            add_movie.Click += add_movie_Click;
            // 
            // update_movie
            // 
            update_movie.Location = new Point(387, 509);
            update_movie.Name = "update_movie";
            update_movie.Size = new Size(106, 38);
            update_movie.TabIndex = 8;
            update_movie.Text = "Update Movie";
            update_movie.Click += update_movie_Click;
            // 
            // delete_movie
            // 
            delete_movie.Location = new Point(517, 509);
            delete_movie.Name = "delete_movie";
            delete_movie.Size = new Size(106, 38);
            delete_movie.TabIndex = 7;
            delete_movie.Text = "Delete Movie";
            delete_movie.Click += delete_movie_Click;
            // 
            // clear_button
            // 
            clear_button.Location = new Point(387, 574);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(106, 38);
            clear_button.TabIndex = 6;
            clear_button.Text = "Clear Fields";
            clear_button.Click += clear_button_Click;
            // 
            // back_button
            // 
            back_button.Location = new Point(904, 662);
            back_button.Name = "back_button";
            back_button.Size = new Size(106, 38);
            back_button.TabIndex = 5;
            back_button.Text = "Back";
            back_button.Click += back_button_Click;
            // 
            // actor_controls_label
            // 
            actor_controls_label.AutoSize = true;
            actor_controls_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            actor_controls_label.Location = new Point(711, 72);
            actor_controls_label.Name = "actor_controls_label";
            actor_controls_label.Size = new Size(164, 28);
            actor_controls_label.TabIndex = 4;
            actor_controls_label.Text = "Assigned Actors";
            // 
            // actor_dropdown
            // 
            actor_dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            actor_dropdown.Location = new Point(711, 453);
            actor_dropdown.Name = "actor_dropdown";
            actor_dropdown.Size = new Size(255, 23);
            actor_dropdown.TabIndex = 3;
            // 
            // assign_actor_button
            // 
            assign_actor_button.Location = new Point(711, 491);
            assign_actor_button.Name = "assign_actor_button";
            assign_actor_button.Size = new Size(122, 32);
            assign_actor_button.TabIndex = 2;
            assign_actor_button.Text = "Assign Actor";
            assign_actor_button.Click += assign_actor_button_Click;
            // 
            // remove_actor_button
            // 
            remove_actor_button.Location = new Point(844, 491);
            remove_actor_button.Name = "remove_actor_button";
            remove_actor_button.Size = new Size(122, 32);
            remove_actor_button.TabIndex = 1;
            remove_actor_button.Text = "Remove Actor";
            remove_actor_button.Click += remove_actor_button_Click;
            // 
            // movie_actor_grid
            // 
            movie_actor_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movie_actor_grid.Location = new Point(711, 138);
            movie_actor_grid.Name = "movie_actor_grid";
            movie_actor_grid.Size = new Size(296, 252);
            movie_actor_grid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(431, 413);
            label1.Name = "label1";
            label1.Size = new Size(156, 28);
            label1.TabIndex = 29;
            label1.Text = "Movie Controls\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(775, 413);
            label2.Name = "label2";
            label2.Size = new Size(149, 28);
            label2.TabIndex = 30;
            label2.Text = "Actor Controls";
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 730);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(movie_actor_grid);
            Controls.Add(remove_actor_button);
            Controls.Add(assign_actor_button);
            Controls.Add(actor_dropdown);
            Controls.Add(actor_controls_label);
            Controls.Add(back_button);
            Controls.Add(clear_button);
            Controls.Add(delete_movie);
            Controls.Add(update_movie);
            Controls.Add(add_movie);
            Controls.Add(load_movies);
            Controls.Add(num_copies);
            Controls.Add(fee_field);
            Controls.Add(genre_dropdown);
            Controls.Add(title_field);
            Controls.Add(copies_label);
            Controls.Add(distribution_fee);
            Controls.Add(genre_label);
            Controls.Add(title_label);
            Controls.Add(movie_info);
            Controls.Add(search_button);
            Controls.Add(genre_search_dropdown);
            Controls.Add(genre_search_label);
            Controls.Add(search_movie_field);
            Controls.Add(search_label);
            Controls.Add(movie_grid);
            Controls.Add(input_movie_title);
            Controls.Add(movie_dashboardd_title);
            Name = "MovieForm";
            Text = "MovieForm";
            Load += MovieForm_Load;
            ((System.ComponentModel.ISupportInitialize)movie_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)movie_actor_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label movie_dashboardd_title;
        private Label input_movie_title;
        private DataGridView movie_grid;
        private Label search_label;
        private TextBox search_movie_field;
        private Label genre_search_label;
        private ComboBox genre_search_dropdown;
        private Button search_button;
        private Label movie_info;
        private Label title_label;
        private Label genre_label;
        private Label distribution_fee;
        private Label copies_label;
        private TextBox title_field;
        private ComboBox genre_dropdown;
        private TextBox fee_field;
        private TextBox num_copies;
        private Button load_movies;
        private Button add_movie;
        private Button update_movie;
        private Button delete_movie;
        private Button clear_button;
        private Button back_button;
        private Label actor_controls_label;
        private ComboBox actor_dropdown;
        private Button assign_actor_button;
        private Button remove_actor_button;
        private DataGridView movie_actor_grid;
        private Label label1;
        private Label label2;
    }
}
