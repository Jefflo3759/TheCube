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
                        cube.QuestionId = (int)rdr["QuestionId"];
                        cube.text = (string)rdr["text"];
                        cube.DisplayOrder = (int)rdr["DisplayOrder"];
                        cube.Answer = (string)rdr["Answer"];
                        cube.Result = (string)rdr["Result"];
                        cube.Type = (string)rdr["Type"];
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

        //public static List<ResultsDomain> GetById(int id)
        //{
        //    List<Cub>
        //}


        public static List<CubeDomain> GetAllQuestions()
        {
            List<CubeDomain> result = null;
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.TheCubeQuestions_SelectAll";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CubeDomain cube = new CubeDomain();
                        cube.Id = (int)rdr["Id"];
                        cube.text = (string)rdr["text"];
                        cube.DisplayOrder = (int)rdr["DisplayOrder"];
                        cube.Type = (string)rdr["Type"];
               

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
