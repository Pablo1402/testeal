using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAL.Domain.CustomExceptions;
using TesteAL.Domain.Entities;
using TesteAL.Domain.Interfaces.Repositories;
using TesteAL.Domain.Interfaces.Services;

namespace TesteAL.Service.Services
{
    public class ClienteService : IClientService
    {
        private readonly IClientRepository _rep;

        public ClienteService(IClientRepository rep)
        {
            _rep = rep;
        }

        public async Task Delete(Guid id)
        {
            var client = await _rep.getSingle(x => x.Id == id);
            if (client == null)
                throw new AppExceptions("Cliente não encontrado", 404);
            await _rep.Delete( client);
        }

        public async Task<List<Client>> GetAll()
        {
            var clients = await _rep.GetAll();
            if (!clients.ToList().Any())
                throw new AppExceptions("Nenhum cliente encontrado", 404);
            return clients.ToList();
        }

        public async Task<Client> GetById(Guid id)
        {
            var client = await _rep.getSingle(x => x.Id == id);
            if (client == null)
                throw new AppExceptions("Cliente não encontrado", 404);
            return client;
        }

        public async Task<Client> Save(Client model)
        {
            DataValidate(model);
            model.Id = new Guid();
            model = await _rep.Add(model);
            return model;
        }

        public async Task<Client> Update(Client model, Guid id)
        {
            if (model.Id != id)
                throw new AppExceptions("Dados inválidos", 400);
            DataValidate(model);

            var client = await _rep.getSingle(x => x.Id == id);
            if (client == null)
                throw new AppExceptions("Cliente não encontrado", 404);

            client.Age = model.Age;
            client.Name = model.Name;

            await _rep.Update(client);

            return client;
        }

        private void DataValidate(Client model)
        {
            string message = "";
            if (string.IsNullOrEmpty(model.Name) || model.Name.Length > 100)
                message = "Nome inválido. ";

            if (model.Age <= 0 || model.Age > 150)
                message = " Idade inválida. ";

            if (!string.IsNullOrEmpty(message))
            {
                throw new AppExceptions(message, 400);
            }
        }
    }
}
