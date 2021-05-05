using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuariosNC
    {
        private static UsuariosDatos objeto = new UsuariosDatos();

        public static List<Usuarios> ListarUsuarios()
        {
            return objeto.ListarUsuarios();
        }

        public static void AgregarUsuario(Usuarios usuario)
        {
             objeto.AgregarUsuario(usuario);
        }

        public static Usuarios ConsigueUsuario(int id)
        {
            return objeto.ConsigueUsuario(id);
        }

        public static void Editar(Usuarios user)
        {
            objeto.Editar(user);
        }

        public static void Eliminar(int id)
        {
            objeto.Eliminar(id);
        }




    }
}
