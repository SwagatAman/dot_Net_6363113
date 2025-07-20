using Confluent.Kafka;
using ChatApp.Common.Models;
using System.Text.Json;

namespace ChatApp.Producer.Services
{
    public class KafkaProducerService
    {
        public void Run()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("Enter your name:");
                var sender = Console.ReadLine();

                Console.WriteLine("Type your messages. Enter 'exit' to quit.");
                while (true)
                {
                    var messageText = Console.ReadLine();
                    if (messageText?.ToLower() == "exit")
                        break;

                    var chatMessage = new ChatMessage
                    {
                        Sender = sender,
                        Message = messageText,
                        Timestamp = DateTime.Now
                    };

                    var json = JsonSerializer.Serialize(chatMessage);
                    producer.Produce("chat-topic", new Message<Null, string> { Value = json });
                }
            }
        }
    }
}
