using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTraineeRepository : ITraineeRepository 
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTraineeRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB;
  integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void AddTrainee(Trainee trainee)
        {
            cmd.CommandText = $"insert into Trainee values ({trainee.TrainingId},{trainee.EmpId},'{trainee.Status}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTrainee(int trainingId, int empId)
        {
            cmd.CommandText = $"delete from Trainee where TrainingId = {trainingId} and EmpId = {empId}";
            con.Open();
            cmd.ExecuteNonQuery();  
            con.Close();
        }

        public List<Trainee> GetAllTrainees()
        {
            cmd.CommandText = "select * from Trainee";
            List<Trainee> trainees = new List<Trainee>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.EmpId = (int)reader["EmpId"];
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.Status = (char)reader["Status"].ToString()[0];
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;
        }

        public Trainee GetTrainee(int trainingId, int empId)
        {
            cmd.CommandText = $"select * from Trainee where TrainingId = {trainingId} and EmpId = {empId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Trainee trainee = new Trainee();
                trainee.EmpId = (int)reader["EmpId"];
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.Status = (char)reader["Status"].ToString()[0];
                con.Close();
                return trainee;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such Training Id");
            }
        }

        public List<Trainee> GetTraineesByEmpId(int empId)
        {
            cmd.CommandText = $"select * from Trainee where EmpId = {empId}";
            List<Trainee> trainees = new List<Trainee>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.EmpId = (int)reader["EmpId"];
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.Status = (char)reader["Status"].ToString()[0];
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;
        }

        public List<Trainee> GetTraineesByStatus(char status)
        {
            cmd.CommandText = $"select * from Trainee where Status = '{status}'";
            List<Trainee> trainees = new List<Trainee>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.EmpId = (int)reader["EmpId"];
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.Status = (char)reader["Status"].ToString()[0];
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;
        }

        public List<Trainee> GetTraineesByTrainingId(int trainingId)
        {
            cmd.CommandText = $"select * from Trainee where TrainingId = {trainingId}";
            List<Trainee> trainees = new List<Trainee>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.EmpId = (int)reader["EmpId"];
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.Status = (char)reader["Status"].ToString()[0];
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;
        }

        public void UpdateTrainee(int tid, int empid, char status)
        {
            cmd.CommandText = $"update Trainee set Status = '{status}' where TrainingId = {tid} and EmpId = {empid}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
