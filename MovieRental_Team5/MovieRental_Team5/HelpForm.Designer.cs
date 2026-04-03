namespace MovieRental_Team5
{
    partial class HelpForm
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
            topic_list = new ListBox();
            help_content_box = new RichTextBox();
            selected_topic_label = new Label();
            SuspendLayout();
            // 
            // topic_list
            // 
            topic_list.Font = new Font("Segoe UI", 10F);
            topic_list.FormattingEnabled = true;
            topic_list.Location = new Point(12, 12);
            topic_list.Name = "topic_list";
            topic_list.Size = new Size(217, 412);
            topic_list.TabIndex = 0;
            topic_list.SelectedIndexChanged += topic_list_SelectedIndexChanged;
            // 
            // help_content_box
            // 
            help_content_box.Location = new Point(248, 52);
            help_content_box.Name = "help_content_box";
            help_content_box.ReadOnly = true;
            help_content_box.Size = new Size(540, 372);
            help_content_box.TabIndex = 1;
            help_content_box.Text = "";
            // 
            // selected_topic_label
            // 
            selected_topic_label.AutoSize = true;
            selected_topic_label.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            selected_topic_label.Location = new Point(445, 12);
            selected_topic_label.Name = "selected_topic_label";
            selected_topic_label.Size = new Size(173, 30);
            selected_topic_label.TabIndex = 2;
            selected_topic_label.Text = "Help Overview ";
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 438);
            Controls.Add(selected_topic_label);
            Controls.Add(help_content_box);
            Controls.Add(topic_list);
            Name = "HelpForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Help";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox topic_list;
        private RichTextBox help_content_box;
        private Label selected_topic_label;
    }
}
