using System;
using System.Collections.Generic;

#nullable disable

namespace UAL_Invest.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ExtratoWallets = new HashSet<ExtratoWallet>();
        }

        public int UsuarioId { get; set; }
        public int? TipoUsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? GerenteId { get; set; }
        public int? WalletId { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<ExtratoWallet> ExtratoWallets { get; set; }
    }
}
