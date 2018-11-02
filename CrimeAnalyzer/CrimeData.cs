using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalyzer
{
    class CrimeData
    {
        /*public CrimeData(string year, string population, string violentCrime, string murder, string rape, string robbery, string aggravatedAssault, string propertyCrime, string burglary, string theft, string motorVehicleTheft)
        {
            Year = year;
            Population = population;
            ViolentCrime = violentCrime;
            Murder = murder;
            Rape = rape;
            AggravatedAssault = aggravatedAssault;
            PropertyCrime = propertyCrime;
            Burglary = burglary;
            Theft = theft;
            MotorVehicleTheft = motorVehicleTheft;
        }
        */
        public int Year
        {
            get;
            set;
        }

        public int Population
        {
            get;
            set;
        }

        public int ViolentCrime
        {
            get;
            set;
        }

        public int Murder
        {
            get;
            set;
        }

        public int Rape
        {
            get;
            set;
        }

        public int Robbery
        {
            get;
            set;
        }

        public int AggravatedAssault
        {
            get;
            set;
        }

        public int PropertyCrime
        {
            get;
            set;
        }

        public int Burglary
        {
            get;
            set;
        }

        public int Theft
        {
            get;
            set;
        }

        public int MotorVehicleTheft
        {
            get;
            set;
        }
    }
}
