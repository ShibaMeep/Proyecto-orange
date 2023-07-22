using System.Collections;
using Proyecto_orange.Negocio;

namespace Proyecto_orange.Persistencia;

public class RepositorioUsuarios{
    

        public ArrayList usuarios;

        public RepositorioUsuarios()
        {
            usuarios = new ArrayList();
            usuarios.Add(new Usuario("pepe","123"));
            usuarios.Add(new Usuario("aa", "aa"));
        }

        public Usuario buscarUsuario(string login)
        {
            foreach (Usuario usr in usuarios)
            {
                if (usr.login.Equals(login))
                {
                    //es una buena practica logear a la consola
                    Console.WriteLine("Usuario existe " + login);
                    return usr;
                }
            }
            //esto lo vamos a mejorar en futuras versiones
            return null;
        }

        public ArrayList bucarTodos()
        {
            return this.usuarios;

        }


        public void addnewuser()
        {
            
        }
        
    }
