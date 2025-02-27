namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
//Assignment 2 task 1
            Console.WriteLine("Enter your salary: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your rating from 1 to 10: ");
            double rating = Convert.ToDouble(Console.ReadLine());

            double taxDeduction = 0.1;
            double bonusRate;


            double salary = basicSalary - (basicSalary * taxDeduction);


            if (rating >= 8)

                salary = salary + (salary * 0.2);

            else if (rating >= 5 && rating < 8)

                salary = salary + (salary * 0.1);

            Console.WriteLine("your net salary is :" + salary);
             

            Console.WriteLine("\n");
//Assignment 2 task 2
            Console.WriteLine("\n");

            double totalCost = 0;
            int numTickets = 0;

            while (true)
            {
                Console.WriteLine("Available Ticket Types:\n");
                Console.WriteLine("1. General");
                Console.WriteLine("2. AC ");
                Console.WriteLine("3. Sleeper ");
                Console.WriteLine("4. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.Please enter a number between 1 and 4.");
                    continue;
                }

                if (choice == 4)
                {
                    Console.WriteLine("\nFinal total amount to be paid: Rs." + totalCost);
                    break;
                }

                Console.Write("Enter the number of tickets: ");
                int ticketCount;
                if (!int.TryParse(Console.ReadLine(), out ticketCount) || ticketCount <= 0)
                {
                    Console.WriteLine("Invalid number of tickets. Please enter a positive number.");
                    continue;
                }

                double price = 0;

                switch (choice)
                {
                    case 1:
                        price = 200;
                        Console.WriteLine($"Booking {ticketCount} General ticket");
                        break;
                    case 2:
                        price = 1000;
                        Console.WriteLine($"Booking {ticketCount} AC ticket.");
                        break;
                    case 3:
                        price = 500;
                        Console.WriteLine($"Booking {ticketCount} Sleeper ticket.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select between 1-4.");
                        continue;
                }

                double cost = ticketCount * price;
                totalCost += cost;
                numTickets += ticketCount;

            }
            Console.WriteLine($"Total number of tickets booked: {numTickets}");
            Console.WriteLine($"Total cost  Rs.{totalCost}");




            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

 //Assignment 2 task 3
            
                double[,] wallet =
                {
                {101,10000.50 },
                { 102,950.75},
                { 103,1001.50}
            };
                //bool
                bool res = false;
                while (!res)
                {
                    Console.WriteLine("Enter user id to check wallet Balance");
                    double userId = Convert.ToDouble(Console.ReadLine());

                    for (int i = 0; i < wallet.GetLength(0); i++)
                    {
                        if (wallet[i, 0] == userId)
                        {
                            res = true;
                            Console.WriteLine("Your wallet balace is : " + wallet[i, 1]);
                            break;
                        }
                    }
                    if (!res)
                    {
                        Console.WriteLine("Wrong user Id ");
                    }
                }
             
        }
    }
}
