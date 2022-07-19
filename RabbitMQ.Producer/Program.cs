using RabbitMQ.Client;
using RabbitMQ.Producer;
using System.Text;
using System.Text.Json;





var factory = new ConnectionFactory
{
    Uri = new Uri(RabbitMQ.Producer.Constants._rabbitMQURL)
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
DirectExchangePublisher.Publish(channel);