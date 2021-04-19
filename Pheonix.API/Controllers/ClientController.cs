using Microsoft.AspNetCore.Mvc;
using Pheonix.Domain.Entities;
using Pheonix.Service.Interfaces;
using Pheonix.Service.Validators;
using Pheonix.W.Controllers;

namespace Pheonix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _clientService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _clientService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Client client)
        {
            if (client == null)
                return NotFound();

            return Execute(() => _clientService.Add<ClientValidator>(client).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null)
                return NotFound();

            return Execute(() => _clientService.Update<ClientValidator>(client));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() => 
            {
               _clientService.Delete(id);
               return true;
            });

            return new NoContentResult();
        }
    }
}
