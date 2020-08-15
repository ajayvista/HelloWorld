using System.Runtime.Serialization;
using System.ComponentModel;
using System;
using System.Text;
using RabbitMQ.Client;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
public interface IConsumer<T>
{
    public string Register(Action<T> subcriber);
}

public class Consumer<T>:IConsumer<T> where T : class
{

    private readonly IConnection _connection;
    private readonly IModel _channelModel;
    private string _exchange;
    private string _queueName;
    public Consumer(string exchange)
    {
        var factory = new ConnectionFactory();
        _exchange = exchange;

        _connection = factory.CreateConnection();
        _channelModel = _connection.CreateModel();
        _channelModel.ExchangeDeclare(exchange: _exchange, type: ExchangeType.Fanout);
    }

    public string Register(Action<T> subcriber)
    {
            _queueName = _channelModel.QueueDeclare().QueueName;
            _channelModel.QueueBind(queue: _queueName, exchange: _exchange, routingKey: "");
            var consumer = new EventingBasicConsumer(_channelModel);
            
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                subcriber(JsonConvert.DeserializeObject<T>(message));
            };
            return _channelModel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
    }
}