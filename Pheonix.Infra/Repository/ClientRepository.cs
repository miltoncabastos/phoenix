using Pheonix.Domain.Entities;
using Pheonix.Infra.Context;
using Pheonix.Interfaces.Clients;

namespace Pheonix.Infra.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(PheonixContext pheonixContext) : base(pheonixContext)
        {
        }
    }
}
