namespace MovieRental_Team5
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpOverviewToolStripMenuItem = new ToolStripMenuItem();
            helpReportsToolStripMenuItem = new ToolStripMenuItem();
            helpAboutToolStripMenuItem = new ToolStripMenuItem();
            title_label = new Label();
            report_selector = new ComboBox();
            run_report_button = new Button();
            back_button = new Button();
            report_grid = new DataGridView();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)report_grid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 546);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(950, 24);
            menuStrip1.TabIndex = 5;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpOverviewToolStripMenuItem, helpReportsToolStripMenuItem, helpAboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpOverviewToolStripMenuItem
            // 
            helpOverviewToolStripMenuItem.Name = "helpOverviewToolStripMenuItem";
            helpOverviewToolStripMenuItem.Size = new Size(180, 22);
            helpOverviewToolStripMenuItem.Text = "Getting Started";
            helpOverviewToolStripMenuItem.Click += helpOverviewToolStripMenuItem_Click;
            // 
            // helpReportsToolStripMenuItem
            // 
            helpReportsToolStripMenuItem.Name = "helpReportsToolStripMenuItem";
            helpReportsToolStripMenuItem.Size = new Size(180, 22);
            helpReportsToolStripMenuItem.Text = "Reports";
            helpReportsToolStripMenuItem.Click += helpReportsToolStripMenuItem_Click;
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.Size = new Size(180, 22);
            helpAboutToolStripMenuItem.Text = "About";
            helpAboutToolStripMenuItem.Click += helpAboutToolStripMenuItem_Click;
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            title_label.Location = new Point(369, 33);
            title_label.Name = "title_label";
            title_label.Size = new Size(118, 37);
            title_label.TabIndex = 4;
            title_label.Text = "Reports";
            // 
            // report_selector
            // 
            report_selector.DropDownStyle = ComboBoxStyle.DropDownList;
            report_selector.Items.AddRange(new object[] { "Best-Seller Movies", "Top Customers By Orders", "Active Rentals By Movie", "Actors Appearing Most Often", "Customer Queue Sizes" });
            report_selector.Location = new Point(211, 472);
            report_selector.Name = "report_selector";
            report_selector.Size = new Size(272, 23);
            report_selector.TabIndex = 3;
            // 
            // run_report_button
            // 
            run_report_button.Location = new Point(489, 467);
            run_report_button.Name = "run_report_button";
            run_report_button.Size = new Size(106, 30);
            run_report_button.TabIndex = 2;
            run_report_button.Text = "Run Report";
            run_report_button.Click += run_report_button_Click;
            // 
            // back_button
            // 
            back_button.Location = new Point(848, 503);
            back_button.Name = "back_button";
            back_button.Size = new Size(90, 30);
            back_button.TabIndex = 1;
            back_button.Text = "Back";
            back_button.Click += back_button_Click;
            // 
            // report_grid
            // 
            report_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            report_grid.Location = new Point(22, 73);
            report_grid.Name = "report_grid";
            report_grid.Size = new Size(769, 370);
            report_grid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(22, 460);
            label1.Name = "label1";
            label1.Size = new Size(184, 37);
            label1.TabIndex = 6;
            label1.Text = "Find a report";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 570);
            Controls.Add(label1);
            Controls.Add(report_grid);
            Controls.Add(back_button);
            Controls.Add(run_report_button);
            Controls.Add(report_selector);
            Controls.Add(title_label);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ReportsForm";
            Text = "ReportsForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)report_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpOverviewToolStripMenuItem;
        private ToolStripMenuItem helpReportsToolStripMenuItem;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
        private Label title_label;
        private ComboBox report_selector;
        private Button run_report_button;
        private Button back_button;
        private DataGridView report_grid;
        private Label label1;
    }
}
