using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCube.Models.Domain;
using TheCube.Models.Request;

namespace TheCube.Services
{
    public class CubeResultsServices
    {
        public static List<ResultsDomain> GetById(int Id)
        {
            List<ResultsDomain> result = null;
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.SaveResults_GetById";
                cmd.Parameters.AddWithValue("@Id", Id);
        

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ResultsDomain results = new ResultsDomain();
                    results.Id = (int)rdr["Id"];
                    results.Username = (string)rdr["Username"];
                    results.Results = (string)rdr["Results"];


                    if (result == null)
  
                    {
                        result = new List<ResultsDomain>();
                    }
                    result.Add(results);


                }
            }
            return result;
        }

    

        public static int Create(TheCubeCreateRequest request)
        {
            int Id;
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.SaveResults_Insert";
                    cmd.Parameters.AddWithValue("@Results", request.Results);
                    cmd.Parameters.AddWithValue("@UserName", request.UserName);
                    cmd.Parameters.Add("@Id",SqlDbType.Int).Direction=ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    Id = (int)cmd.Parameters["@Id"].Value;
                    
                }
                return Id;
            }
        }


        public static void Update(TheCubeUpdateRequest request)
        {
        
            var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.SaveResults_Update";


                    cmd.Parameters.AddWithValue("@UserName", request.UserName);
                    cmd.Parameters.AddWithValue("@Id", request.Id);

                    cmd.ExecuteNonQuery();



                }
    
            }
        }

        public static void Delete(int Id)
        {

                var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.SaveResults_Delete";
                        cmd.Parameters.AddWithValue("@Id", Id);

                        cmd.ExecuteNonQuery();



                    }

                }
            }
        }
}
