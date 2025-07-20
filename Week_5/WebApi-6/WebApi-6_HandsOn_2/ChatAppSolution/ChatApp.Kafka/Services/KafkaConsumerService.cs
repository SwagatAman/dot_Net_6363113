using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using ChatApp.Kafka.Interfaces;

namespace ChatApp.Kafka.Services
{
    public class KafkaConsumerService : IDisposable
    {
        private readonly IConsumer<Null, string> _consumer;
        private readonly string _topic;
        private readonly IKafkaConsumerCallback _callback;
        private CancellationTokenSource _cts;
        private bool _disposed;

        public KafkaConsumerService(string bootstrapServers, string topic, string groupId, IKafkaConsumerCallback callback)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Null, string>(config).Build();
            _topic = topic;
            _callback = callback;
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                _consumer.Subscribe(_topic);
                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        try
                        {
                            var cr = _consumer.Consume(_cts.Token);
                            _callback.OnMessageReceived(cr.Message.Value);
                        }
                        catch (ConsumeException ex)
                        {
                            // Log or handle consume error
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected on cancellation
                }
            }, _cts.Token);
        }

        public void Stop()
        {
            _cts?.Cancel();
            _consumer.Close();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _consumer?.Dispose();
                _cts?.Dispose();
                _disposed = true;
            }
        }
    }
}
