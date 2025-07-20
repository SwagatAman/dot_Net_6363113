using ChatApp.Producer.Services;

namespace ChatApp.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'send' to produce messages or 'receive' to consume messages:");
            var mode = Console.ReadLine()?.Trim().ToLower();

            if (mode == "send")
            {
                var producer = new KafkaProducerService();
                producer.Run();
            }
            else if (mode == "receive")
            {
                var consumer = new KafkaConsumerService();
                consumer.Run();
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
