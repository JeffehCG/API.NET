using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API_ListaCompra.Models;
using API_ListaCompra.Aplicacao;
using Newtonsoft.Json;

namespace API_ListaCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaCompraController : ControllerBase
    {

        private APIContext _contexto;
        public ListaCompraController(APIContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        [Route("inserir")]
        [Authorize]

        public IActionResult InserirLista([FromBody]Listacompras listaEnviada)
        {
            try
            {
                if (!ModelState.IsValid || listaEnviada == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new ListaCompraAplicacao(_contexto).setLista(listaEnviada);
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
        [Authorize]
        public IActionResult AlterarLista([FromBody]Listacompras listaEnviada)
        {
            try
            {
                if (!ModelState.IsValid || listaEnviada == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new ListaCompraAplicacao(_contexto).UpdateLista(listaEnviada);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpDelete]
        [Route("deletar")]
        [Authorize]
        public IActionResult DeleteUserByEmail([FromBody]Listacompras lista)
        {
            try
            {
                if (lista == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new ListaCompraAplicacao(_contexto).DeleteLista(lista);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public IActionResult Listarusuarios(int idusuario)
        {
            try
            {
                var listasUsuarios = new ListaCompraAplicacao(_contexto).getListasUsuario(idusuario);

                if (listasUsuarios != null)
                {
                    var resposta = JsonConvert.SerializeObject(listasUsuarios);
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Nenhuma lista cadastrado!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }
    }
}