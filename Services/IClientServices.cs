using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public interface IClientService
    {
        List<Client> GetAllClientes();
    }
}
