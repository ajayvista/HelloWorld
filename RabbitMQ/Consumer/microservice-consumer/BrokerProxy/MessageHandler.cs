using System.Collections.Generic;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public interface IMessageHandler
{
        public void Register();
        public void Handle(Message message);
}
public class MessageHandler: IMessageHandler
{
    private IConsumer<Message>  _consumer;
    private ILogger<MessageHandler>  _logger;   
    public MessageHandler(ILogger<MessageHandler> logger, string exchange)
    {
        _logger = logger;
        _consumer = new Consumer<Message>(exchange);//exchange name - that required to be listended
    }

    /// <summary>
    /// Register your subscription
    /// </summary>
    public void Register() =>  _consumer.Register(Handle);
    
    /// <summary>
    /// Handle message
    /// </summary>
    /// <param name="message"></param>
    public void Handle(Message message)
    {
        //TODO: logic to handle the message
        Console.WriteLine($"Message received - {message.MessageId} - {message.ProducedAt} - {JsonConvert.SerializeObject(message.Data)}");
    }
}