using System;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaChatProducerUI
{
    public partial class Form1 : Form
    {
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnCancel;
        private Label lblPrompt;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtMessage = new TextBox();
            this.btnSend = new Button();
            this.btnCancel = new Button();
            this.lblPrompt = new Label();

            this.SuspendLayout();

            // Label
            this.lblPrompt.Text = "Please Enter your Message Here:";
            this.lblPrompt.Location = new System.Drawing.Point(50, 30);
            this.lblPrompt.AutoSize = true;

            // TextBox
            this.txtMessage.Multiline = true;
            this.txtMessage.Location = new System.Drawing.Point(50, 60);
            this.txtMessage.Size = new System.Drawing.Size(300, 150);

            // Send Button
            this.btnSend.Text = "Send";
            this.btnSend.Location = new System.Drawing.Point(200, 230);
            this.btnSend.Click += new EventHandler(this.BtnSend_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(100, 230);
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form Properties
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Text = "Kafka Chat Publisher (Form1)";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            // Connects to local Kafka Broker on port 9092
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    // Produces the message to the 'chat-message' topic
                    var result = await producer.ProduceAsync("chat-message", new Message<Null, string> { Value = txtMessage.Text });
                    MessageBox.Show($"Message Delivered Successfully!\nTopic: {result.TopicPartitionOffset}");
                    txtMessage.Clear();
                }
                catch (ProduceException<Null, string> ex)
                {
                    MessageBox.Show($"Delivery failed: {ex.Error.Reason}\n(Ensure Kafka Server is running!)", "Error");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
        }
    }
}
