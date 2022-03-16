using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Models;
using UAL_Invest.Repositorio.Interface;

namespace UAL_Invest.Controllers
{
    public class AdminController : Controller
    {
        private ICadastroAtivoRepositorio _cadastroAtivoRepositorio { get; set; }
        public ICadastroGerenteRepositorio _cadastroGerenteRepositorio { get; set; }
        public AdminController(ICadastroGerenteRepositorio cadastroGerenteRepositorio, ICadastroAtivoRepositorio cadastroAtivoRepositorio  )
        {
            _cadastroAtivoRepositorio = cadastroAtivoRepositorio;
            _cadastroGerenteRepositorio = cadastroGerenteRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CadastrarGerente()
        {
            return View();
        }
        public IActionResult CadastrarAtivos()
        {
            //var ativos = _cadastroAtivoRepositorio.BuscarAtivos();

            return View();
        }


        [HttpPost]
        public IActionResult CadastrarNovoGerente(Usuario usuario)
        {
            _cadastroGerenteRepositorio.Cadastrar(usuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CadastrarNovoAtivo(Ativo ativo)
        {
            _cadastroAtivoRepositorio.Cadastrar(ativo);
            return RedirectToAction("Index");
        }

    }
}
