using System.Collections.Generic;
using CMBData.Models;

namespace CMBData
{
    public interface ICliente
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        IEnumerable<Anuncio> GetAnuncios(int id);
        void Add(Cliente newCliente);
        string GetNome(int id);
        string GetEndereco(int id);
        string GetEMail(int id);
        string GetTelefone(int id);
        string GetCPF(int id);
    }
}