using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class TipoRendum
    {
        public TipoRendum()
        {
            Ativos = new HashSet<Ativo>();
        }

        public int TipoRendaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Ativo> Ativos { get; set; }
    }
}
