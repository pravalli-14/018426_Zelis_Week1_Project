using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public int TrainerId { get; set; }
        public int TechnologyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate  { get; set; }
    }
}
