using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMBData;
using CMBData.Models;
using Microsoft.EntityFrameworkCore;

namespace CMBServices
{
    public class AnuncioServices : IAnuncio
    {
        CMBContext _context;

        public AnuncioServices(CMBContext context)
        {
            _context = context;
        }


        public IEnumerable<Anuncio> GetAll()
        {
            return _context.Anuncios
                .Include(asset => asset.Anunciante)
                .Include(asset => asset.Modelo);
        }

        public Anuncio GetById(int id)
        {
            return _context.Anuncios
                .Include(asset => asset.Anunciante)
                .Include(asset => asset.Modelo)
                .FirstOrDefault(anuncio => anuncio.Id == id);
        }

        public Cliente GetCliente(int id)
        {
            return GetById(id).Anunciante;
        }

        public IEnumerable<Anuncio> GetByCliente(int id)
        {
            return GetAll().Where(anucio => anucio.Anunciante.Id == id);
        }

        public int GetAno(int id)
        {
            return GetById(id).Ano;
        }

        public string GetDescricao(int id)
        {
            return GetById(id).Descricao;
        }

        public string GetStatus(int id)
        {
            switch (GetById(id).Status)
            {
                case 1:
                    return "Publicado";
                case 2:
                    return "Em análise";
                case 3:
                    return "Expirados";
                default:
                    return "Fora De Status";
            }
        }
    }
}