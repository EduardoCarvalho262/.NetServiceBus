using ApiServiceBus.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ApiServiceBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceBusPOCController : ControllerBase
    {
        private readonly ILogger<ServiceBusPOCController> _logger;

        public ServiceBusPOCController(ILogger<ServiceBusPOCController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string EnviarMensagem(Pessoa pessoa)
        {
            return "";
        }   

    }
}
