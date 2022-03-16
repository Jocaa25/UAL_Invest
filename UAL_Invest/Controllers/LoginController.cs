using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Models;
using UAL_Invest.Repositorio.Interface;

namespace UAL_Invest.Controllers
{
    public class LoginController : Controller
    {
        public ILoginRepositorio _loginRepositorio { get; set; }
        
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar()
        {
            return View();
        }

        public IActionResult EsqueciASenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario , string returnURl)
        {

            if (!string.IsNullOrEmpty(usuario.Email) && string.IsNullOrEmpty(usuario.Senha))
            {
                return RedirectToAction("Index");
            }

            var logado = _loginRepositorio.Login(usuario);

             _httpContextAccessor.HttpContext.Session.LoadAsync();
            var tipoUsuario = _httpContextAccessor.HttpContext.Session.GetString("TipoUsuario");

            if (tipoUsuario.Equals("1")){
                return RedirectToAction("Index", "Admin");
            }
            if (tipoUsuario.Equals("2"))
            {
                return RedirectToAction("Index", "Gerente");
            }
            if (tipoUsuario.Equals("1"))
            {
                return RedirectToAction("Index", "Cliente");
            }

            
            return RedirectToAction("Index");

        }
    }
}
