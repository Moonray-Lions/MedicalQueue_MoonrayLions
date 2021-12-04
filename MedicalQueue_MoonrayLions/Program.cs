using System;

namespace MedicalQueue_MoonrayLions
{
    class Program
    {
        static void Main(string[] args)
        {
            ERQueue erQueue = new ERQueue();
            ConsoleKeyInfo choice;
            do
            {
                Console.Clear();
                Console.Write(Menu());
                choice = Console.ReadKey(); 

                if (choice.Key == ConsoleKey.A) // ADD PATIENT
                {
                    Console.Write("\n\nFirst Name: ");
                    string first = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string last = Console.ReadLine();
                    Console.Write("Priority: ");
                    int priority = int.Parse(Console.ReadLine());

                    Console.WriteLine($"\nNumber of Patients in ERQueue: " +
                        $"{erQueue.Enqueue(new Patient(first, last, priority))}");
                    Console.Write("\nPress any key to continue. . .");
                    Console.ReadKey();
                }
                else if (choice.Key == ConsoleKey.P) // PROCCESS CURRENT PATIENT 
                {
                    Patient temp = erQueue.Dequeue();
                    if (temp == null)
                    {
                        Console.WriteLine("\n\nALERT: ER QUEUE IS EMPTY");
                    }
                    else
                    {
                        Console.WriteLine($"\n\nPRIORITY LEVEL {temp} SUCCESSFULLY PROCESSED");
                    }
                    Console.Write("\nPress any key to continue. . .");
                    Console.ReadKey();
                }
                else if (choice.Key == ConsoleKey.L) // LIST ALL IN QUEUE
                {
                    // LIST ALL PATIENTS
                    Console.WriteLine("\n\n" + erQueue.List());
                    Console.Write("\nPress any key to continue. . .");
                    Console.ReadKey();
                }
                // QUIT
            } while (choice.Key != ConsoleKey.Q);
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
