namespace MovieRental_Team5
{
    partial class Reports_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            title_label = new Label();
            report_selector = new ComboBox();
            run_report_button = new Button();
            back_button = new Button();
            report_grid = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)report_grid).BeginInit();
            SuspendLayout();
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            title_label.Location = new Point(444, 57);
            title_label.Name = "title_label";
            title_label.Size = new Size(118, 37);
            title_label.TabIndex = 4;
            title_label.Text = "Reports";
            // 
            // report_selector
            // 
            report_selector.DropDownStyle = ComboBoxStyle.DropDownList;
            report_selector.Items.AddRange(new object[] { "Monthly Revenue", "Top 3 Most Rented Movies", "Top 3 Employees By Revenue", "Top 3 Actors", "Top 3 Most Active Customers" });
            report_selector.Location = new Point(31, 199);
            report_selector.Name = "report_selector";
            report_selector.Size = new Size(272, 23);
            report_selector.TabIndex = 3;
            // 
            // run_report_button
            // 
            run_report_button.Location = new Point(105, 252);
            run_report_button.Name = "run_report_button";
            run_report_button.Size = new Size(106, 30);
            run_report_button.TabIndex = 2;
            run_report_button.Text = "Run Report";
            run_report_button.Click += run_report_button_Click;
            // 
            // back_button
            // 
            back_button.Location = new Point(502, 498);
            back_button.Name = "back_button";
            back_button.Size = new Size(90, 30);
            back_button.TabIndex = 1;
            back_button.Text = "Back";
            back_button.Click += back_button_Click;
            // 
            // report_grid
            // 
            report_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            report_grid.Location = new Point(360, 121);
            report_grid.Name = "report_grid";
            report_grid.Size = new Size(285, 351);
            report_grid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(42, 132);
            label1.Name = "label1";
            label1.Size = new Size(184, 37);
            label1.TabIndex = 6;
            label1.Text = "Find a report";
            // 
            // Reports_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 565);
            Controls.Add(label1);
            Controls.Add(report_grid);
            Controls.Add(back_button);
            Controls.Add(run_report_button);
            Controls.Add(report_selector);
            Controls.Add(title_label);
            Name = "Reports_Form";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)report_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label title_label;
        private ComboBox report_selector;
        private Button run_report_button;
        private Button back_button;
        private DataGridView report_grid;
        private Label label1;
    }
}
