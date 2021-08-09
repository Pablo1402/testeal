using System;
using System.Collections.Generic;
using System.Text;
using TesteAL.Domain.Entities;
using TesteAL.Domain.Interfaces.Repositories;
using TesteAL.Repository.Context;

namespace TesteAL.Repository.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(TesteALContext db) : base(db)
        {
        }
    }
}
