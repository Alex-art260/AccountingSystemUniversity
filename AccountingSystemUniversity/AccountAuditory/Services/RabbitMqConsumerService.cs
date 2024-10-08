using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using AccountAuditory.Models;
using Newtonsoft.Json;
using AccountAuditory.Interfaces;
using AccountAuditory.Models.Dto;

namespace AccountAuditory.Services
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqConsumerService(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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
            var channel = connection.CreateModel();

            channel.QueueDeclare("auditoriesBuilding_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            List<Task> saveTasks = new List<Task>();

            var scope = _serviceProvider.CreateScope();
            var auditoryService = scope.ServiceProvider.GetRequiredService<IAuditoryService>();

            consumer.Received += async (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($"Received message: {message}");

                // Десериализация сообщения
                var buildingChange = JsonConvert.DeserializeObject<BuildingChange>(message);

                try
                {
                    // Обработка сообщения
                    switch (buildingChange.Action)
                    {
                        case "Create":
                        {
                            var newBuilding = new BuildingDto
                            {
                                Id = buildingChange.BuildingId,
                                Name = buildingChange.BuildingName
                            };

                            saveTasks.Add(Task.Run(async () =>
                            {
                                await auditoryService.Create(newBuilding);
                            }));
                            break;
                        }
                        case "Update":
                        {
                            var newBuilding = new BuildingDto
                            {
                                Id = buildingChange.BuildingId,
                                Name = buildingChange.BuildingName
                            };

                            saveTasks.Add(Task.Run(async () =>
                            {

                                await auditoryService.UpdateBuilding(newBuilding);
                            }));
                            break;
                        }
                        case "Delete":
                        {
                            saveTasks.Add(Task.Run(async () =>
                            {
                                await auditoryService.DeleteBuilding(buildingChange.BuildingId);
                            }));
                            break;
                        }


                    }
                    await Task.WhenAll(saveTasks);

                    // Подтвердите получение сообщения после успешного завершения всех задач
                   

                    saveTasks.Clear();
                }
                catch (Exception ex)
                {
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };


            channel.BasicConsume(queue: "auditoriesBuilding_queue", autoAck: false, consumer: consumer);

            // Дождитесь отмены токена
            await Task.Delay(-1, stoppingToken);

        }
    }

}
