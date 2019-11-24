using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_ListaCompra.Models;
using API_ListaCompra.Aplicacao;
using Newtonsoft.Json;

namespace API_ListaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private APIContext _contexto;
        public UsuarioController(APIContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return Ok("Index API ");
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult InserirUsuario([FromBody]Usuario usuarioEnviado)
        {
            try
            {
                if (!ModelState.IsValid || usuarioEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).setUsuario(usuarioEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult AlterarUsuario([FromBody]Usuario usuarioEnviado)
        {
            try
            {
                if (!ModelState.IsValid || usuarioEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).UpdateUsuario(usuarioEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpPost]
        [Route("buscar")]
        public IActionResult GetUsuario([FromBody]string login)
        {
            try
            {
                if (login == string.Empty)
                {
                    return BadRequest("Email inválido! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).getUsuario(login);

                    if (resposta != null)
                    {
                        var usuarioResposta = JsonConvert.SerializeObject(resposta);
                        return Ok(usuarioResposta);
                    }
                    else
                    {
                        return BadRequest("Usuário não cadastrado!");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }


        [HttpGet]
        [Route("listar")]
        public IActionResult Listarusuarios()
        {
            try
            {
                var listaUsuarios = new UsuarioAplicacao(_contexto).getTodosUsuarios();

                if (listaUsuarios != null)
                {
                    var resposta = JsonConvert.SerializeObject(listaUsuarios);
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Nenhum usuário cadastrado!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public IActionResult DeleteUserByEmail([FromBody]string login)
        {
            try
            {
                if (login == string.Empty)
                {
                    return BadRequest("Email inválido! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).DeleteUsuario(login);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }
    }
}