using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAL_Invest.Controllers
{
    public class GerenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
