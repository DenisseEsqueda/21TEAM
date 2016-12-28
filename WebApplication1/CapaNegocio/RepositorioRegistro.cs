using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaNegocio;

namespace CapaNegocio
{
    public class RepositorioRegistro : IRepositorio<RegistroUsuario>
    {
        private ProyectoPatronusWebEntities _Context;

        public RepositorioRegistro()
        {
            //Proyecto_patronusWebEntities1
            _Context = new ProyectoPatronusWebEntities();
        }

        public IEnumerable<RegistroUsuario> Listar
        {
            get
            {
                return _Context.RegistroUsuarios;
            }
        }

        public void Actualizar(RegistroUsuario entity)
        {
            _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

    

        public void Crear(RegistroUsuario entity)
        {
            _Context.RegistroUsuarios.Add(entity);
            _Context.SaveChanges();
        }

        public void Eliminar(RegistroUsuario entity)
        {
            _Context.RegistroUsuarios.Remove(entity);
            _Context.SaveChanges();
        }

        public RegistroUsuario Buscar(int Id)
        {
            var result = (from r in _Context.RegistroUsuarios where r.idUsuario == Id select r).FirstOrDefault();
            return result;
        }


        /**/
        //public void Crear(FREF rs)
        //{
        //    _Context.RegistroUsuarioss.Add(rs);
        //    _Context.SaveChanges();
        //}

        //public IEnumerable<Trabajo> FiltroUsuario(Expression<Func<Trabajo, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
