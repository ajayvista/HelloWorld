using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using RabbitMQ.Client;

namespace Producer.BrokerProxy
{
    /// <summary>
    /// Base producer, can be extended based on exchange and message type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class BaseProducer<T,K>:IProducer<T,K>  where T : class where K : Enum
    {
        private readonly IConnection _connection;
        private readonly IModel _channelModel;
        private readonly string _exchange;

        /// <summary>
        /// Inject all dependencies required for the constructor
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="factory"></param>
        public BaseProducer(ILogger<BaseProducer<T,K>> _logger, K exchangeName, ConnectionFactory factory )
        {
            _exchange = Extensions.EnumDescription<K>(exchangeName);
            _connection = factory.CreateConnection();
            _channelModel = _connection.CreateModel();
        }

        /// <summary>
        /// Produce T type message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Produce(T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channelModel.BasicPublish(exchange: _exchange,
                        routingKey: "",
                        basicProperties: null,
                        body: body);
        
            return true;
        }
    }
}