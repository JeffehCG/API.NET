using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ListaCompra.Models;

namespace API_ListaCompra.Aplicacao
{
    public class ListaCompraAplicacao
    {

        private APIContext _contexto;

        public ListaCompraAplicacao(APIContext contexto)
        {
            _contexto = contexto;
        }

        public string setLista(Listacompras lista)
        {
            try
            {
                if (lista != null)
                {
                    _contexto.Add(lista);
                    _contexto.SaveChanges();

                    return "Lista cadastrada com sucesso!";

                }
                else
                {
                    return "Lista invalida!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateLista(Listacompras lista)
        {
            try
            {
                if (lista != null)
                {
                    _contexto.Update(lista);
                    _contexto.SaveChanges();

                    return "Lista alterada com sucesso!";
                }
                else
                {
                    return "Lista inválida!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string DeleteLista(Listacompras lista)
        {
            try
            {
                if (lista == null)
                {
                    return "Lista invalida! Por favor tente novamente.";
                }
                else
                {
                    _contexto.Produto.RemoveRange(_contexto.Produto.Where(x => x.IdLista == lista.Id));
                    _contexto.Listacompras.Remove(lista);
                    _contexto.SaveChanges();

                    return "Lista deletada com sucesso!";
                }
            }
            catch (Exception ex)
            {   
                
                return "Não foi possível se comunicar com a base de dados!" + ex;
            }
        }

        public List<Listacompras> getListasUsuario(int idUsuario)
        {
            List<Listacompras> listasUsuarios = new List<Listacompras>();
            try
            {

                listasUsuarios = _contexto.Listacompras.Where(x => x.IdUsuario == idUsuario).ToList();

                if (listasUsuarios != null)
                {
                    return listasUsuarios;
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
