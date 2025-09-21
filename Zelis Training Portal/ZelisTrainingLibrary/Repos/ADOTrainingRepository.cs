using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainingRepository : ITrainingRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTrainingRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB;
  integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void AddTraining(Training training)
        {
            cmd.CommandText = @"INSERT INTO Training 
                        (TrainingId, TrainerId, TechnologyId, StartDate, EndDate) 
                        VALUES (@TrainingId, @TrainerId, @TechnologyId, @StartDate, @EndDate)";
            cmd.Parameters.AddWithValue("@TrainingId", training.TrainingId);
            cmd.Parameters.AddWithValue("@TrainerId", training.TrainerId);
            cmd.Parameters.AddWithValue("@TechnologyId", training.TechnologyId);
            cmd.Parameters.AddWithValue("@StartDate", training.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", training.EndDate);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTraining(int trainingId)
        {
            cmd.CommandText = $"delete from Training where TrainingId = {trainingId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }   

        public List<Training> GetAllTrainings()
        {
            cmd.CommandText = "select * from Training";
            List<Training> trainings = new List<Training>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];
                trainings.Add(training);
            }
            con.Close();
            return trainings;
        }

        public Training GetTraining(int id)
        {
            cmd.CommandText = $"select * from Training where TrainingId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];
                con.Close();
                return training;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such Training Id");
            }
        }

        public List<Training> GetTrainingByTechnologyId(int technologyid)
        {
            cmd.CommandText = $"select * from Training where TechnologyId = {technologyid}";
            List<Training> trainings = new List<Training>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];
                trainings.Add(training);
            }
            con.Close();
            return trainings;
        }

        public List<Training> GetTrainingByTrainerId(int trainerId)
        {
            cmd.CommandText = $"select * from Training where TrainerId = {trainerId}";
            List<Training> trainings = new List<Training>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];
                trainings.Add(training);
            }
            con.Close();
            return trainings;
        }

        public void UpdateTraining(int trainingId, Training training)
        {
            cmd.CommandText = @"UPDATE Training
                        SET TrainerId = @TrainerId,
                            TechnologyId = @TechnologyId,
                            StartDate = @StartDate,
                            EndDate = @EndDate
                        WHERE TrainingId = @TrainingId"; 
            cmd.Parameters.AddWithValue("@TrainingId", training.TrainingId);
            cmd.Parameters.AddWithValue("@TrainerId", training.TrainerId);
            cmd.Parameters.AddWithValue("@TechnologyId", training.TechnologyId);
            cmd.Parameters.AddWithValue("@StartDate", training.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", training.EndDate);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}