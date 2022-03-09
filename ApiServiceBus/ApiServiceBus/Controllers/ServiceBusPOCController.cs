using ApiServiceBus.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace ApiServiceBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceBusPOCController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly string serviceBusConnectionString;

        public ServiceBusPOCController(IConfiguration config)
        {
            _config = config;
            serviceBusConnectionString = _config.GetValue<string>("AzureBusConnectionString");
        }

        [HttpPost]
        [Route("topic")]
        public async Task<IActionResult> EnviarMensagem(Pessoa pessoa)
        {
            await EnviarMensagemParaTopico(pessoa);
            return Ok(pessoa);
        }

        private async Task EnviarMensagemParaTopico(Pessoa pessoa)
        {
            var topico = "pessoa";

            var client = new TopicClient(serviceBusConnectionString, topico);
            string corpoDaMensagem = JsonSerializer.Serialize(pessoa);
            var mensagem = new Message(Encoding.UTF8.GetBytes(corpoDaMensagem));
            mensagem.UserProperties.Add("sexo", pessoa.Sexo);

            await client.SendAsync(mensagem);
            await client.CloseAsync();
        }
    }
}
