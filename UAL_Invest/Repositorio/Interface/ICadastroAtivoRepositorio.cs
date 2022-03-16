using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Models;

namespace UAL_Invest.Repositorio.Interface
{
    public interface ICadastroAtivoRepositorio
    {
        List<Ativo> BuscarAtivos();
        Ativo Cadastrar(Ativo Ativo);
        

    }
}
