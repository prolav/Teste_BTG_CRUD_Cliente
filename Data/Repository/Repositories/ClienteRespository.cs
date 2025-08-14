using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces;

namespace Teste_BTG_CRUD_Cliente.Data.Repository.Repositories
{
    public class ClienteRespository : BaseRepository<ClienteModel>, IClienteRepository
    {
        public Task<List<ClienteModel>> ObterClienteOrderByAscAsync()
        {
            try
            {
                var clienteOrdenados = GetAll();
                return Task.FromResult(clienteOrdenados.OrderBy(c => c.Name).ToList());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //public ClienteModel GetById(Guid id)
        //{
        //    try
        //    {
        //        return GetById(id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

    }
}