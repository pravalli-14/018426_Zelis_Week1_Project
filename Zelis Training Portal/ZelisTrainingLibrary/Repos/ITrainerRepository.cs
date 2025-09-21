using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainerRepository
    {
        void NewTrainer(Trainer trainer);
        void UpdateTrainer(int trainerId,Trainer trainer);
        void DeleteTrainer(int trainerId);
        Trainer GetTrainer(int trainerId);
        List<Trainer> GetTrainerByType(string type);
        List<Trainer> GetAllTrainers();
    }
}
