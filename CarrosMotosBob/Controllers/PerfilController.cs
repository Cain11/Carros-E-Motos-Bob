using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarrosMotosBob.Models.PerfilCliente;
using CMBData;
using Microsoft.AspNetCore.Mvc;

namespace CarrosMotosBob.Controllers
{
    public class PerfilController : Controller
    {
        ICliente _clientes;

        public PerfilController(ICliente clientes)
        {
            _clientes = clientes;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var login = new LoginIndexModel
            {
                Id = -1,
                EMail = ""
            };

            return View(login);
        }

        public IActionResult Logado(int id)
        {
            var perfil = _clientes.GetById(id);

            var model = new PerfilClienteIndexModel
            {
                Id = perfil.Id,
                Nome = perfil.Nome,
                EMail = perfil.Email,
                Telefone = perfil.Telefone
                
            };
            return View(model);
        }
    }
}