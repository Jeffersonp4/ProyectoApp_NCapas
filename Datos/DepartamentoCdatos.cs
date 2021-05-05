
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Datos
{
    public class DepartamentoCdatos
    {
        public List<Departamentos> ListarDepartamentos()
        {
            using(var db = new ProyectoFinalEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Departamentos.ToList();
            }
        }



        public void AgregarDptos(Departamentos dpto)
        {
            using(var db = new ProyectoFinalEntities())
            {
                db.Departamentos.Add(dpto);
                db.SaveChanges();
            }
        }

        public Departamentos consigueDpto(int id)
        {
            using(var db  = new ProyectoFinalEntities())
            {
                //return db.Departamentos.Find(id);
                return db.Departamentos.Where(D => D.IdDepa == id).FirstOrDefault();
            }
        }

        public void Editar(Departamentos dpto )
        {
            using (var db = new ProyectoFinalEntities())
            {

                var editar = db.Departamentos.Find(dpto.IdDepa);

                editar.NombreDepa = dpto.NombreDepa;
                editar.Siglas = dpto.Siglas;
                editar.año = dpto.año;
                db.SaveChanges();
               
            }

               
            
        }

        public void eliminar(int id)
        {
            using (var db = new ProyectoFinalEntities())
            {
                var eliminar = db.Departamentos.Find(id);
                db.Departamentos.Remove(eliminar);
                db.SaveChanges();
            }
        }
    }
}
