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
    public class CadastroAtivoRepositorio : ICadastroAtivoRepositorio
    {
        public UalContext _ualContext { get; set; }

        public CadastroAtivoRepositorio(UalContext context)
        {
            _ualContext = context;

        }
        public Ativo Cadastrar(Ativo ativo)
        {
            
            var tipoUsuario = 2;

            //adicionando usuario
           
            _ualContext.Ativos.Add(ativo);
            _ualContext.SaveChanges();

            return ativo;
        }

        public List<Ativo> BuscarAtivos()
        {
            return _ualContext.Ativos.ToList();
        }
    }
}
