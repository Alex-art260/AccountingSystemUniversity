using RabbitMQ.Client;
using static AccountingSystemUniversity.Services.RabbitMqService;
using System.Text;
using AccountingSystemUniversity.Interfaces;

namespace AccountingSystemUniversity.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PublishMessage(string message, string queueName)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _configuration.GetValue<string>("RabbitMq:HostName"),
                Port = _configuration.GetValue<int>("RabbitMq:Port"),
                UserName = _configuration.GetValue<string>("RabbitMq:UserName"),
                Password = _configuration.GetValue<string>("RabbitMq:Password"),
                VirtualHost = _configuration.GetValue<string>("RabbitMq:VirtualHost")
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
        }
    }
    
}
