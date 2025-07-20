namespace ChatApp.Kafka.Interfaces
{
    public interface IKafkaConsumerCallback
    {
        void OnMessageReceived(string message);
    }
}
