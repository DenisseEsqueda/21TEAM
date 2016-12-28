using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaDatos;
using System.Data;
using System.Data.Entity;
using System.Threading;
using System.Web.Cors;
using System.Web.Http.Cors;


namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class APIController : ApiController
    {

        /*PAIS: NOMBRE DE LA TABLA
         */
        // GET: API
        [HttpGet]
        public IEnumerable<PAIS> Paises()
        {
            using (ProyectoPatronusWebEntities entities = new ProyectoPatronusWebEntities())
            {
                /*Paises es el atributo pluralizado de mi tabla*/
                return entities.PAISES.ToList();
            }
        }
        [HttpGet]
        public PAIS Paises(string nom)
        {
            using (ProyectoPatronusWebEntities entities = new ProyectoPatronusWebEntities())
            {
                /*
                 * modelo entties.tabla pluraliada que trae el nombre de paises(atributo de tabla)
                 */
                return entities.PAISES.FirstOrDefault(e => e.nombrePais == nom);
            }
        }





        //public HttpResponseMessage Get(int id)
        //{
        //    using (ProyectoPatronusWebEntities entities = new ProyectoPatronusWebEntities())
        //    {
        //        var entity = entities.PAISES.FirstOrDefault(e => e.idPaises == id);

        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee whith Id = " + id.ToString() + " Not Fond");
        //        }
        //    }
        //}
        //public HttpResponseMessage Paises(string pais = "All")
        //{
        //    using (ProyectoPatronusWebEntities entities = new ProyectoPatronusWebEntities())
        //    {
        //        switch (pais.ToLower())
        //        {
        //            case "all":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.PAISES.ToList());
        //            case "2":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.PAISES.Include(a => a.nombrePais).ToList());//Freelancer
        //            case "3":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                      entities.TipoUsuarios.Where(e => e.idTipoUsuario.ToString() == "3").ToList());//Empresa
        //            default:
        //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
        //                    "Value for usuario must be Male, Female or All. " + usuario + " is invalid.");
        //        }
        //    }
        //    }
    }
}