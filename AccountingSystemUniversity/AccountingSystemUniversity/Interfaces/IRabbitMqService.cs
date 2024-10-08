namespace AccountingSystemUniversity.Interfaces
{
    public interface IRabbitMqService
    {
        void PublishMessage(string message, string queueName);
    }
}
