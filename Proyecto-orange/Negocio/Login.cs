using Proyecto_orange.Persistencia;

namespace Proyecto_orange.Negocio;

public class Login
{
    private RepositorioUsuarios repositorioUsuarios;
        public Usuario? usuarioActual; //? permite valores null


        public Login()
        {
            this.repositorioUsuarios = new RepositorioUsuarios();
        }
        public bool autenticar(Usuario usuario)
        {
            Usuario usuarioRecuperado = repositorioUsuarios.buscarUsuario(usuario.login);
            if (usuarioRecuperado != null)
            {
                if (usuarioRecuperado.passwordCorrecta(usuario.pass))
                {
                    return true;
                } else
                {
                    return false;
                }
                
            } else
            {
                return false;
            }
        }
    }

