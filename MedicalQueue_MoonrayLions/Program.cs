using System;

namespace MedicalQueue_MoonrayLions
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient head = null;
            Patient tail = null;
            ERQueue erQueue = new ERQueue();

            string choice;
            do
            {
                Console.Clear();
                Console.Write(Menu());
                choice = Console.ReadLine();

                if (choice.ToUpper() == "A") // ADD PATIENT
                {
                    Console.Write("\nEnter the patient's name: ");
                    string name = Console.ReadLine();
                    Console.Write("\nEnter the patient's priority: ");
                    int priority = int.Parse(Console.ReadLine());

                    head = erQueue.Add(head, new Patient(name, priority));

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
