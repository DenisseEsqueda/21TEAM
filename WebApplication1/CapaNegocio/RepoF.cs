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
    public class RepoF : IRepo<FREF>
    {
        private ProyectoPatronusWebEntities _ct;
        public void Crear(FREF entity)
        {
            _ct.FREFs.Add(entity);
            _ct.SaveChanges();
        }
    }
}
