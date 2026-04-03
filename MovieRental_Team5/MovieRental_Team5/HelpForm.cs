using System;
using System.Windows.Forms;

namespace MovieRental_Team5
{
    public partial class HelpForm : Form
    {
        public HelpForm(string topic)
        {
            InitializeComponent();
            LoadTopics();
            ShowTopic(topic);
        }

        private void LoadTopics()
        {
            topic_list.Items.Clear();

            foreach (string topic in HelpTopics.AllTopics)
            {
                topic_list.Items.Add(topic);
            }
        }

        public void ShowTopic(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                topic = HelpTopics.GettingStarted;
            }

            selected_topic_label.Text = topic;
            help_content_box.Text = HelpTopics.GetContent(topic);
            int topicIndex = topic_list.Items.IndexOf(topic);

            if (topicIndex >= 0)
            {
                topic_list.SelectedIndex = topicIndex;
            }
            else if (topic_list.Items.Count > 0 && topic_list.SelectedIndex == -1)
            {
                topic_list.SelectedIndex = 0;
            }
        }

        private void topic_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (topic_list.SelectedItem is string topic)
            {
                selected_topic_label.Text = topic;
                help_content_box.Text = HelpTopics.GetContent(topic);
            }
        }
    }
}
