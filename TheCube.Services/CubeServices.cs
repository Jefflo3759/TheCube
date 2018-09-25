using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TheCube.Models.Domain;

namespace TheCube.Services
{
    public class CubeServices
    {
        public static List<CubeDomain> GetAll()
        {
            List<CubeDomain> result = null;
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.TheCube_SelectAll";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CubeDomain cube = new CubeDomain();
                        cube.Id = (int)rdr["Id"];
                        cube.Size = (int)rdr["Size"];
                        cube.Color = (int)rdr["Color"];
                        //cube.Float = (bool)rdr["Float"];

                        if (result == null)
                        {
                            result = new List<CubeDomain>();
                        }
                        result.Add(cube);


                    }
                }
                return result;
            }
        }

    }
}
