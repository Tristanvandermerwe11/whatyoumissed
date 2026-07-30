using System.Collections.Concurrent;

namespace hospitalManagementExample
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Patient> patients = new List<Patient>
            {
                new Patient {id =1 , name = "John Smith", age = 45, disease = "Pneumonia", status = PatientStatus.Admitted },
                new Patient {id =2 , name = "Sarah Jones", age = 30, disease = "Fracture", status = PatientStatus.Discharged },
                new Patient {id =3 , name = "Glynn Rudman", age = 60, disease = "Heart Attack", status = PatientStatus.ICU },
                new Patient {id =4 , name = "Emily Davis", age = 25, disease = "Flu", status = PatientStatus.Admitted },
                new Patient {id =5 , name = "Kyle Weisbrook", age = 70, disease = "Stroke", status = PatientStatus.ICU }
            };

            //Find all patients in ICU 
            var icuPatients = patients.Where(p => p.status == PatientStatus.ICU);

            Console.WriteLine("Patients in ICU");

            foreach(var patient in icuPatients)
            {
                Console.WriteLine($"{ patient.name} - {patient.disease}");
            }

            // sort by age 

            var sortedPatients = patients.OrderBy(p => p.age);

            Console.WriteLine("\nPatients Sorted by Age");

            foreach (var patient in sortedPatients)
            {

                Console.WriteLine($"{patient.name} - Age: {patient.age}");
            }



            //group by status 

            var groupPatients = patients.GroupBy(P => P.status);

            Console.WriteLine("\nPatients Grouped by status: ");

            foreach (var group in groupPatients)
            {
                Console.WriteLine(group.Key); // looks at the key on the enums we created 

                foreach (var patient in group)
                {
                    Console.WriteLine($" - {patient.name}");

                }


            } 

            //Count admitted patients
            int admittedCOunt = patients.Count(P => P.status == PatientStatus.Admitted);

            Console.WriteLine($"\nNumber of admitted Patients: {admittedCOunt}");
        }
    }
}



/*
 Create an application for a car rental service
 The application should utilise enums to determine if a car is available or booked. 
Include a car class that tracks a rental car's:
-Brand
-Colour
-Mileage
-How many doors
- Last serviced (year it was last serviced 
-availabilty 

Include an extension method that determined if the car needs to be servuce 

(assuming a cars needs to be serviced every 2 years)

Populate a list with 8 different types of cars 
USING LinQ to do the following: 

- COunt cars available
- filter cars that have 4 doors
- sort cars by the year that they were last serviced 
- filter the car via brand 
- have an application write out a full report to a .txt file
  
  
 
 */
