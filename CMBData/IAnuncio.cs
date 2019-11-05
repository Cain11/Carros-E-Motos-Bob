using System;
using System.Collections.Generic;
using System.Text;
using CMBData.Models;

namespace CMBData
{
    public interface IAnuncio
    {
        IEnumerable<Anuncio> GetAll();
        Anuncio GetById(int id);
        Cliente GetCliente(int id);
        IEnumerable<Anuncio> GetByCliente(int id);
        int GetAno(int id);
        string GetDescricao(int id);
        string  GetStatus(int id);
    }
}