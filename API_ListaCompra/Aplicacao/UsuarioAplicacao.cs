using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ListaCompra.Models;

namespace API_ListaCompra.Aplicacao
{
    public class UsuarioAplicacao
    {
        private APIContext _contexto;

        public UsuarioAplicacao(APIContext contexto)
        {
            _contexto = contexto;
        }

        public string setUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioExiste = getUsuario(usuario.Login);

                    if (usuarioExiste == null)
                    {
                        _contexto.Add(usuario);
                        _contexto.SaveChanges();

                        return "Usuário cadastrado com sucesso!";
                    }
                    else
                    {
                        return "Email já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }


        public string UpdateUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    _contexto.Update(usuario);
                    _contexto.SaveChanges();

                    return "Usuário alterado com sucesso!";
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Usuario getUsuario(string login)
        {
            Usuario primeiroUsuario = new Usuario();

            try
            {
                if (login == string.Empty)
                {
                    return null;
                }

                var cliente = _contexto.Usuario.Where(x => x.Login == login).ToList();
                primeiroUsuario = cliente.FirstOrDefault();

                if (primeiroUsuario != null)
                {
                    return primeiroUsuario;
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

        public List<Usuario> getTodosUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {

                listaUsuarios = _contexto.Usuario.Select(x => x).ToList();

                if (listaUsuarios != null)
                {
                    return listaUsuarios;
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


        public string DeleteUsuario(string login)
        {
            try
            {
                if (login == string.Empty)
                {
                    return "Email inválido! Por favor tente novamente.";
                }
                else
                {
                    var usuario = getUsuario(login);

                    if (usuario != null)
                    {
                        _contexto.Usuario.Remove(usuario);
                        _contexto.SaveChanges();

                        return "Usuário " + login + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }
    }
}
