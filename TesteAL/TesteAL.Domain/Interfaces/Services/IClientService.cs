using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteAL.Domain.Entities;

namespace TesteAL.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> GetById(Guid id);
        Task<Client> Save(Client model);
        Task<Client> Update(Client model, Guid id);
        Task Delete(Guid id);
    }
}
