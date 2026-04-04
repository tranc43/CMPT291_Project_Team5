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
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customer_grid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
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
            helpOverviewToolStripMenuItem.Size = new Size(199, 22);
            helpOverviewToolStripMenuItem.Text = "Getting Started";
            helpOverviewToolStripMenuItem.Click += helpOverviewToolStripMenuItem_Click;
            // 
            // helpCustomersToolStripMenuItem
            // 
            helpCustomersToolStripMenuItem.Name = "helpCustomersToolStripMenuItem";
            helpCustomersToolStripMenuItem.Size = new Size(199, 22);
            helpCustomersToolStripMenuItem.Text = "Customer Management";
            helpCustomersToolStripMenuItem.Click += helpCustomersToolStripMenuItem_Click;
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.Size = new Size(199, 22);
            helpAboutToolStripMenuItem.Text = "About";
            helpAboutToolStripMenuItem.Click += helpAboutToolStripMenuItem_Click;
            // 
            // customer_title
            // 
            customer_title.AutoSize = true;
            customer_title.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            customer_title.Location = new Point(381, 30);
            customer_title.Name = "customer_title";
            customer_title.Size = new Size(279, 37);
            customer_title.TabIndex = 1;
            customer_title.Text = "Customer Dashboard";
            // 
            // customer_grid
            // 
            customer_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customer_grid.Location = new Point(20, 110);
            customer_grid.Name = "customer_grid";
            customer_grid.Size = new Size(519, 492);
            customer_grid.TabIndex = 2;
            customer_grid.CellClick += customer_grid_CellClick;
            // 
            // controls_label
            // 
            controls_label.AutoSize = true;
            controls_label.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            controls_label.Location = new Point(715, 78);
            controls_label.Name = "controls_label";
            controls_label.Size = new Size(102, 32);
            controls_label.TabIndex = 3;
            controls_label.Text = "Controls";
            // 
            // labels
            // 
            first_name_label.AutoSize = true;
            first_name_label.Location = new Point(575, 126);
            first_name_label.Name = "first_name_label";
            first_name_label.Size = new Size(64, 15);
            first_name_label.TabIndex = 4;
            first_name_label.Text = "First Name";
            last_name_label.AutoSize = true;
            last_name_label.Location = new Point(575, 162);
            last_name_label.Name = "last_name_label";
            last_name_label.Size = new Size(63, 15);
            last_name_label.TabIndex = 5;
            last_name_label.Text = "Last Name";
            email_label.AutoSize = true;
            email_label.Location = new Point(575, 198);
            email_label.Name = "email_label";
            email_label.Size = new Size(82, 15);
            email_label.TabIndex = 6;
            email_label.Text = "Email Address";
            city_label.AutoSize = true;
            city_label.Location = new Point(575, 234);
            city_label.Name = "city_label";
            city_label.Size = new Size(28, 15);
            city_label.TabIndex = 7;
            city_label.Text = "City";
            province_label.AutoSize = true;
            province_label.Location = new Point(575, 270);
            province_label.Name = "province_label";
            province_label.Size = new Size(53, 15);
            province_label.TabIndex = 8;
            province_label.Text = "Province";
            address_label.AutoSize = true;
            address_label.Location = new Point(575, 306);
            address_label.Name = "address_label";
            address_label.Size = new Size(49, 15);
            address_label.TabIndex = 9;
            address_label.Text = "Address";
            postal_code_label.AutoSize = true;
            postal_code_label.Location = new Point(575, 342);
            postal_code_label.Name = "postal_code_label";
            postal_code_label.Size = new Size(68, 15);
            postal_code_label.TabIndex = 10;
            postal_code_label.Text = "Postal Code";
            account_number_label.AutoSize = true;
            account_number_label.Location = new Point(575, 378);
            account_number_label.Name = "account_number_label";
            account_number_label.Size = new Size(94, 15);
            account_number_label.TabIndex = 11;
            account_number_label.Text = "Account Number";
            account_creation_label.AutoSize = true;
            account_creation_label.Location = new Point(575, 414);
            account_creation_label.Name = "account_creation_label";
            account_creation_label.Size = new Size(124, 15);
            account_creation_label.TabIndex = 12;
            account_creation_label.Text = "Account Creation Date";
            credit_card_label.AutoSize = true;
            credit_card_label.Location = new Point(575, 450);
            credit_card_label.Name = "credit_card_label";
            credit_card_label.Size = new Size(104, 15);
            credit_card_label.TabIndex = 13;
            credit_card_label.Text = "Credit Card Number";
            average_rating_label.AutoSize = true;
            average_rating_label.Location = new Point(575, 486);
            average_rating_label.Name = "average_rating_label";
            average_rating_label.Size = new Size(87, 15);
            average_rating_label.TabIndex = 14;
            average_rating_label.Text = "Average Rating";
            // 
            // text boxes
            // 
            first_name_field.Location = new Point(721, 123);
            first_name_field.Name = "first_name_field";
            first_name_field.Size = new Size(188, 23);
            first_name_field.TabIndex = 15;
            last_name_field.Location = new Point(721, 159);
            last_name_field.Name = "last_name_field";
            last_name_field.Size = new Size(188, 23);
            last_name_field.TabIndex = 16;
            email_field.Location = new Point(721, 195);
            email_field.Name = "email_field";
            email_field.Size = new Size(188, 23);
            email_field.TabIndex = 17;
            city_field.Location = new Point(721, 231);
            city_field.Name = "city_field";
            city_field.Size = new Size(188, 23);
            city_field.TabIndex = 18;
            province_field.Location = new Point(721, 267);
            province_field.Name = "province_field";
            province_field.Size = new Size(188, 23);
            province_field.TabIndex = 19;
            address_field.Location = new Point(721, 303);
            address_field.Name = "address_field";
            address_field.Size = new Size(188, 23);
            address_field.TabIndex = 20;
            postal_code_field.Location = new Point(721, 339);
            postal_code_field.Name = "postal_code_field";
            postal_code_field.Size = new Size(188, 23);
            postal_code_field.TabIndex = 21;
            account_number_field.Location = new Point(721, 375);
            account_number_field.Name = "account_number_field";
            account_number_field.Size = new Size(188, 23);
            account_number_field.TabIndex = 22;
            credit_card_field.Location = new Point(721, 447);
            credit_card_field.Name = "credit_card_field";
            credit_card_field.Size = new Size(188, 23);
            credit_card_field.TabIndex = 24;
            average_rating_field.Location = new Point(721, 483);
            average_rating_field.Name = "average_rating_field";
            average_rating_field.ReadOnly = true;
            average_rating_field.Size = new Size(188, 23);
            average_rating_field.TabIndex = 25;
            // 
            // account_creation_picker
            // 
            account_creation_picker.Location = new Point(721, 411);
            account_creation_picker.Name = "account_creation_picker";
            account_creation_picker.Size = new Size(188, 23);
            account_creation_picker.TabIndex = 23;
            // 
            // buttons
            // 
            load_customers_button.Location = new Point(575, 545);
            load_customers_button.Name = "load_customers_button";
            load_customers_button.Size = new Size(121, 40);
            load_customers_button.TabIndex = 26;
            load_customers_button.Text = "Load Customers";
            load_customers_button.UseVisualStyleBackColor = true;
            load_customers_button.Click += load_customers_button_Click;
            add_customer_button.Location = new Point(714, 545);
            add_customer_button.Name = "add_customer_button";
            add_customer_button.Size = new Size(121, 40);
            add_customer_button.TabIndex = 27;
            add_customer_button.Text = "Add Customer";
            add_customer_button.UseVisualStyleBackColor = true;
            add_customer_button.Click += add_customer_button_Click;
            update_customer_button.Location = new Point(852, 545);
            update_customer_button.Name = "update_customer_button";
            update_customer_button.Size = new Size(121, 40);
            update_customer_button.TabIndex = 28;
            update_customer_button.Text = "Update Customer";
            update_customer_button.UseVisualStyleBackColor = true;
            update_customer_button.Click += update_customer_button_Click;
            delete_customer_button.Location = new Point(990, 545);
            delete_customer_button.Name = "delete_customer_button";
            delete_customer_button.Size = new Size(121, 40);
            delete_customer_button.TabIndex = 29;
            delete_customer_button.Text = "Delete Customer";
            delete_customer_button.UseVisualStyleBackColor = true;
            delete_customer_button.Click += delete_customer_button_Click;
            clear_button.Location = new Point(990, 123);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(121, 40);
            clear_button.TabIndex = 30;
            clear_button.Text = "Clear Fields";
            clear_button.UseVisualStyleBackColor = true;
            clear_button.Click += clear_button_Click;
            back_button.Location = new Point(990, 178);
            back_button.Name = "back_button";
            back_button.Size = new Size(121, 40);
            back_button.TabIndex = 31;
            back_button.Text = "Back";
            back_button.UseVisualStyleBackColor = true;
            back_button.Click += back_button_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 626);
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
    }
}
