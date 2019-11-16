using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarrosMotosBob.Models.ViewModels.Anuncio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMBData;
using CMBData.Models;
using Microsoft.AspNetCore.Http;

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
                //TODO: Descomentar quando implementar os modelos de carros
                /*.Include(a => a.Modelo)*/;

            foreach (var anuncio in anuncios)
            {
                ListaVm.AnuncianteVm anunciante = new ListaVm.AnuncianteVm
                {
                    Nome = anuncio.Anunciante.Nome,
                    Cidade = anuncio.Anunciante.Cidade,
                    Estado = anuncio.Anunciante.Estado,
                    Telefone = anuncio.Anunciante.Telefone
                };

                ListaVm.ModeloVm modelo = new ListaVm.ModeloVm
                {
                    //TODO: Preencher com dados do modelo do carro do anúncio
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

        [HttpGet]
        public IActionResult Cadastro()
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new CadastroVm());
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroVm dadosCadastro)
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Cliente anunciante = _context.Clientes.Find(Convert.ToInt32(clienteId));
            //TODO: Descomentar quando implementar os modelos de carros
            /*
            Modelo modelo = _context.Modelos.Find(dadosCadastro.ModeloId);
            if (modelo == null)
            {
                ModelState.AddModelError(string.Empty, "Modelo selecionado não existe");
                return View("Cadastro", dadosCadastro);
            }
            */
            Anuncio anuncio = new Anuncio
            {
                Anunciante = anunciante,
                Ano = dadosCadastro.Ano,
                DataPublicacao = DateTime.Now,
                Descricao = dadosCadastro.Descricao,
                Preco = dadosCadastro.Preco,
                //TODO: Descomentar quando implementar os modelos de carros
                //Modelo = modelo
            };

            if (dadosCadastro.Imagem != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    dadosCadastro.Imagem.CopyTo(memoryStream);
                    if (memoryStream.Length < 2097152) //2097152 = 2Mb
                    {
                        anuncio.Imagem = Convert.ToBase64String(memoryStream.ToArray());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Imagem muito grande (máx. 2Mb)");
                        return View("Cadastro", dadosCadastro);
                    }
                }
            }

            _context.Anuncios.Add(anuncio);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
