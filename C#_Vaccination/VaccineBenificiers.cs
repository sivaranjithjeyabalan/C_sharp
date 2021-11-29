using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine
{
    class VaccineBenificiers
    {
        private static int _registrationNumber = 1001;
        public int RegistrationNumber;
        public string Name { get; set; }
        public long MobileNo { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public Gender Gen { get; set; }
        public List<Vaccine> VaccineDetail { get; set; }


        public VaccineBenificiers(string name,long mobile,string city,int age,Gender gender)
        {
            this.Name = name;
            this.MobileNo = mobile;
            this.City = city;
            this.Age = age;
            this.Gen = gender;
            this.RegistrationNumber = _registrationNumber;
            _registrationNumber++;

        }
        
    }
    public enum Gender
    {
        Male=1,
        Female,
        Others
    }
}
