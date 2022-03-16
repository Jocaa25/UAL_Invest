using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Models;
using UAL_Invest.Repositorio.Data;
using UAL_Invest.Repositorio.Interface;

namespace UAL_Invest.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        public ICadastroUsuarioRepositorio _cadastro { get; set; }
        public CadastroUsuarioController(ICadastroUsuarioRepositorio cadastro)
        {
            _cadastro = cadastro;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            _cadastro.Cadastrar(usuario);
            return RedirectToAction("Cadastrar");
        }

    }
}
