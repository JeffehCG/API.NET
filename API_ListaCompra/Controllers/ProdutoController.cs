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
    public class ProdutoController : ControllerBase
    {

        private APIContext _contexto;
        public ProdutoController(APIContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        [Route("inserir")]
        [Authorize]

        public IActionResult InserirProduto([FromBody]Produto produtoEnviado)
        {
            try
            {
                if (!ModelState.IsValid || produtoEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new ProdutoAplicacao(_contexto).setProduto(produtoEnviado);
                    return Ok(JsonConvert.SerializeObject(resposta));
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
        public IActionResult AlterarProduto([FromBody]Produto produtoEnviado)
        {
            try
            {
                if (!ModelState.IsValid || produtoEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new ProdutoAplicacao(_contexto).UpdateProduto(produtoEnviado);
                    return Ok(JsonConvert.SerializeObject(resposta));
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
        public IActionResult DeleteProduto(int id)
        {
            try
            {
 
                var resposta = new ProdutoAplicacao(_contexto).DeleteProduto(id);
                return Ok(JsonConvert.SerializeObject(resposta));
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public IActionResult ListarProdutosLista(int idLista)
        {
            try
            {
                var produtosLista = new ProdutoAplicacao(_contexto).getListaProdutos(idLista);

                if (produtosLista != null)
                {
                    var resposta = JsonConvert.SerializeObject(produtosLista);
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Nenhum produto cadastrado!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }
    }
}