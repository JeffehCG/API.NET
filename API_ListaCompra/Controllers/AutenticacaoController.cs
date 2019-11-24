using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API_ListaCompra.Models;
using API_ListaCompra.Aplicacao;

namespace API_ListaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private IConfiguration _config;
        private APIContext _contexto;
        public AutenticacaoController(APIContext contexto, IConfiguration Configuration)
        {
            _contexto = contexto;
            _config = Configuration;
        }

        private Usuario ValidarUsuario( Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).getUsuario(usuario.Login);
                    if(resposta != null)
                    {
                        if(resposta.Senha == usuario.Senha)
                        {
                            return resposta;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        private string GerarToken()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expiry,
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]Usuario login)
        {
            Usuario resultado = ValidarUsuario(login);
            if (resultado != null)
            {
                var tokenString = GerarToken();
                return Ok(new Token { TokenJwt = tokenString, DataTokenGerado = DateTime.Now, Usuario = resultado.Login, Identificador = resultado.Id });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}