using System;

namespace MedicalQueue_MoonrayLions
{
    class Program
    {
        static void Main()
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
                    while (string.IsNullOrEmpty(first))
                    {
                        Console.WriteLine("\nMust Enter Name");
                        Console.Write("\nFirst Name: ");
                        first = Console.ReadLine();
                       
                    }
                    Console.Write("\nLast Name: ");
                    string last = Console.ReadLine();
                    while (string.IsNullOrEmpty(last))
                    {
                        Console.WriteLine("\nMust Enter Name");
                        Console.Write("\nLast Name: ");
                        last = Console.ReadLine();

                    }
                    Console.Write("\nPriority (Highest: 1 - Lowest: 5): ");
                    int priority;
                    bool parseSuccess = int.TryParse(Console.ReadLine(), out priority) && 
                        (priority > 0 && priority < 6);
                    while (!parseSuccess)
                    {
                        Console.WriteLine("\nSet Value Between 1 & 5. . .");
                        Console.Write("\nPriority: ");
                        parseSuccess = int.TryParse(Console.ReadLine(), out priority) && 
                            (priority > 0 && priority < 6);
                    }
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
                    Console.WriteLine("\n\n" + erQueue.List());
                    Console.Write("\nPress any key to continue. . .");
                    Console.ReadKey();
                }
            } while (choice.Key != ConsoleKey.Q); // QUIT
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
