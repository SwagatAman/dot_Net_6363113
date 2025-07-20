using Confluent.Kafka;

namespace ChatApp.Producer.Services
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
                        Console.WriteLine($"Received: {consumeResult.Message.Value}");
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
