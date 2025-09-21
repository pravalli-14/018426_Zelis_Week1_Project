using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainerRepository : ITrainerRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTrainerRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB;
  integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void DeleteTrainer(int trainerId)
        {
            cmd.CommandText = $"delete from Trainer where TrainerId = {trainerId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Trainer> GetAllTrainers()
        {
            cmd.CommandText = "select * from Trainer";
            List<Trainer> trainers = new List<Trainer>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.TrainerEmail = (string)reader["TrainerEmail"];
                trainer.TrainerType = (string)reader["TrainerType"];
                trainer.TrainerPhoneNo = (string)reader["TrainerPhoneNo"];
                trainers.Add(trainer);
            }
            con.Close() ;
            return trainers ;
        }

        public Trainer GetTrainer(int trainerId)
        {
            cmd.CommandText = $"select * from Trainer where TrainerId = {trainerId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.TrainerEmail = (string)reader["TrainerEmail"];
                trainer.TrainerType = (string)reader["TrainerType"];
                trainer.TrainerPhoneNo = (string)reader["TrainerPhoneNo"];
                con.Close();
                return trainer;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such Technology Id");
            }
        }

        public List<Trainer> GetTrainerByType(string type)
        {
            cmd.CommandText = $"select * from Trainer where TrainerType = '{type}'";
            List<Trainer> trainers = new List<Trainer>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.TrainerEmail = (string)reader["TrainerEmail"];
                trainer.TrainerType = (string)reader["TrainerType"];
                trainer.TrainerPhoneNo = (string)reader["TrainerPhoneNo"];
                trainers.Add(trainer);
            }
            con.Close();
            return trainers;
        }

        public void NewTrainer(Trainer trainer)
        {
            cmd.CommandText = $"insert into Trainer values ({trainer.TrainerId},'{trainer.TrainerName}','{trainer.TrainerType}','{trainer.TrainerEmail}','{trainer.TrainerPhoneNo}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTrainer(int trainerId, Trainer trainer)
        {
            cmd.CommandText = $"update Trainer set TrainerName = '{trainer.TrainerName}', TrainerType = '{trainer.TrainerType}', TrainerEmail = '{trainer.TrainerEmail}', TrainerPhoneNo = '{trainer.TrainerPhoneNo}' where TrainerId = {trainerId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
