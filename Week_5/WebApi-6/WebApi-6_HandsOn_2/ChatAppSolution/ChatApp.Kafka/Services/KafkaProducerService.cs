using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace ChatApp.Kafka.Services
{
    public class KafkaProducerService : IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;
        private bool _disposed;

        public KafkaProducerService(string bootstrapServers, string topic)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
            _topic = topic;
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
            }
            catch (Exception ex)
            {
                // Log or handle error as needed
                throw new ApplicationException("Failed to send message to Kafka.", ex);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _producer?.Dispose();
                _disposed = true;
            }
        }
    }
}
