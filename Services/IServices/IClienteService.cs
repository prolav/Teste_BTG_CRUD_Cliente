using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces;

namespace Teste_BTG_CRUD_Cliente.Services.IServices
{
    public interface IClienteService
    {
        Task<List<ClienteModel>> ObterClienteOrderByAscAsync();
        ClienteModel ObterClientePorId(Guid id);
        Task DeleteCliente(ClienteModel cliente);
        Task InsertReplaceCliente(ClienteModel cliente);
    }
}
