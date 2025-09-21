using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainingRepository
    {
        void AddTraining(Training training);
        void UpdateTraining(int trainingId,Training training);
        void DeleteTraining(int trainingId);
        Training GetTraining(int id);
        List<Training> GetAllTrainings();
        List<Training> GetTrainingByTrainerId(int trainerId);
        List<Training> GetTrainingByTechnologyId(int technologyid);
    }
}
