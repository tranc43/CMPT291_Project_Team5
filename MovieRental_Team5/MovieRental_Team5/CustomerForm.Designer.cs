namespace MovieRental_Team5
{
    partial class CustomerForm
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
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpOverviewToolStripMenuItem = new ToolStripMenuItem();
            helpCustomersToolStripMenuItem = new ToolStripMenuItem();
            helpAboutToolStripMenuItem = new ToolStripMenuItem();
            customer_title = new Label();
            customer_grid = new DataGridView();
            controls_label = new Label();
            first_name_label = new Label();
            last_name_label = new Label();
            email_label = new Label();
            city_label = new Label();
            province_label = new Label();
            address_label = new Label();
            postal_code_label = new Label();
            account_number_label = new Label();
            account_creation_label = new Label();
            credit_card_label = new Label();
            average_rating_label = new Label();
            first_name_field = new TextBox();
            last_name_field = new TextBox();
            email_field = new TextBox();
            city_field = new TextBox();
            province_field = new TextBox();
            address_field = new TextBox();
            postal_code_field = new TextBox();
            account_number_field = new TextBox();
            credit_card_field = new TextBox();
            average_rating_field = new TextBox();
            account_creation_picker = new DateTimePicker();
            load_customers_button = new Button();
            add_customer_button = new Button();
            update_customer_button = new Button();
            delete_customer_button = new Button();
            clear_button = new Button();
            back_button = new Button();
            search_first_label = new Label();
            search_last_label = new Label();
            search_email_label = new Label();
            customer_search_first_field = new TextBox();
            customer_search_last_field = new TextBox();
            customer_search_email_field = new TextBox();
            search_customers_button = new Button();
            queue_label = new Label();
            history_label = new Label();
            customer_queue_grid = new DataGridView();
            customer_history_grid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customer_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customer_queue_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customer_history_grid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 804);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1227, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpOverviewToolStripMenuItem, helpCustomersToolStripMenuItem, helpAboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpOverviewToolStripMenuItem
            // 
            helpOverviewToolStripMenuItem.Name = "helpOverviewToolStripMenuItem";
            helpOverviewToolStripMenuItem.Size = new Size(200, 22);
            helpOverviewToolStripMenuItem.Text = "Getting Started";
            helpOverviewToolStripMenuItem.Click += helpOverviewToolStripMenuItem_Click;
            // 
            // helpCustomersToolStripMenuItem
            // 
            helpCustomersToolStripMenuItem.Name = "helpCustomersToolStripMenuItem";
            helpCustomersToolStripMenuItem.Size = new Size(200, 22);
            helpCustomersToolStripMenuItem.Text = "Customer Management";
            helpCustomersToolStripMenuItem.Click += helpCustomersToolStripMenuItem_Click;
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.Size = new Size(200, 22);
            helpAboutToolStripMenuItem.Text = "About";
            helpAboutToolStripMenuItem.Click += helpAboutToolStripMenuItem_Click;
            // 
            // customer_title
            // 
            customer_title.AutoSize = true;
            customer_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            customer_title.Location = new Point(822, 51);
            customer_title.Name = "customer_title";
            customer_title.Size = new Size(288, 37);
            customer_title.TabIndex = 1;
            customer_title.Text = "Customer Dashboard";
            // 
            // customer_grid
            // 
            customer_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customer_grid.Location = new Point(696, 91);
            customer_grid.Name = "customer_grid";
            customer_grid.Size = new Size(519, 468);
            customer_grid.TabIndex = 2;
            customer_grid.CellClick += customer_grid_CellClick;
            // 
            // controls_label
            // 
            controls_label.AutoSize = true;
            controls_label.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            controls_label.Location = new Point(905, 579);
            controls_label.Name = "controls_label";
            controls_label.Size = new Size(111, 32);
            controls_label.TabIndex = 3;
            controls_label.Text = "Controls";
            // 
            // first_name_label
            // 
            first_name_label.AutoSize = true;
            first_name_label.Location = new Point(30, 380);
            first_name_label.Name = "first_name_label";
            first_name_label.Size = new Size(64, 15);
            first_name_label.TabIndex = 4;
            first_name_label.Text = "First Name";
            // 
            // last_name_label
            // 
            last_name_label.AutoSize = true;
            last_name_label.Location = new Point(30, 416);
            last_name_label.Name = "last_name_label";
            last_name_label.Size = new Size(63, 15);
            last_name_label.TabIndex = 5;
            last_name_label.Text = "Last Name";
            // 
            // email_label
            // 
            email_label.AutoSize = true;
            email_label.Location = new Point(30, 452);
            email_label.Name = "email_label";
            email_label.Size = new Size(81, 15);
            email_label.TabIndex = 6;
            email_label.Text = "Email Address";
            // 
            // city_label
            // 
            city_label.AutoSize = true;
            city_label.Location = new Point(30, 488);
            city_label.Name = "city_label";
            city_label.Size = new Size(28, 15);
            city_label.TabIndex = 7;
            city_label.Text = "City";
            // 
            // province_label
            // 
            province_label.AutoSize = true;
            province_label.Location = new Point(30, 524);
            province_label.Name = "province_label";
            province_label.Size = new Size(53, 15);
            province_label.TabIndex = 8;
            province_label.Text = "Province";
            // 
            // address_label
            // 
            address_label.AutoSize = true;
            address_label.Location = new Point(30, 560);
            address_label.Name = "address_label";
            address_label.Size = new Size(49, 15);
            address_label.TabIndex = 9;
            address_label.Text = "Address";
            // 
            // postal_code_label
            // 
            postal_code_label.AutoSize = true;
            postal_code_label.Location = new Point(30, 596);
            postal_code_label.Name = "postal_code_label";
            postal_code_label.Size = new Size(70, 15);
            postal_code_label.TabIndex = 10;
            postal_code_label.Text = "Postal Code";
            // 
            // account_number_label
            // 
            account_number_label.AutoSize = true;
            account_number_label.Location = new Point(30, 632);
            account_number_label.Name = "account_number_label";
            account_number_label.Size = new Size(99, 15);
            account_number_label.TabIndex = 11;
            account_number_label.Text = "Account Number";
            // 
            // account_creation_label
            // 
            account_creation_label.AutoSize = true;
            account_creation_label.Location = new Point(30, 668);
            account_creation_label.Name = "account_creation_label";
            account_creation_label.Size = new Size(127, 15);
            account_creation_label.TabIndex = 12;
            account_creation_label.Text = "Account Creation Date";
            // 
            // credit_card_label
            // 
            credit_card_label.AutoSize = true;
            credit_card_label.Location = new Point(30, 704);
            credit_card_label.Name = "credit_card_label";
            credit_card_label.Size = new Size(114, 15);
            credit_card_label.TabIndex = 13;
            credit_card_label.Text = "Credit Card Number";
            // 
            // average_rating_label
            // 
            average_rating_label.AutoSize = true;
            average_rating_label.Location = new Point(30, 740);
            average_rating_label.Name = "average_rating_label";
            average_rating_label.Size = new Size(87, 15);
            average_rating_label.TabIndex = 14;
            average_rating_label.Text = "Average Rating";
            // 
            // first_name_field
            // 
            first_name_field.Location = new Point(176, 377);
            first_name_field.Name = "first_name_field";
            first_name_field.Size = new Size(188, 23);
            first_name_field.TabIndex = 15;
            // 
            // last_name_field
            // 
            last_name_field.Location = new Point(176, 413);
            last_name_field.Name = "last_name_field";
            last_name_field.Size = new Size(188, 23);
            last_name_field.TabIndex = 16;
            // 
            // email_field
            // 
            email_field.Location = new Point(176, 449);
            email_field.Name = "email_field";
            email_field.Size = new Size(188, 23);
            email_field.TabIndex = 17;
            // 
            // city_field
            // 
            city_field.Location = new Point(176, 485);
            city_field.Name = "city_field";
            city_field.Size = new Size(188, 23);
            city_field.TabIndex = 18;
            // 
            // province_field
            // 
            province_field.Location = new Point(176, 521);
            province_field.Name = "province_field";
            province_field.Size = new Size(188, 23);
            province_field.TabIndex = 19;
            // 
            // address_field
            // 
            address_field.Location = new Point(176, 557);
            address_field.Name = "address_field";
            address_field.Size = new Size(188, 23);
            address_field.TabIndex = 20;
            // 
            // postal_code_field
            // 
            postal_code_field.Location = new Point(176, 593);
            postal_code_field.Name = "postal_code_field";
            postal_code_field.Size = new Size(188, 23);
            postal_code_field.TabIndex = 21;
            // 
            // account_number_field
            // 
            account_number_field.Location = new Point(176, 629);
            account_number_field.Name = "account_number_field";
            account_number_field.Size = new Size(188, 23);
            account_number_field.TabIndex = 22;
            // 
            // credit_card_field
            // 
            credit_card_field.Location = new Point(176, 701);
            credit_card_field.Name = "credit_card_field";
            credit_card_field.Size = new Size(188, 23);
            credit_card_field.TabIndex = 24;
            // 
            // average_rating_field
            // 
            average_rating_field.Location = new Point(176, 737);
            average_rating_field.Name = "average_rating_field";
            average_rating_field.ReadOnly = true;
            average_rating_field.Size = new Size(188, 23);
            average_rating_field.TabIndex = 25;
            // 
            // account_creation_picker
            // 
            account_creation_picker.Location = new Point(176, 665);
            account_creation_picker.Name = "account_creation_picker";
            account_creation_picker.Size = new Size(188, 23);
            account_creation_picker.TabIndex = 23;
            // 
            // load_customers_button
            // 
            load_customers_button.Location = new Point(828, 619);
            load_customers_button.Name = "load_customers_button";
            load_customers_button.Size = new Size(121, 40);
            load_customers_button.TabIndex = 26;
            load_customers_button.Text = "Load Customers";
            load_customers_button.UseVisualStyleBackColor = true;
            load_customers_button.Click += load_customers_button_Click;
            // 
            // add_customer_button
            // 
            add_customer_button.Location = new Point(967, 619);
            add_customer_button.Name = "add_customer_button";
            add_customer_button.Size = new Size(121, 40);
            add_customer_button.TabIndex = 27;
            add_customer_button.Text = "Add Customer";
            add_customer_button.UseVisualStyleBackColor = true;
            add_customer_button.Click += add_customer_button_Click;
            // 
            // update_customer_button
            // 
            update_customer_button.Location = new Point(829, 668);
            update_customer_button.Name = "update_customer_button";
            update_customer_button.Size = new Size(121, 40);
            update_customer_button.TabIndex = 28;
            update_customer_button.Text = "Update Customer";
            update_customer_button.UseVisualStyleBackColor = true;
            update_customer_button.Click += update_customer_button_Click;
            // 
            // delete_customer_button
            // 
            delete_customer_button.Location = new Point(967, 668);
            delete_customer_button.Name = "delete_customer_button";
            delete_customer_button.Size = new Size(121, 40);
            delete_customer_button.TabIndex = 29;
            delete_customer_button.Text = "Delete Customer";
            delete_customer_button.UseVisualStyleBackColor = true;
            delete_customer_button.Click += delete_customer_button_Click;
            // 
            // clear_button
            // 
            clear_button.Location = new Point(828, 720);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(121, 40);
            clear_button.TabIndex = 30;
            clear_button.Text = "Clear Fields";
            clear_button.UseVisualStyleBackColor = true;
            clear_button.Click += clear_button_Click;
            // 
            // back_button
            // 
            back_button.Location = new Point(1094, 761);
            back_button.Name = "back_button";
            back_button.Size = new Size(121, 40);
            back_button.TabIndex = 31;
            back_button.Text = "Back";
            back_button.UseVisualStyleBackColor = true;
            back_button.Click += back_button_Click;
            // 
            // search_first_label
            // 
            search_first_label.AutoSize = true;
            search_first_label.Location = new Point(36, 100);
            search_first_label.Name = "search_first_label";
            search_first_label.Size = new Size(64, 15);
            search_first_label.TabIndex = 6;
            search_first_label.Text = "First Name";
            // 
            // search_last_label
            // 
            search_last_label.AutoSize = true;
            search_last_label.Location = new Point(37, 144);
            search_last_label.Name = "search_last_label";
            search_last_label.Size = new Size(63, 15);
            search_last_label.TabIndex = 5;
            search_last_label.Text = "Last Name";
            // 
            // search_email_label
            // 
            search_email_label.AutoSize = true;
            search_email_label.Location = new Point(53, 182);
            search_email_label.Name = "search_email_label";
            search_email_label.Size = new Size(36, 15);
            search_email_label.TabIndex = 4;
            search_email_label.Text = "Email";
            // 
            // customer_search_first_field
            // 
            customer_search_first_field.Location = new Point(100, 97);
            customer_search_first_field.Name = "customer_search_first_field";
            customer_search_first_field.Size = new Size(120, 23);
            customer_search_first_field.TabIndex = 3;
            // 
            // customer_search_last_field
            // 
            customer_search_last_field.Location = new Point(100, 141);
            customer_search_last_field.Name = "customer_search_last_field";
            customer_search_last_field.Size = new Size(120, 23);
            customer_search_last_field.TabIndex = 2;
            // 
            // customer_search_email_field
            // 
            customer_search_email_field.Location = new Point(100, 179);
            customer_search_email_field.Name = "customer_search_email_field";
            customer_search_email_field.Size = new Size(180, 23);
            customer_search_email_field.TabIndex = 1;
            // 
            // search_customers_button
            // 
            search_customers_button.Location = new Point(100, 220);
            search_customers_button.Name = "search_customers_button";
            search_customers_button.Size = new Size(103, 28);
            search_customers_button.TabIndex = 0;
            search_customers_button.Text = "Search";
            search_customers_button.Click += search_customers_button_Click;
            // 
            // queue_label
            // 
            queue_label.AutoSize = true;
            queue_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            queue_label.Location = new Point(402, 384);
            queue_label.Name = "queue_label";
            queue_label.Size = new Size(137, 21);
            queue_label.TabIndex = 32;
            queue_label.Text = "Customer Queue";
            // 
            // history_label
            // 
            history_label.AutoSize = true;
            history_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            history_label.Location = new Point(402, 67);
            history_label.Name = "history_label";
            history_label.Size = new Size(113, 21);
            history_label.TabIndex = 33;
            history_label.Text = "Order History";
            // 
            // customer_queue_grid
            // 
            customer_queue_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customer_queue_grid.Location = new Point(402, 91);
            customer_queue_grid.Name = "customer_queue_grid";
            customer_queue_grid.Size = new Size(285, 290);
            customer_queue_grid.TabIndex = 34;
            // 
            // customer_history_grid
            // 
            customer_history_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customer_history_grid.Location = new Point(402, 412);
            customer_history_grid.Name = "customer_history_grid";
            customer_history_grid.Size = new Size(288, 276);
            customer_history_grid.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(64, 51);
            label1.Name = "label1";
            label1.Size = new Size(300, 37);
            label1.TabIndex = 36;
            label1.Text = "Search for a Customer";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(77, 325);
            label2.Name = "label2";
            label2.Size = new Size(237, 37);
            label2.TabIndex = 37;
            label2.Text = "Customer Details";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 828);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(search_customers_button);
            Controls.Add(customer_search_email_field);
            Controls.Add(customer_search_last_field);
            Controls.Add(customer_search_first_field);
            Controls.Add(search_email_label);
            Controls.Add(search_last_label);
            Controls.Add(search_first_label);
            Controls.Add(customer_history_grid);
            Controls.Add(customer_queue_grid);
            Controls.Add(history_label);
            Controls.Add(queue_label);
            Controls.Add(back_button);
            Controls.Add(clear_button);
            Controls.Add(delete_customer_button);
            Controls.Add(update_customer_button);
            Controls.Add(add_customer_button);
            Controls.Add(load_customers_button);
            Controls.Add(account_creation_picker);
            Controls.Add(average_rating_field);
            Controls.Add(credit_card_field);
            Controls.Add(account_number_field);
            Controls.Add(postal_code_field);
            Controls.Add(address_field);
            Controls.Add(province_field);
            Controls.Add(city_field);
            Controls.Add(email_field);
            Controls.Add(last_name_field);
            Controls.Add(first_name_field);
            Controls.Add(average_rating_label);
            Controls.Add(credit_card_label);
            Controls.Add(account_creation_label);
            Controls.Add(account_number_label);
            Controls.Add(postal_code_label);
            Controls.Add(address_label);
            Controls.Add(province_label);
            Controls.Add(city_label);
            Controls.Add(email_label);
            Controls.Add(last_name_label);
            Controls.Add(first_name_label);
            Controls.Add(controls_label);
            Controls.Add(customer_grid);
            Controls.Add(customer_title);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CustomerForm";
            Text = "CustomerForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customer_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)customer_queue_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)customer_history_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpOverviewToolStripMenuItem;
        private ToolStripMenuItem helpCustomersToolStripMenuItem;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
        private Label customer_title;
        private DataGridView customer_grid;
        private Label controls_label;
        private Label first_name_label;
        private Label last_name_label;
        private Label email_label;
        private Label city_label;
        private Label province_label;
        private Label address_label;
        private Label postal_code_label;
        private Label account_number_label;
        private Label account_creation_label;
        private Label credit_card_label;
        private Label average_rating_label;
        private TextBox first_name_field;
        private TextBox last_name_field;
        private TextBox email_field;
        private TextBox city_field;
        private TextBox province_field;
        private TextBox address_field;
        private TextBox postal_code_field;
        private TextBox account_number_field;
        private TextBox credit_card_field;
        private TextBox average_rating_field;
        private DateTimePicker account_creation_picker;
        private Button load_customers_button;
        private Button add_customer_button;
        private Button update_customer_button;
        private Button delete_customer_button;
        private Button clear_button;
        private Button back_button;
        private Label search_first_label;
        private Label search_last_label;
        private Label search_email_label;
        private TextBox customer_search_first_field;
        private TextBox customer_search_last_field;
        private TextBox customer_search_email_field;
        private Button search_customers_button;
        private Label queue_label;
        private Label history_label;
        private DataGridView customer_queue_grid;
        private DataGridView customer_history_grid;
        private Label label1;
        private Label label2;
    }
}
