using Confluent.Kafka;
using ChatApp.Common.Models;
using System.Text.Json;

namespace ChatApp.Consumer.Services
{
    public class KafkaConsumerService
    {
        public void Run()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("chat-topic");
                Console.WriteLine("Listening for chat messages. Press Ctrl+C to exit.");

                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume();
                        var chatMessage = JsonSerializer.Deserialize<ChatMessage>(consumeResult.Message.Value);
                        Console.WriteLine($"[{chatMessage.Timestamp:HH:mm:ss}] {chatMessage.Sender}: {chatMessage.Message}");
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }
    }
}
