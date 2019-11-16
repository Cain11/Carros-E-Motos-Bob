using System;
using System.Collections.Generic;
using System.Linq;
using CMBData;
using CMBData.Models;
using Microsoft.EntityFrameworkCore;

namespace CMBServices
{
    public class ClienteServices : ICliente
    {
        CMBContext _context;

        public ClienteServices(CMBContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes;
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes
                .FirstOrDefault(asset => asset.Id == id);
        }

        public IEnumerable<Anuncio> GetAnuncios(int id)
        {
            var anucios = new AnuncioServices(_context);

            return anucios.GetByCliente(id);
        }

        public void Add(Cliente newCliente)
        {
            _context.Add(newCliente);
            _context.SaveChanges();
        }

        public string GetNome(int id)
        {
            return GetById(id).Nome;
        }

        public string GetEndereco(int id)
        {
            return GetById(id).Cidade + ", " + GetById(id).Estado;
        }

        public string GetEMail(int id)
        {
            return GetById(id).Email;
        }

        public string GetTelefone(int id)
        {
            return GetById(id).Telefone;
        }

        public string GetCPF(int id)
        {
            var cpf = GetById(id).CPF.ToString();
            int casas = cpf.Length;

            while (casas < 11)
            {
                cpf = "0" + cpf;
                casas++;
            }

            return cpf;
        }
    }
}