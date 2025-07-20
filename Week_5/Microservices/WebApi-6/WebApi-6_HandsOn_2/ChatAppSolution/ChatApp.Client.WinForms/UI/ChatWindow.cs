using System;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms.UI
{
    public class ChatWindow : Form
    {
        private ListBox lstMessages;
        private TextBox txtMessage;
        private Button btnSend;

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lstMessages = new ListBox();
            this.txtMessage = new TextBox();
            this.btnSend = new Button();

            // ListBox
            this.lstMessages.Location = new System.Drawing.Point(12, 12);
            this.lstMessages.Size = new System.Drawing.Size(360, 300);

            // TextBox
            this.txtMessage.Location = new System.Drawing.Point(12, 320);
            this.txtMessage.Size = new System.Drawing.Size(280, 23);

            // Button
            this.btnSend.Location = new System.Drawing.Point(300, 320);
            this.btnSend.Size = new System.Drawing.Size(72, 23);
            this.btnSend.Text = "Send";
            this.btnSend.Click += BtnSend_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Text = "Chat Window";
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                lstMessages.Items.Add("Me: " + message);
                txtMessage.Clear();
                txtMessage.Focus();
                // TODO: Add logic to send message to Kafka or backend
            }
        }

        // TODO: Add method to receive messages and display in lstMessages
        public void AddReceivedMessage(string sender, string message)
        {
            lstMessages.Items.Add($"{sender}: {message}");
        }
    }
}
