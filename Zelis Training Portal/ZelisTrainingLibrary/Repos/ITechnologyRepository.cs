using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITechnologyRepository
    {
        void NewTechnology(Technology technology);
        void UpdateTechnology(int techId,Technology technology);
        void DeleteTechnology(int techId);
        Technology GetTechnology(int techId);
        List<Technology> GetTechnologyByLevel(string level);
        List<Technology> GetAllTechnologies();
    }
}
