using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;
namespace ZelisTrainingLibrary.Repos
{
    public class ADOTechnologyRepository : ITechnologyRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTechnologyRepository()
        {
            
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void DeleteTechnology(int techId)
        {
            cmd.CommandText = $"delete from Technology where TechnologyId = {techId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Technology> GetAllTechnologies()
        {
            cmd.CommandText = "select * from Technology";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Technology> technologies = new List<Technology>();
            while (reader.Read())
            {
                Technology technology = new Technology();
                technology.TechnologyId = (int)reader["TechnologyId"];
                technology.TechnologyName = (string)reader["TechnologyName"];
                technology.Level = (string)reader["Level"];
                technology.Duration = (int)reader["Duration"];
                technologies.Add(technology);
            }
            con.Close();
            return technologies;
        }

        public Technology GetTechnology(int techId)
        {
            cmd.CommandText = $"select * from Technology where TechnologyId = {techId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Technology technology = new Technology();
                technology.TechnologyId = (int)reader["TechnologyId"];
                technology.TechnologyName = (string)reader["TechnologyName"];
                technology.Level = (string)reader["Level"];
                technology.Duration = (int)reader["Duration"];
                con.Close();
                return technology;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such Technology Id");
            }
        }

        public List<Technology> GetTechnologyByLevel(string level)
        {
            cmd.CommandText = $"select * from Technology where Level = '{level}'";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Technology> technologies = new List<Technology>();
            while (reader.Read())
            {
                Technology technology = new Technology();
                technology.TechnologyId = (int)reader["TechnologyId"];
                technology.TechnologyName = (string)reader["TechnologyName"];
                technology.Level = (string)reader["Level"];
                technology.Duration = (int)reader["Duration"];
                technologies.Add(technology);
            }
            con.Close();
            return technologies;
        }

        public void NewTechnology(Technology technology)
        {
            cmd.CommandText = $"insert into Technology values ({technology.TechnologyId}, '{technology.TechnologyName}','{technology.Level}',{technology.Duration})";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTechnology(int techId, Technology technology)
        {
            cmd.CommandText = $"update Technology set TechnologyName = '{technology.TechnologyName}', Level = '{technology.Level}', Duration = {technology.Duration} where TechnologyId = {techId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
