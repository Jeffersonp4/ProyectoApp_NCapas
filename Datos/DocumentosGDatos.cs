using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Datos
{
    public class DocumentosGDatos
    {
        public List<DocumentoBien> ListarDocumentos()
        {
            string sql = @"select e.id,  e.Año , e.Departamento_Origen, e.Departamento_Destino, e.Secuencia, e.idUser , d.Siglas as 'Nombres_O', r.Siglas as 'NombreDepa', u.Nombre,
                                n.NombreDepa as 'Idnombre'
                                from DocumentosG e
                                inner join Departamentos d on e.Departamento_Origen = d.IdDepa
                                inner join Departamentos r on e.Departamento_Destino = r.IdDepa
                                inner join Usuarios u on e.idUser = u.id
                                inner join Departamentos n on e.idDepa = n.IdDepa";

            using (var db = new ProyectoFinalEntities())
            {

                return db.Database.SqlQuery<DocumentoBien>(sql).ToList();
            }
        }

        public void GeneraDocumento(DocumentosG DG)
        {

            using (var db = new ProyectoFinalEntities())
            {
                db.DocumentosG.Add(DG);
                db.SaveChanges();
            }

        }

        public DocumentoBien consigueDocumento(int id)
        {
            string sql = @"select e.id,  e.Año , e.Departamento_Origen, e.Departamento_Destino, e.Secuencia, e.idUser , d.Siglas as 'Nombres_O', r.Siglas as 'NombreDepa', u.Nombre,
                                    n.NombreDepa as 'Idnombre'
                                    from DocumentosG e
                                    inner join Departamentos d on e.Departamento_Origen = d.IdDepa
                                    inner join Departamentos r on e.Departamento_Destino = r.IdDepa
                                    inner join Usuarios u on e.idUser = u.id
                                    inner join Departamentos n on e.idDepa = n.IdDepa
                                    where e.id = @id";
            using (var db = new ProyectoFinalEntities())
            {
                //return db.DocumentosG.Find(id);
                return db.Database.SqlQuery<DocumentoBien>(sql,
                    new SqlParameter("@id", id)).FirstOrDefault();
            }
        }

        public void Editar(DocumentosG DG)
        {
            using (var db = new ProyectoFinalEntities())
            {

                var editar = db.DocumentosG.Find(DG.id);

                editar.Año = DG.Año;
                editar.Departamento_Origen = DG.Departamento_Origen;
                editar.Departamento_Destino = DG.Departamento_Destino;
                editar.Secuencia = DG.Secuencia;
                db.SaveChanges();

            }



        }

        public void eliminar(int id)
        {
            using (var db = new ProyectoFinalEntities())
            {
                var eliminar = db.DocumentosG.Find(id);
                db.DocumentosG.Remove(eliminar);
                db.SaveChanges();
            }
        }


    }
}
