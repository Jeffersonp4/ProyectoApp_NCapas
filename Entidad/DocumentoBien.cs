using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DocumentoBien
    {
        public int id { get; set; }
        public int Año { get; set; }
        public string Departamento_Origen { get; set; }
        public string Departamento_Destino { get; set; }
        public string Secuencia { get; set; }
        public int idDepa { get; set; }
        public string NombreDepa { get; set; }
        public string Nombres_O { get; set; }
        public string Nombre { get; set; }
        public string Idnombre { get; set; }
        public int idUser { get; set; }
    }
}
