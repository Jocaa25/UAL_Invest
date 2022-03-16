using Microsoft.AspNetCore.Authorization;
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
    
    public class ClienteController : Controller
    {

        //private IClienteDepositoRepositorio _IclienteDepositoRepositorio { get; set; }

        //private readonly IHttpContextAccessor _context;
        public ClienteController()
        {
            //_IclienteDepositoRepositorio = clienteDepositoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Comprar()
        {
            return View();
        }
        public IActionResult Vender()
        {
            return View();
        }
        public IActionResult Saque()
        {
            return View();
        }
        public IActionResult Depositar()
        {
            return View();
        }
        public IActionResult Extrato()
        {
            return View();
        }

        //public IActionResult Depositar (Wallet walet)
        //{
        //    _IclienteDepositoRepositorio.Depositar(walet);
        //    return RedirectToAction("Index");
        //}

    }
}
