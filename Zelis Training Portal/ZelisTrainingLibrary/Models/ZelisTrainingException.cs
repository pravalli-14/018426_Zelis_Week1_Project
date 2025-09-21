using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class ZelisTrainingException : Exception
    {
        public ZelisTrainingException(string errMsg) : base(errMsg)
        {
            
        }
    }
}
