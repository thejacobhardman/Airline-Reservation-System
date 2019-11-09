using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System
{
    class Program
    {

        static void printSeats(bool[] seats)
        {

            Console.WriteLine("First Class Seats (Seats 1-5):");

            Console.WriteLine("--------------------------------------");
            Console.Write("| ");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(seats[i] ? "Booked " : "Vacant ");
            }

            Console.Write("|");
            Console.WriteLine("\n--------------------------------------");

            Console.WriteLine("Economy Seats (Seats 6-10):");

            Console.WriteLine("--------------------------------------");
            Console.Write("| ");

            for (int i = 5; i < 10; i++)
            {
                Console.Write(seats[i] ? "Booked " : "Vacant ");
            }

            Console.Write("|");
            Console.WriteLine("\n--------------------------------------");
        }

        static bool checkFirstClass(bool[] seats)
        {
            bool firstClassFull = true;

            for (int i = 0; i < 5; i++)
            {
                if (seats[i] == false)
                {
                    firstClassFull = false;
                    break;
                }
            }

            return firstClassFull;
        }

        static bool checkEconomy(bool[] seats)
        {
            bool economyFull = true;

            for (int i = 5; i < 10; i++)
            {
                if (seats[i] == false)
                {
                    economyFull = false;
                    break;
                }
            }

            return economyFull;
        }

        static void Main(string[] args)
        {
            bool isNum, firstClassFull, economyFull;
            bool[] seats = new bool[10];
            int selectedSeat = 0;
            string userInput;

            for (int i = 0; i < 10; i++)
            {
                seats[i] = false;
            }

            do
            {
                printSeats(seats);

                firstClassFull = checkFirstClass(seats);
                economyFull = checkEconomy(seats);

                isNum = false;
                while (!isNum || selectedSeat > 10 || selectedSeat < 1)
                {
                    Console.Write("\nPlease select a seat that you'd like to book. (-1 to quit): ");
                    isNum = int.TryParse(Console.ReadLine(), out selectedSeat);

                    if (selectedSeat == -1) { break; }
                    if (!isNum || selectedSeat > 10 || selectedSeat < 1)
                    {
                        Console.WriteLine("Please enter a valid integer between 1 and 10.");
                    }
                }

                if (selectedSeat == -1) { break; }

                if (firstClassFull && economyFull)
                {
                    Console.WriteLine("All seats are booked. The next flight leaves in 3 hours.");
                } else
                {
                    if (!seats[selectedSeat - 1])
                    {
                        seats[selectedSeat - 1] = true;
                        Console.WriteLine(selectedSeat <= 5 ? "Seat " + selectedSeat + " has been booked in First Class." : "Seat " + selectedSeat + " has been booked in Economy.");
                    }
                    else
                    {
                        bool userConfirm = false;
                        if (firstClassFull && !economyFull)
                        {
                            while (!userConfirm)
                            {
                                Console.WriteLine("The First Class section is full.");
                                Console.Write("Would you like to book a seat in the economy section instead? (Y/N): ");
                                userInput = Console.ReadLine();

                                if (userInput == "Y" || userInput == "y")
                                {
                                    for (int i = 5; i < 10; i++)
                                    {
                                        if (seats[i] == false)
                                        {
                                            seats[i] = true;
                                            Console.WriteLine("Seat " + (i + 1) + " has been automatically booked in the economy section.");
                                            break;
                                        }
                                    }
                                    userConfirm = true;
                                } else if (userInput == "N" || userInput == "n")
                                {
                                    Console.WriteLine("The next flight leaves in 3 hours.");
                                    userConfirm = true;
                                } else
                                {
                                    Console.WriteLine("Please enter a valid selection.");
                                }
                            }
                        } else if (economyFull && !firstClassFull)
                        {
                            while (!userConfirm)
                            {
                                Console.WriteLine("The Economy section is full.");
                                Console.Write("Would you like to book a seat in the economy section instead? (Y/N): ");
                                userInput = Console.ReadLine();

                                if (userInput == "Y" || userInput == "y")
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (seats[i] == false)
                                        {
                                            seats[i] = true;
                                            Console.WriteLine("Seat " + (i + 1) + " has been automatically booked in the economy section.");
                                            break;
                                        }
                                    }
                                    userConfirm = true;
                                }
                                else if (userInput == "N" || userInput == "n")
                                {
                                    Console.WriteLine("The next flight leaves in 3 hours.");
                                    userConfirm = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid selection.");
                                }
                            }
                        } else
                        {
                            Console.WriteLine("That seat has already been booked. Please select a different seat.");
                        }
                    }
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                Console.Clear();

            } while (selectedSeat != -1);

            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }
}
