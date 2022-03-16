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
    public class CadastroUsuarioRepositorio : ICadastroUsuarioRepositorio
    {
        public UalContext _ualContext { get; set; }

        public CadastroUsuarioRepositorio(UalContext context)
        {
            _ualContext = context;

        }
        public Usuario Cadastrar(Usuario usuario)
        {
            //    var connection = new SqlConnection(_ualContext.Database.GetDbConnection().ConnectionString);
            //    connection.Open();
            //    var query = "insert into Usuario([TipoUsuarioID] ,[Nome],[DataDeNascimento],[Email],[Senha],[GerenteID],[WalletID]) +" +
            //        "Values (@TipoUsuarioID, @Nome,@DataDeNascimento,@Email,@Senha,@GerenteID,@WalletID)";
            //    var command = new SqlCommand(query, connection);
            //    command.Parameters.Add("@TipoUsuario", SqlDbType.Int).Value = 3;
            //    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = usuario.Nome;
            //    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
            //    command.Parameters.Add("@DataDeNascimento", SqlDbType.Date).Value = usuario.DataDeNascimento;
            //    command.Parameters.Add("@Senha", SqlDbType.VarChar).Value = usuario.Senha;
            //    command.Parameters.Add("@GerenteID", SqlDbType.VarChar).Value = usuario.GerenteId;
            //    command.Parameters.Add("@WalletID", SqlDbType.VarChar).Value = walletID;
            //    command.ExecuteNonQuery();

            //    connection.Close();

            var tipoUsuario = 3;

            //adicionando usuario
            usuario.TipoUsuarioId = tipoUsuario;
            _ualContext.Usuarios.Add(usuario);
            _ualContext.SaveChanges();

            //adicionando wallet
            Wallet wallet = new Wallet();
            wallet.Saldo = 0;
            _ualContext.Wallets.Add(wallet);
            _ualContext.SaveChanges();


            var usuarioId = usuario.UsuarioId;
            var walletID = wallet.WalletId;

            //vinculando wallet ao usuario
            usuario.WalletId = walletID;
            _ualContext.Update(usuario);
            _ualContext.SaveChanges();

            

            return usuario;
        }

        public int WalletId()
        {
            int WalletID = 0;
            using (var db = new UalContext())
            {
                var query = from T in db.Wallets.OrderByDescending(x => x.WalletId)
                            select new
                            {
                                WalletId = T.WalletId
                            };
                foreach(var v in query)
                {
                    WalletID = v.WalletId;
                    break;
                }

                return WalletID;

            }
        }

        public int UsuarioID()
        {
            int usuarioId = 0;
            using (var db = new UalContext())
            {
                var query = from T in db.Usuarios.OrderByDescending(x => x.UsuarioId)
                            select new
                            {
                                UsuarioId = T.UsuarioId,
                            };
                foreach (var v in query)
                {
                    usuarioId = v.UsuarioId;
                    break;
                }

                return usuarioId;

            }
        }
    }
}
