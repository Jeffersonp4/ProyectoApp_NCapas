using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuariosDatos
    {
        public List<Usuarios> ListarUsuarios()
        {
            using(var db =  new ProyectoFinalEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Usuarios.ToList();
            }
        }

        public void AgregarUsuario(Usuarios usuario)
        {
            using (var db = new ProyectoFinalEntities())
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        public Usuarios ConsigueUsuario(int id)
        {
            using(var db =  new ProyectoFinalEntities())
            {
                return db.Usuarios.Where(D => D.id == id).FirstOrDefault();

            }
        }

        public void Editar(Usuarios user)
        {
            using(var db = new ProyectoFinalEntities())
            {
                var edita = db.Usuarios.Find(user.id);

                edita.Nombre = user.Nombre;
                edita.Correo = user.Correo;
                edita.Departamento = user.Departamento;
                edita.Cargo = user.Cargo;
                edita.Apellido = user.Apellido;
                edita.Edad = user.Edad;
                edita.IdDepa = user.IdDepa;

                db.SaveChanges();



            }
        }

        public void Eliminar(int id)
        {
            using( var db = new ProyectoFinalEntities())
            {
                var elimina = db.Usuarios.Find(id);
                db.Usuarios.Remove(elimina);
                db.SaveChanges();
            }
        }

    }
}
