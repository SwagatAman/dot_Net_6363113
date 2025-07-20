using System;
using System.Windows.Forms;
using ChatApp.Common.Models;
using ChatApp.Kafka.Services;
using ChatApp.Kafka.Interfaces;
using System.Configuration;

namespace ChatApp.Client.WinForms
{
    public partial class Form1 : Form, IKafkaConsumerCallback
    {
        private KafkaProducerService _producer;
        private KafkaConsumerService _consumer;

        private TextBox txtSender;
        private TextBox txtMessage;
        private Button btnSend;
        private ListBox lstChat;

        public Form1()
        {
            InitializeComponent();
            InitializeChatControls();

            var bootstrapServers = ConfigurationManager.AppSettings["KafkaBootstrapServers"];
            var topic = ConfigurationManager.AppSettings["KafkaTopic"];
            var groupId = Guid.NewGuid().ToString();

            _producer = new KafkaProducerService(bootstrapServers, topic);
            _consumer = new KafkaConsumerService(bootstrapServers, topic, groupId, this);
            _consumer.Start();
        }

        private void InitializeChatControls()
        {
            txtSender = new TextBox { Left = 10, Top = 10, Width = 150, PlaceholderText = "Sender" };
            txtMessage = new TextBox { Left = 170, Top = 10, Width = 400, PlaceholderText = "Message" };
            btnSend = new Button { Left = 580, Top = 10, Width = 80, Text = "Send" };
            lstChat = new ListBox { Left = 10, Top = 40, Width = 650, Height = 370 };

            btnSend.Click += BtnSend_Click;

            Controls.Add(txtSender);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(lstChat);
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSender.Text) || string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            var chatMsg = new ChatMessage
            {
                Sender = txtSender.Text,
                Message = txtMessage.Text,
                Timestamp = DateTime.Now
            };
            try
            {
                await _producer.SendMessageAsync(chatMsg.ToJson());
                txtMessage.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnMessageReceived(string message)
        {
            ChatMessage chatMsg;
            try
            {
                chatMsg = ChatMessage.FromJson(message);
            }
            catch
            {
                // Ignore malformed messages
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddMessageToList(chatMsg)));
            }
            else
            {
                AddMessageToList(chatMsg);
            }
        }

        private void AddMessageToList(ChatMessage chatMsg)
        {
            lstChat.Items.Add($"{chatMsg.Timestamp:HH:mm:ss} {chatMsg.Sender}: {chatMsg.Message}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _consumer.Stop();
            _producer.Dispose();
            _consumer.Dispose();
            base.OnFormClosing(e);
        }
    }
}
