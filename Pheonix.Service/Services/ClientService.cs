using Pheonix.Domain.Entities;
using Pheonix.Interfaces.Clients;
using Pheonix.Service.Interfaces;

namespace Pheonix.Service.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(IClientRepository clientRepository) : base(clientRepository)
        {
        }
    }
}
