using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQ.Producer;

internal class QueueProducer
{
    internal static void Publish(IModel channel)
    {
        channel.QueueDeclare(Constants._rabbitMQURL,
        durable: true,
        exclusive: false,
        autoDelete: false,
        arguments: null);

        var count = 0;
        while (true)
        {
            var message = new { Name = "Producer", Message = count.ToString() };
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish("", Constants._queueName, null, body);
            count++;
            //Thread.Sleep(1000);
        }

        
    }
}
