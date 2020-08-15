using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Producer.BrokerProxy;

namespace microservice_producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IProducer<Message,ExchangeType>  _producer;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IProducer<Message,ExchangeType> producer)
        {
            _logger = logger;
            _producer = producer;
        }

        [HttpPost]
        public IActionResult Post(SubcriberDetail subcriber)
        {
            var isProduced = _producer.Produce(new Message(){ProducedAt = DateTime.Now,Data=subcriber, MessageId=Guid.NewGuid() });    
            return Ok($"You will be notified everyday- subcription status {(isProduced?"subscribed":"failed to subscribed-try again")}");
        }
    }
}
