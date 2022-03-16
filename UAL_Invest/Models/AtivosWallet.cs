using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class AtivosWallet
    {
        public int? AtivoId { get; set; }
        public int? WalletId { get; set; }
        public int? QuantidadeAtivo { get; set; }

        public virtual Ativo Ativo { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
