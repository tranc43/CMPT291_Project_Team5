namespace MovieRental_Team5
{
    partial class OrderForm
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
            dataGridView1 = new DataGridView();
            OrderTitle = new Label();
            checkout_date = new DateTimePicker();
            checkout_time = new DateTimePicker();
            back_button = new Button();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            select_customer_label = new Label();
            label2 = new Label();
            current_orders_label = new Label();
            checkout_label = new Label();
            date_label = new Label();
            time_label = new Label();
            label3 = new Label();
            label4 = new Label();
            return_label = new Label();
            return_date = new DateTimePicker();
            return_time = new DateTimePicker();
            record_order_button = new Button();
            button1 = new Button();
            employee_ID_label = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(372, 535);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // OrderTitle
            // 
            OrderTitle.AutoSize = true;
            OrderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            OrderTitle.Location = new Point(616, 61);
            OrderTitle.Name = "OrderTitle";
            OrderTitle.Size = new Size(167, 32);
            OrderTitle.TabIndex = 1;
            OrderTitle.Text = "Record Order";
            // 
            // checkout_date
            // 
            checkout_date.Format = DateTimePickerFormat.Time;
            checkout_date.Location = new Point(486, 372);
            checkout_date.Name = "checkout_date";
            checkout_date.ShowUpDown = true;
            checkout_date.Size = new Size(200, 23);
            checkout_date.TabIndex = 2;
            // 
            // checkout_time
            // 
            checkout_time.Location = new Point(486, 331);
            checkout_time.Name = "checkout_time";
            checkout_time.Size = new Size(200, 23);
            checkout_time.TabIndex = 3;
            checkout_time.Value = new DateTime(2026, 3, 31, 15, 29, 54, 0);
            // 
            // back_button
            // 
            back_button.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            back_button.Location = new Point(894, 562);
            back_button.Name = "back_button";
            back_button.Size = new Size(123, 58);
            back_button.TabIndex = 4;
            back_button.Text = "back";
            back_button.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(470, 160);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(138, 23);
            comboBox2.TabIndex = 6;
            comboBox2.Text = "Select Customer ID";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(789, 160);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 7;
            comboBox3.Text = "Select Movie";
            // 
            // select_customer_label
            // 
            select_customer_label.AutoSize = true;
            select_customer_label.FlatStyle = FlatStyle.Flat;
            select_customer_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            select_customer_label.Location = new Point(443, 129);
            select_customer_label.Name = "select_customer_label";
            select_customer_label.Size = new Size(165, 28);
            select_customer_label.TabIndex = 8;
            select_customer_label.Text = "Select Customer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(782, 129);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 9;
            label2.Text = "Select Movie";
            // 
            // current_orders_label
            // 
            current_orders_label.AutoSize = true;
            current_orders_label.FlatStyle = FlatStyle.Flat;
            current_orders_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            current_orders_label.Location = new Point(125, 65);
            current_orders_label.Name = "current_orders_label";
            current_orders_label.Size = new Size(152, 28);
            current_orders_label.TabIndex = 10;
            current_orders_label.Text = "Current Orders";
            // 
            // checkout_label
            // 
            checkout_label.AutoSize = true;
            checkout_label.FlatStyle = FlatStyle.Flat;
            checkout_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            checkout_label.Location = new Point(443, 278);
            checkout_label.Name = "checkout_label";
            checkout_label.Size = new Size(205, 37);
            checkout_label.TabIndex = 11;
            checkout_label.Text = "Checkout Date";
            // 
            // date_label
            // 
            date_label.AutoSize = true;
            date_label.FlatStyle = FlatStyle.Flat;
            date_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            date_label.Location = new Point(418, 326);
            date_label.Name = "date_label";
            date_label.Size = new Size(62, 28);
            date_label.TabIndex = 12;
            date_label.Text = "Date:";
            // 
            // time_label
            // 
            time_label.AutoSize = true;
            time_label.FlatStyle = FlatStyle.Flat;
            time_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            time_label.Location = new Point(416, 367);
            time_label.Name = "time_label";
            time_label.Size = new Size(64, 28);
            time_label.TabIndex = 13;
            time_label.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(712, 367);
            label3.Name = "label3";
            label3.Size = new Size(64, 28);
            label3.TabIndex = 18;
            label3.Text = "Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.Location = new Point(714, 326);
            label4.Name = "label4";
            label4.Size = new Size(62, 28);
            label4.TabIndex = 17;
            label4.Text = "Date:";
            // 
            // return_label
            // 
            return_label.AutoSize = true;
            return_label.FlatStyle = FlatStyle.Flat;
            return_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            return_label.Location = new Point(739, 278);
            return_label.Name = "return_label";
            return_label.Size = new Size(171, 37);
            return_label.TabIndex = 16;
            return_label.Text = "Return Date";
            // 
            // return_date
            // 
            return_date.Location = new Point(782, 331);
            return_date.Name = "return_date";
            return_date.Size = new Size(200, 23);
            return_date.TabIndex = 15;
            return_date.Value = new DateTime(2026, 3, 31, 8, 29, 25, 0);
            // 
            // return_time
            // 
            return_time.Format = DateTimePickerFormat.Time;
            return_time.Location = new Point(782, 372);
            return_time.Name = "return_time";
            return_time.ShowUpDown = true;
            return_time.Size = new Size(200, 23);
            return_time.TabIndex = 14;
            // 
            // record_order_button
            // 
            record_order_button.Font = new Font("Segoe UI", 15F);
            record_order_button.Location = new Point(486, 425);
            record_order_button.Name = "record_order_button";
            record_order_button.Size = new Size(185, 58);
            record_order_button.TabIndex = 19;
            record_order_button.Text = "record order";
            record_order_button.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(782, 425);
            button1.Name = "button1";
            button1.Size = new Size(185, 58);
            button1.TabIndex = 20;
            button1.Text = "clear order";
            button1.UseVisualStyleBackColor = true;
            // 
            // employee_ID_label
            // 
            employee_ID_label.AutoSize = true;
            employee_ID_label.FlatStyle = FlatStyle.Flat;
            employee_ID_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            employee_ID_label.Location = new Point(28, 9);
            employee_ID_label.Name = "employee_ID_label";
            employee_ID_label.Size = new Size(131, 28);
            employee_ID_label.TabIndex = 21;
            employee_ID_label.Text = "Employee ID";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 643);
            Controls.Add(employee_ID_label);
            Controls.Add(button1);
            Controls.Add(record_order_button);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(return_label);
            Controls.Add(return_date);
            Controls.Add(return_time);
            Controls.Add(time_label);
            Controls.Add(date_label);
            Controls.Add(checkout_label);
            Controls.Add(current_orders_label);
            Controls.Add(label2);
            Controls.Add(select_customer_label);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(back_button);
            Controls.Add(checkout_time);
            Controls.Add(checkout_date);
            Controls.Add(OrderTitle);
            Controls.Add(dataGridView1);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label OrderTitle;
        private DateTimePicker checkout_date;
        private DateTimePicker checkout_time;
        private Button back_button;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label select_customer_label;
        private Label label2;
        private Label current_orders_label;
        private Label checkout_label;
        private Label date_label;
        private Label time_label;
        private Label label3;
        private Label label4;
        private Label return_label;
        private DateTimePicker return_date;
        private DateTimePicker return_time;
        private Button record_order_button;
        private Button button1;
        private Label employee_ID_label;
    }
}