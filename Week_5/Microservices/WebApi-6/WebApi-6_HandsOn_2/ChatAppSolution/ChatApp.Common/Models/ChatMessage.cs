using System;
using System.Text.Json;

namespace ChatApp.Common.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static ChatMessage FromJson(string json)
        {
            return JsonSerializer.Deserialize<ChatMessage>(json);
        }
    }
}
