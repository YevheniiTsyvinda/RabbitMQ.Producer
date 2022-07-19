using RabbitMQ.Client;
using System.Text;
using System.Text.Json;


const string _rabbitMQURL = "amqp://guest:guest@localhost:5672";
const string _queueName = "demo-queue";


var factory = new ConnectionFactory
{
    Uri = new Uri(_rabbitMQURL)
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(_queueName,
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var message = new { Name = "Producer", Message = "Holla!" };
var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

channel.BasicPublish("", _queueName, null, body);