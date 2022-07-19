using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQ.Producer;

internal class HeaderExchangePublisher
{
    public static void Publish(IModel channel)
    {
        var ttl = new Dictionary<string, object>
        {
            {"x-message-ttl",30000 }//ttl - time to live
        };

        channel.ExchangeDeclare(Constants._headerExchange, ExchangeType.Headers, arguments: ttl);

        var count = 0;
        while (true)
        {
            var message = new { Name = "Producer", Message = count.ToString() };
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            var properties = channel.CreateBasicProperties();
            properties.Headers = new Dictionary<string, object> { { "account", "update" } };

            channel.BasicPublish(Constants._headerExchange, String.Empty, properties, body);
            count++;
            Thread.Sleep(1000);
        }
    }
}
