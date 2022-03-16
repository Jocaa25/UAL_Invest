using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int WalletId { get; set; }
        public decimal? Saldo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
