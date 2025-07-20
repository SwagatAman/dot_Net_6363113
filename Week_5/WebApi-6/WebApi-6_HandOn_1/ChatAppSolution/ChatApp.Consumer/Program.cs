using ChatApp.Consumer.Services;

namespace ChatApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point for Kafka Consumer
            var consumer = new KafkaConsumerService();
            consumer.Run();
        }
    }
}
