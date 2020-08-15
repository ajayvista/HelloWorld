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
    /// Producer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public interface IProducer<T,K>
    {
        /// <summary>
        /// A method which takes T type and produce 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Produce(T message);
    }
}