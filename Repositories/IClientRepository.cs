using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetClientes();
    }
}
