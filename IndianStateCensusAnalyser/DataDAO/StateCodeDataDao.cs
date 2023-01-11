using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser.DataDAO
{
    public class StateCodeDataDao
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public StateCodeDataDao(int serialNumber, string stateName, int tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
