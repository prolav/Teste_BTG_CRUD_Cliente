using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces;
using Teste_BTG_CRUD_Cliente.Services.IServices;

namespace Teste_BTG_CRUD_Cliente.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Data.Models.ClienteModel>> ObterClienteOrderByAscAsync()
        {
            try
            {
                return await _repository.ObterClienteOrderByAscAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter clientes ordenados: " + e.Message);
            }
        }

        public ClienteModel ObterClientePorId(Guid id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter cliente por ID: " + e.Message);
            }
        }

        public async Task DeleteCliente(ClienteModel cliente)
        {
            try
            {
                _repository.Delete(cliente);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir cliente: " + e.Message);
            }
        }

        public async Task InsertReplaceCliente(ClienteModel cliente)
        {
            try
            {
                _repository.InsertOrReplace(cliente);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir ou substituir cliente: " + e.Message);
            }
        }


    }
}
