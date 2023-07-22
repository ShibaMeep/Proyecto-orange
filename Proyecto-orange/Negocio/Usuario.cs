namespace Proyecto_orange.Negocio;

public class Usuario
{
    public string login;
    public string pass;

    public Usuario(string p_login, string p_pass)
    {
        this.login = p_login;
        this.pass = p_pass;
    }

    public bool passwordCorrecta(string passAvalidar)
    {
        return pass.Equals(passAvalidar) ? true : false;

    }


      
}
