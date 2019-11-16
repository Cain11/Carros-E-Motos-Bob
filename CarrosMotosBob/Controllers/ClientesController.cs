using System;
using System.Linq;
using CarrosMotosBob.Models.ViewModels.Cliente;
using Microsoft.AspNetCore.Mvc;
using CMBData;
using CMBData.Models;
using Microsoft.AspNetCore.Http;

namespace CarrosMotosBob.Controllers
{
    public class ClientesController : Controller
    {
        private readonly CMBContext _context;

        public ClientesController(CMBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Autenticar(LoginVm dadosLogin)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", dadosLogin);
            }

            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Email == dadosLogin.Email);
            if (cliente != null)
            {
                if (UtilSenha.ValidarSenha(cliente.Senha, dadosLogin.Senha))
                {
                    var cookieOptions = new CookieOptions()
                    {
                        Expires = DateTimeOffset.MaxValue,
                        IsEssential = true
                    };
                    Response.Cookies.Append("ClienteId", cliente.Id.ToString(), cookieOptions);
                    Response.Cookies.Append("ClienteNome", cliente.Nome, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View("Login", dadosLogin);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(new CadastroVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(CadastroVm dadosCadastro)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro", dadosCadastro);
            }

            Cliente clienteExistente = _context.Clientes.FirstOrDefault(c => c.Email == dadosCadastro.Email);
            if (clienteExistente != null)
            {
                ModelState.AddModelError(string.Empty, "Já existe um usuário cadastrado com esse email");
                return View("Cadastro", dadosCadastro);
            }

            Cliente cliente = new Cliente
            {
                Nome = dadosCadastro.Nome,
                Email = dadosCadastro.Email,
                Senha = UtilSenha.GerarHashSenha(dadosCadastro.Senha),
                Cidade = dadosCadastro.Cidade,
                Estado = dadosCadastro.Estado,
                Telefone = dadosCadastro.Telefone,
                CPF = dadosCadastro.CPF
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult MinhaConta()
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Cliente cliente = _context.Clientes.Find(Convert.ToInt32(clienteId));
            AlterarVm dadosAlterar = new AlterarVm
            {
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Cidade = cliente.Cidade,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Estado = cliente.Estado
            };

            return View(dadosAlterar);
        }

        [HttpPost]
        public IActionResult Alterar(AlterarVm dadosAlterar)
        {
            string clienteId = Request.Cookies["ClienteId"];
            if (clienteId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View("MinhaConta", dadosAlterar);
            }

            Cliente cliente = _context.Clientes.Find(Convert.ToInt32(clienteId));

            if (UtilSenha.ValidarSenha(cliente.Senha, dadosAlterar.SenhaAtual))
            {
                cliente.Cidade = dadosAlterar.Cidade;
                cliente.Estado = dadosAlterar.Estado;
                cliente.Telefone = dadosAlterar.Telefone;
                if (!string.IsNullOrWhiteSpace(dadosAlterar.SenhaNova))
                {
                    cliente.Senha = UtilSenha.GerarHashSenha(dadosAlterar.SenhaNova);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("MinhaConta", dadosAlterar);
        }

        [HttpGet]
        public IActionResult Sair()
        {
            Response.Cookies.Delete("ClienteId");
            Response.Cookies.Delete("ClienteNome");
            return RedirectToAction("Index", "Home");
        }

    }
}
