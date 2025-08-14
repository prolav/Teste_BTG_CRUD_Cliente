using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;

namespace Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository<ClienteModel>
    {
        Task<List<ClienteModel>> ObterClienteOrderByAscAsync();
    }
}