using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class ExtratoWallet
    {
        public int ExtratoWalletId { get; set; }
        public DateTime? DataHoraInclusao { get; set; }
        public int? AtivoId { get; set; }
        public int? UsuarioId { get; set; }
        public string TipoOperacao { get; set; }
        public int? QuantidadeAtivo { get; set; }
        public decimal? ValorAtivo { get; set; }

        public virtual Ativo Ativo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
