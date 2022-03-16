using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UAL_Invest.Context;
using UAL_Invest.Models;
using UAL_Invest.Repositorio.Interface;




namespace UAL_Invest.Repositorio.Data
{
    public class LoginRepositorio : ILoginRepositorio
    {
        public UalContext _ualContext { get; set; }
        public HttpContext HttpContext { get; set; }
        public SignInManager<IdentityUser> _signInManager { get; set; }


        public LoginRepositorio(UalContext context)
        {
            _ualContext = context;
           // _httpContext = httpContext;
            
        }
        public async Task<bool> Login(Usuario user)
        {
            bool logado = false;
            string _email = "";
            string _senha = "";

            using (var db = new UalContext())
            {
                var query = from T in db.Usuarios
                            where T.Email == user.Email && T.Senha == user.Senha
                            select new
                            {
                                email = T.Email,
                                senha = T.Senha,
                                nome = T.Nome,
                                TipoUsuarioID = T.TipoUsuarioId,
                                UsuarioID = T.UsuarioId,
                            };
                foreach(var v in query)
                {
                    _email = v.email;
                    _senha = v.senha;
                    user.UsuarioId = v.UsuarioID;
                    user.TipoUsuarioId = v.TipoUsuarioID;
                    user.Nome = v.nome;
                }
            }
           

            if(_email.Equals(user.Email) && _senha.Equals(user.Senha))
            {
                //var identity = new ClaimsIdentity(new[] {
                //    new Claim(ClaimTypes.Name, user.UsuarioId.ToString())
                //}, CookieAuthenticationDefaults.AuthenticationScheme);

                //var principal = new ClaimsPrincipal(identity);

                await  HttpContext.Session.LoadAsync();

                HttpContext.Session.SetString("Email", user.Email.ToString());
                HttpContext.Session.SetString("UsuarioID", user.UsuarioId.ToString());
                HttpContext.Session.SetString("Nome", user.Nome.ToString());
                HttpContext.Session.SetString("TipoUsuario", user.TipoUsuarioId.ToString());

                 
                return logado = true;
            }

           logado = false;
            return logado;
            
        }
     
    }
}
