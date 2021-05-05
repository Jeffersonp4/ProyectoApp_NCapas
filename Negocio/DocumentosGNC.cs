using System;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Web.Mvc;

namespace Negocio
{
    public class DocumentosGNC
    {
        private static DocumentosGDatos objeto = new DocumentosGDatos();
        public static List<DocumentoBien> listarDocumento()
        {
            return objeto.ListarDocumentos();
        }

        //public static List<SelectListItem> listarSiglas()
        //{
        //    return objeto.listarSiglas();
        //}

        public static void GeneraDoc(DocumentosG DG)
        {
            objeto.GeneraDocumento(DG);
        }

        public static DocumentoBien ConsigueDoc(int id)
        {
            return objeto.consigueDocumento(id);
        }

        public static void Editar(DocumentosG DG)
        {
            objeto.Editar(DG);
        }

        public static void Eliminar(int id)
        {
            objeto.eliminar(id);
        }
    }
}
