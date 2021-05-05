using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class DepartamentoNC
    {
        private static DepartamentoCdatos objeto = new DepartamentoCdatos();
        public static List<Departamentos> ListarDepartamentos()
        {
            return objeto.ListarDepartamentos();
        }

        public static void AgregarDpto(Departamentos dpto)
        {
            objeto.AgregarDptos(dpto);
        }

        public static Departamentos consigueDpto(int id)
        {
            return objeto.consigueDpto(id);
        }

        public static void Editar(Departamentos dpto)
        {
            objeto.Editar(dpto);
        }

        public static void Eliminar(int id)
        {
            objeto.eliminar(id);
        }
    }
}
