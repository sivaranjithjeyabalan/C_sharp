using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine
{
    class Vaccine
    {
        public VaccineType VacType { get; set; }
        public int Dosage { get; set; }
        public DateTime VaccinationDate { get; set; }

        public Vaccine(VaccineType vacType, DateTime vaccinationDate)
        {
            this.VaccinationDate = vaccinationDate;

            this.VacType = vacType;
       
        }
      
    }
    public enum VaccineType
    {
        CoviShield=1,
        Covaxin,
        Sputnik
    }
}
