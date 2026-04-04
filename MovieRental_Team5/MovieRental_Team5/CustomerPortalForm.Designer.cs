namespace MovieRental_Team5
{
    partial class CustomerPortalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpOverviewToolStripMenuItem = new ToolStripMenuItem();
            helpCustomersToolStripMenuItem = new ToolStripMenuItem();
            helpAboutToolStripMenuItem = new ToolStripMenuItem();
            title_label = new Label();
            customer_selector_label = new Label();
            customer_selector = new ComboBox();
            refresh_button = new Button();
            back_button = new Button();
            portal_tabs = new TabControl();
            account_tab = new TabPage();
            account_rating_value = new Label();
            account_created_value = new Label();
            account_number_value = new Label();
            account_postal_value = new Label();
            account_address_value = new Label();
            account_province_value = new Label();
            account_city_value = new Label();
            account_email_value = new Label();
            account_name_value = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            current_tab = new TabPage();
            current_rentals_grid = new DataGridView();
            history_tab = new TabPage();
            history_grid = new DataGridView();
            browse_tab = new TabPage();
            suggestions_grid = new DataGridView();
            suggestions_label = new Label();
            bestseller_grid = new DataGridView();
            bestsellers_label = new Label();
            browse_button = new Button();
            keyword_filter = new TextBox();
            keyword_filter_label = new Label();
            movie_type_filter = new ComboBox();
            movie_type_filter_label = new Label();
            available_movies_grid = new DataGridView();
            available_movies_label = new Label();
            menuStrip1.SuspendLayout();
            portal_tabs.SuspendLayout();
            account_tab.SuspendLayout();
            current_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)current_rentals_grid).BeginInit();
            history_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)history_grid).BeginInit();
            browse_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)suggestions_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bestseller_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)available_movies_grid).BeginInit();
            SuspendLayout();
            // menu
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1260, 24);
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpOverviewToolStripMenuItem, helpCustomersToolStripMenuItem, helpAboutToolStripMenuItem });
            helpToolStripMenuItem.Text = "Help";
            helpOverviewToolStripMenuItem.Text = "Getting Started";
            helpOverviewToolStripMenuItem.Click += helpOverviewToolStripMenuItem_Click;
            helpCustomersToolStripMenuItem.Text = "Customer Portal";
            helpCustomersToolStripMenuItem.Click += helpCustomersToolStripMenuItem_Click;
            helpAboutToolStripMenuItem.Text = "About";
            helpAboutToolStripMenuItem.Click += helpAboutToolStripMenuItem_Click;
            // header
            title_label.AutoSize = true;
            title_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            title_label.Location = new Point(446, 33);
            title_label.Text = "Customer Portal";
            customer_selector_label.AutoSize = true;
            customer_selector_label.Location = new Point(31, 87);
            customer_selector_label.Text = "Select Customer";
            customer_selector.DropDownStyle = ComboBoxStyle.DropDownList;
            customer_selector.Location = new Point(132, 84);
            customer_selector.Size = new Size(269, 23);
            customer_selector.SelectedIndexChanged += customer_selector_SelectedIndexChanged;
            refresh_button.Location = new Point(420, 79);
            refresh_button.Size = new Size(120, 33);
            refresh_button.Text = "Refresh Portal";
            refresh_button.Click += refresh_button_Click;
            back_button.Location = new Point(1118, 76);
            back_button.Size = new Size(110, 33);
            back_button.Text = "Back";
            back_button.Click += back_button_Click;
            // tabs
            portal_tabs.Controls.Add(account_tab);
            portal_tabs.Controls.Add(current_tab);
            portal_tabs.Controls.Add(history_tab);
            portal_tabs.Controls.Add(browse_tab);
            portal_tabs.Location = new Point(22, 129);
            portal_tabs.Size = new Size(1210, 560);
            // account tab
            account_tab.Text = "Account";
            Label[] labels = { label10, label11, label12, label13, label14, label15, label16, label17, label18 };
            string[] texts = { "Name", "Email", "City", "Province", "Address", "Postal Code", "Account Number", "Created", "Average Rating" };
            Label[] values = { account_name_value, account_email_value, account_city_value, account_province_value, account_address_value, account_postal_value, account_number_value, account_created_value, account_rating_value };
            int y = 34;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].AutoSize = true;
                labels[i].Location = new Point(62, y);
                labels[i].Text = texts[i];
                values[i].AutoSize = true;
                values[i].Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                values[i].Location = new Point(230, y - 2);
                values[i].Text = "-";
                account_tab.Controls.Add(labels[i]);
                account_tab.Controls.Add(values[i]);
                y += 45;
            }
            // current tab
            current_tab.Text = "Currently Held Movies";
            current_rentals_grid.Dock = DockStyle.Fill;
            current_tab.Controls.Add(current_rentals_grid);
            // history tab
            history_tab.Text = "Order History";
            history_grid.Dock = DockStyle.Fill;
            history_tab.Controls.Add(history_grid);
            // browse tab
            browse_tab.Text = "Browse";
            movie_type_filter_label.AutoSize = true;
            movie_type_filter_label.Location = new Point(21, 18);
            movie_type_filter_label.Text = "Movie Type";
            movie_type_filter.DropDownStyle = ComboBoxStyle.DropDownList;
            movie_type_filter.Items.AddRange(new object[] { "All", "Action", "Comedy", "Drama", "Foreign" });
            movie_type_filter.Location = new Point(95, 15);
            movie_type_filter.Size = new Size(138, 23);
            movie_type_filter.SelectedIndex = 0;
            keyword_filter_label.AutoSize = true;
            keyword_filter_label.Location = new Point(254, 18);
            keyword_filter_label.Text = "Keyword";
            keyword_filter.Location = new Point(312, 15);
            keyword_filter.Size = new Size(185, 23);
            browse_button.Location = new Point(518, 11);
            browse_button.Size = new Size(114, 30);
            browse_button.Text = "Browse Movies";
            browse_button.Click += browse_button_Click;
            available_movies_label.AutoSize = true;
            available_movies_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            available_movies_label.Location = new Point(21, 54);
            available_movies_label.Text = "Available Movies";
            available_movies_grid.Location = new Point(21, 79);
            available_movies_grid.Size = new Size(748, 206);
            bestsellers_label.AutoSize = true;
            bestsellers_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            bestsellers_label.Location = new Point(790, 54);
            bestsellers_label.Text = "Best-Seller List";
            bestseller_grid.Location = new Point(790, 79);
            bestseller_grid.Size = new Size(385, 206);
            suggestions_label.AutoSize = true;
            suggestions_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            suggestions_label.Location = new Point(21, 307);
            suggestions_label.Text = "Personalized Suggestions";
            suggestions_grid.Location = new Point(21, 332);
            suggestions_grid.Size = new Size(748, 171);
            browse_tab.Controls.Add(movie_type_filter_label);
            browse_tab.Controls.Add(movie_type_filter);
            browse_tab.Controls.Add(keyword_filter_label);
            browse_tab.Controls.Add(keyword_filter);
            browse_tab.Controls.Add(browse_button);
            browse_tab.Controls.Add(available_movies_label);
            browse_tab.Controls.Add(available_movies_grid);
            browse_tab.Controls.Add(bestsellers_label);
            browse_tab.Controls.Add(bestseller_grid);
            browse_tab.Controls.Add(suggestions_label);
            browse_tab.Controls.Add(suggestions_grid);
            // form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 706);
            Controls.Add(portal_tabs);
            Controls.Add(back_button);
            Controls.Add(refresh_button);
            Controls.Add(customer_selector);
            Controls.Add(customer_selector_label);
            Controls.Add(title_label);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CustomerPortalForm";
            Text = "CustomerPortalForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            portal_tabs.ResumeLayout(false);
            account_tab.ResumeLayout(false);
            account_tab.PerformLayout();
            current_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)current_rentals_grid).EndInit();
            history_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)history_grid).EndInit();
            browse_tab.ResumeLayout(false);
            browse_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)suggestions_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bestseller_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)available_movies_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpOverviewToolStripMenuItem;
        private ToolStripMenuItem helpCustomersToolStripMenuItem;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
        private Label title_label;
        private Label customer_selector_label;
        private ComboBox customer_selector;
        private Button refresh_button;
        private Button back_button;
        private TabControl portal_tabs;
        private TabPage account_tab;
        private TabPage current_tab;
        private TabPage history_tab;
        private TabPage browse_tab;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label account_name_value;
        private Label account_email_value;
        private Label account_city_value;
        private Label account_province_value;
        private Label account_address_value;
        private Label account_postal_value;
        private Label account_number_value;
        private Label account_created_value;
        private Label account_rating_value;
        private DataGridView current_rentals_grid;
        private DataGridView history_grid;
        private ComboBox movie_type_filter;
        private Label movie_type_filter_label;
        private TextBox keyword_filter;
        private Label keyword_filter_label;
        private Button browse_button;
        private Label available_movies_label;
        private DataGridView available_movies_grid;
        private Label bestsellers_label;
        private DataGridView bestseller_grid;
        private Label suggestions_label;
        private DataGridView suggestions_grid;
    }
}
