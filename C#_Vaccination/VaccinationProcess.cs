using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine
{
    class VaccinationProcess
    {
        private static List<VaccineBenificiers> vac = new List<VaccineBenificiers>();
        
        static void Main(string[] args)
        {
            VaccinationProcess vp = new VaccinationProcess();
            var vacBenif1 = new VaccineBenificiers("siva", 9878909865, "Trichy", 22,(Gender)1);
            var vacBenif2 = new VaccineBenificiers("Aravindh", 8909785412, "Madurai", 23,(Gender)1);
            var vacBenif3 = new VaccineBenificiers("Dhiya", 7890985423, "Chennai", 21,(Gender)2);
            vac.Add(vacBenif1);
            vac.Add(vacBenif2);
            vac.Add(vacBenif3);
            string userChoice;
            do
            {
                Console.WriteLine("---------Wear Mask------Stay Safe----------");
                Console.WriteLine(" Benificiary Registration-->1\n Vaccination-->2 \n VaccineBenificiarsDetails-->3\n Exit-->4");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            vp.BenificiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            vp.Vaccination();
                            break;
                        }
                    case 3:
                        {
                            vp.VaccineBenificiarsDetails();
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(-1);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice!");
                            break;
                        }
                }
                Console.WriteLine("Continue to main menu (yes/no)");
                userChoice = Console.ReadLine().ToLower();
                if(userChoice!="yes"&&userChoice!="no")
                {
                    do
                    {
                        Console.WriteLine("Please enter (yes/no)");
                        userChoice = Console.ReadLine();
                    } while (userChoice != "yes" && userChoice != "no");
                }
            } while (userChoice == "yes");
            Console.ReadKey();
            
        }
        /// <summary>
        /// To Register for Covid Vaccine
        /// </summary>
        public void BenificiaryRegistration()
        {
          string userChoice = "";
          do { 
            Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your phone no");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your city ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            G:
            Console.WriteLine("Enter gender Male-->1\n Female-->2\n Others-->3");
            int gender = int.Parse(Console.ReadLine());
            switch(gender)
            {
                case 1:
                    {
                        gender = ((int)Gender.Male);
                        break;
                    }
                case 2:
                    {
                        gender = ((int)Gender.Female);
                        break;
                    }
                case 3:
                    {
                        gender = ((int)Gender.Others);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter valid choice !!!");
                        goto G;
                    }
            }
            var vacBenif4 = new VaccineBenificiers(name, mobile, city, age, (Gender)gender);
            vac.Add(vacBenif4);
            Console.WriteLine("|----Registration Complete----|");
            Console.WriteLine("Your registration number is {0}", vacBenif4.RegistrationNumber);
            Console.WriteLine("Do you want to continue(yes/no)");
            userChoice = Console.ReadLine();
          } while (userChoice=="yes");
        }
        /// <summary>
        /// To get details about Vaccination.
        /// </summary>
        public void Vaccination()
        {
            string userChoice = "";
            do { 
            Console.WriteLine("|------VACCINATION------|");
            Console.WriteLine("Enter your Registration Number ");
            int regNo = int.Parse(Console.ReadLine());
            int regValue = 0;
            foreach(VaccineBenificiers va in vac)
            {
                if (va.RegistrationNumber == regNo)
                    regValue = regNo;
                {
                    Console.WriteLine("Take vaccination-->a \n Vaccination History-->b \n Next Due Date-->c \n Exit-->d");
                    char userDecision = char.Parse(Console.ReadLine());
                    switch (userDecision)
                    {
                        case 'a':
                            {
                                Console.WriteLine("Select Vaccination type \n CoviShield-->1 \n Covaxin-->2 \n Sputnik-->3");
                                VaccineType vacinType = (VaccineType)int.Parse(Console.ReadLine());
                                var user = new Vaccine(vacinType, DateTime.Now);
                                if (va.VaccineDetail==null)
                                {
                                    va.VaccineDetail = new List<Vaccine>();
                                    va.VaccineDetail.Add(user);
                                    Console.WriteLine("Vaccination Completed...");
                                }
                                    break;
                              
                            }
                            // To Know about next Vaccination History
                            case 'b':
                            {
                                foreach (VaccineBenificiers h in vac)
                                {
                                    if (h.VaccineDetail != null)
                                    {
                                        Console.WriteLine(h.RegistrationNumber + "===>>" + h.Name + " ===>> " + h.VaccineDetail[0].VacType);
                                        Console.WriteLine("--------------------------------------------");
                                            break;
                                    }
  
                                    }
                                break;
                            }
                            // To Know about next due date
                            case 'c':
                            {
                                foreach (VaccineBenificiers nextDueDate in vac)
                                {
                                    if (nextDueDate.VaccineDetail != null)
                                    {
                                        if (nextDueDate.VaccineDetail.Count == 1)
                                        {
                                            Console.WriteLine(nextDueDate.VaccineDetail[0].VaccinationDate);
                                            DateTime due = nextDueDate.VaccineDetail[0].VaccinationDate;
                                            Console.WriteLine("Next due date is :" + due.AddDays(30));
                                        }
                                        else
                                        {
                                            Console.WriteLine("vaccination completed, thanks for the participation");
                                        }
                                    }
                                }
                                break;
                            }
                        case 'd':
                            {

                                Environment.Exit(-1);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid choice");
                                break;
                            }
                    }
                }
            }
            if(regValue==0)
            {
                Console.WriteLine("Invalid Registration Number");
            }
            Console.WriteLine("Do you want to continue(yes/no)");
            userChoice = Console.ReadLine().ToLower();

        } while (userChoice=="yes");


        }
       //ALL VaccineBenificiars details 
        public void VaccineBenificiarsDetails()
        {
            foreach(VaccineBenificiers v in vac)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine($" Registration No : {v.RegistrationNumber}\n Name : {v.Name}\n Mobile No : {v.MobileNo}\n City : {v.City}\n Age : {v.Age}\n Gender : {v.Gen}");
                Console.WriteLine("-----------------------------------------------------------");
            }

        }      
    }
}
