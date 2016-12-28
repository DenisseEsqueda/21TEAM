using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaNegocio;

namespace CapaNegocio
{
    public class RepositorioTrabajo : IRepositorio<Trabajo>
    {
        //Modelop
        private ProyectoPatronusWebEntities _Context;

        public RepositorioTrabajo()
        {
            //Proyecto_patronusWebEntities1
            _Context = new ProyectoPatronusWebEntities();
        }

        public IEnumerable<Trabajo> Listar
        {
            get
            {
                return _Context.Trabajoes;
            }
        }

        public void Actualizar(Trabajo entity)
        {

            Trabajo employeeToUpdate = _Context.Trabajoes.SingleOrDefault(x => x.idUsuario == entity.idUsuario);
            employeeToUpdate.idUsuario = entity.idUsuario;
            
            _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Crear(Trabajo entity)
        {
            _Context.Trabajoes.Add(entity);
            _Context.SaveChanges();
        }

        public void Eliminar(Trabajo entity)
        {
            _Context.Trabajoes.Remove(entity);
            _Context.SaveChanges();
        }

        public Trabajo Buscar(int Id)
        {
            var result = (from r in _Context.Trabajoes where r.idUsuario == Id select r).FirstOrDefault();
            return result;
        }
    }
}
