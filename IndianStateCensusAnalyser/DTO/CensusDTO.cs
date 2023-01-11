using IndianStateCensusAnalyser.DataDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public string state;
        public long population;
        public long area;
        public long density;
        public CensusDTO(StateCodeDataDao stateCodeDataDAO)
        {
            this.serialNumber = stateCodeDataDAO.serialNumber;
            this.stateName = stateCodeDataDAO.stateName;
            this.tin = stateCodeDataDAO.tin;
            this.stateCode = stateCodeDataDAO.stateCode;
        }
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}
