using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarrosMotosBob.Models.ViewModels.Anuncio;
using CarrosMotosBob.Models.ViewModels.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMBData;
using CMBData.Models;
using Microsoft.AspNetCore.Http;
using CarrosMotosBob.Models.ViewModels.Cliente;

namespace CarrosMotosBob.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly CMBContext _context;

        public AnunciosController(CMBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ListaVm> lista = new List<ListaVm>();

            var anuncios = _context.Anuncios
                .Include(a => a.Anunciante)
                .Include(a => a.Modelo);

            foreach (var anuncio in anuncios)
            {
                AnuncianteVm anunciante = new AnuncianteVm
                {
                    Nome = anuncio.Anunciante.Nome,
                    Cidade = anuncio.Anunciante.Cidade,
                    Estado = anuncio.Anunciante.Estado,
                    Telefone = anuncio.Anunciante.Telefone
                };

                AnuncioListaVm modelo = new AnuncioListaVm
                {
                    Nome = anuncio.Modelo.Nome,
                    Avaliacao = anuncio.Modelo.Avaliacao
                };

                ListaVm itemLista = new ListaVm
                {
                   Anunciante = anunciante,
                   Imagem = anuncio.Imagem,
                   Ano = anuncio.Ano,
                   DataPublicacao = anuncio.DataPublicacao,
                   Descricao = anuncio.Descricao,
                   Preco = anuncio.Preco,
                   Modelo = modelo
                };

                lista.Add(itemLista);
            }

            return View(lista);
        }

        private List<AnuncioCadastroVm> ObterListaModelos()
        {
            List<AnuncioCadastroVm> listaModelos = new List<AnuncioCadastroVm>();

            foreach (var modelo in _context.Modelos)
            {
                AnuncioCadastroVm modeloVm = new AnuncioCadastroVm
                {
                    Id = modelo.Id,
                    Nome = modelo.Nome
                };
                listaModelos.Add(modeloVm);
            }

            return listaModelos;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new Models.ViewModels.Anuncio.CadastroVm(ObterListaModelos()));
        }

        [HttpPost]
        public IActionResult Cadastrar(Models.ViewModels.Anuncio.CadastroVm dadosCadastro)
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Cliente anunciante = _context.Clientes.Find(Convert.ToInt32(clienteId));
            Modelo modelo = _context.Modelos.Find(dadosCadastro.ModeloId);
            if (modelo == null)
            {
                ModelState.AddModelError(string.Empty, "Selecione um modelo de carro da lista");
                dadosCadastro.ListaModelos = ObterListaModelos();
                return View("Cadastro", dadosCadastro);
            }

            Anuncio anuncio = new Anuncio
            {
                Anunciante = anunciante,
                Ano = dadosCadastro.Ano,
                DataPublicacao = DateTime.Now,
                Descricao = dadosCadastro.Descricao,
                Preco = dadosCadastro.Preco,
                Modelo = modelo
            };

            if (dadosCadastro.Imagem != null)
            {
                using var memoryStream = new MemoryStream();
                dadosCadastro.Imagem.CopyTo(memoryStream);
                if (memoryStream.Length < 2097152) //2097152 = 2Mb
                {
                    anuncio.Imagem = Convert.ToBase64String(memoryStream.ToArray());
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Imagem muito grande (máx. 2Mb)");
                    dadosCadastro.ListaModelos = ObterListaModelos();
                    return View("Cadastro", dadosCadastro);
                }
            }

            _context.Anuncios.Add(anuncio);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
