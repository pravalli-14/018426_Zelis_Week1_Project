using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITraineeRepository
    {
        void AddTrainee(Trainee trainee);
        void UpdateTrainee(int trainingid, int empid, char status);
        void DeleteTrainee(int trainingId, int empId);
        Trainee GetTrainee(int trainingId, int empId);
        List<Trainee> GetAllTrainees();
        List<Trainee> GetTraineesByStatus(char status);
        List<Trainee> GetTraineesByEmpId(int empId);
        List<Trainee> GetTraineesByTrainingId(int trainingId);
    }
}
