using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class StroredProcedures
    {
       
      
        public void GetFreelancers()
        {
            string constring = ConfigurationManager.ConnectionStrings["ProyectoPatronusWebEntities1"].ConnectionString;
            SqlConnection coneccion = new SqlConnection(constring);
            SqlCommand getFreelancer = new SqlCommand("SP_GETFREELANCERS", coneccion);
            getFreelancer.CommandType = CommandType.StoredProcedure;
            getFreelancer.Parameters.AddWithValue("@idTipoUsuario",SqlDbType.Int).Value = 2; //Para usuario Freelancer
        }
    }
}
