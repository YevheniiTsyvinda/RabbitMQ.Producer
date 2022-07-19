using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    internal static class Constants
    {
       internal const string _rabbitMQURL = "amqp://guest:guest@localhost:5672";
       internal const string _queueName = "demo-queue";
       internal const string _directExchange = "demo-direct-exchange";
        internal const string _accountInit = "account.init";

    }
}
