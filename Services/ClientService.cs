using MyBack.Repositories;
using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetAllClientes()
        {
            return _clientRepository.GetClientes();
        }
    }
}
