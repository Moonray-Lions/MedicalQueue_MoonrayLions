using System;

namespace MedicalQueue_MoonrayLions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ERQueue erQueue = new ERQueue();

            string choice;
            do
            {
                Console.Clear();
                Console.Write(Menu());
                choice = Console.ReadLine(); 

                if (choice.ToUpper() == "A") // ADD PATIENT
                {
                    Console.Write("\nEnter the patient's first name: ");
                    string first = Console.ReadLine();
                    Console.Write("\nEnter the patient's last name: ");
                    string last = Console.ReadLine();
                    Console.Write("\nEnter the patient's priority: ");
                    int priority = int.Parse(Console.ReadLine());

                    erQueue.Enqueue(new Patient(first, last, priority));

                }
                else if (choice.ToUpper() == "P") // PROCCESS CURRENT PATIENT 
                {
                    // REMOVE THE TAIL PATIENT IN ER QUEUE
                }
                else if (choice.ToUpper() == "L") // LIST ALL IN QUEUE
                {
                    // LIST ALL PATIENTS
                }
                // QUIT
            } while (choice != "Q");
        }
        static string Menu()
        {
            return "(A)dd Patient\n" +
                    "(P)rocess Current Patient\n" +
                    "(L)ist All in Queue\n" +
                    "(Q)uit\n\n" +
                    "Enter Your Selection (A, P, L, Q): ";
        }
    }
}
