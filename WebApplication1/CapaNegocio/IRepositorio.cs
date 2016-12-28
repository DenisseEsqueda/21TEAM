using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaNegocio;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace CapaNegocio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> Listar { get; }
        void Crear(T entity);
        void Eliminar(T entity);
        void Actualizar(T entity);
        T Buscar(int Id);
    }

    public interface IRepo<T> where T : class
    {
        void Crear(T entity);
    }

    //public class RepositorioRegistro: IRepositorio<RegistroUsuario> 
    //{
    //    private Proyecto_patronusWebEntities1 _Context;

    //    public RepositorioRegistro()
    //    {
    //        _Context =new Proyecto_patronusWebEntities1();
    //    }

    //    public IEnumerable<RegistroUsuario> Listar
    //    {
    //        get
    //        {
    //            return _Context.RegistroUsuarios;
    //        }
    //    }

    //    public void Actualizar(RegistroUsuario entity)
    //    {
    //        _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
    //        _Context.SaveChanges();
    //    }

    //    public void Crear(RegistroUsuario entity)
    //    {
    //        _Context.RegistroUsuarios.Add(entity);
    //        _Context.SaveChanges();
    //    }

    //    public void Eliminar(RegistroUsuario entity)
    //    {
    //        _Context.RegistroUsuarios.Remove(entity);
    //        _Context.SaveChanges();
    //    }

    //    public RegistroUsuario Buscar(int Id)
    //    {
    //        var result = (from r in _Context.RegistroUsuarios where r.idUsuario == Id select r).FirstOrDefault();
    //        return result;
    //    }

    //}
}
