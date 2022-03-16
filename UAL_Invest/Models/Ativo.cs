using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class Ativo
    {
        public Ativo()
        {
            ExtratoWallets = new HashSet<ExtratoWallet>();
        }

        public int AtivoId { get; set; }
        public string NomeAtivo { get; set; }
        public int? TipoRendaId { get; set; }
        public decimal? PrecoAtivo { get; set; }

        public virtual TipoRendum TipoRenda { get; set; }
        public virtual ICollection<ExtratoWallet> ExtratoWallets { get; set; }
    }
}
