using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Context;
using UAL_Invest.Models;
using UAL_Invest.Repositorio.Interface;

namespace UAL_Invest.Repositorio.Data
{
    public class ClienteDepositoRepositorio : IClienteDepositoRepositorio
    {
        public UalContext _ualContext { get; set; }
        public ClienteDepositoRepositorio(UalContext context)
        {
            _ualContext = context;

        }



        public Wallet Depositar(Wallet Wallet)
        {
            throw new NotImplementedException();
        }
    }

}
