using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ListaCompra.Models;

namespace API_ListaCompra.Aplicacao
{
    public class ProdutoAplicacao
    {

        private APIContext _contexto;
        public ProdutoAplicacao(APIContext contexto)
        {
            _contexto = contexto;
        }

        public string setProduto(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    _contexto.Add(produto);
                    _contexto.SaveChanges();

                    return "Produto cadastrado com sucesso!";

                }
                else
                {
                    return "Produto invalido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateProduto(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    _contexto.Update(produto);
                    _contexto.SaveChanges();

                    return "Produto alterado com sucesso!";

                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível se comunicar com a base de dados! " + ex;
            }
        }

        public string DeleteProduto(Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return "Produto invalido! Por favor tente novamente.";
                }
                else
                {
                    _contexto.Produto.Remove(produto);
                    _contexto.SaveChanges();

                    return "Produto deletada com sucesso!";
                }
            }
            catch (Exception ex)
            {

                return "Não foi possível se comunicar com a base de dados!" + ex;
            }
        }

        public List<Produto> getListaProdutos(int idLista)
        {
            List<Produto> listaProdutos = new List<Produto>();
            try
            {

                listaProdutos = _contexto.Produto.Where(x => x.IdLista == idLista).ToList();

                if (listaProdutos != null)
                {
                    return listaProdutos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
