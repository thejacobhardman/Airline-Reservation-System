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

            Console.WriteLine("First Class Seats: ");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(seats[i] ? "Booked " : "Empty ");
            }

            Console.WriteLine("\nEconomy Seats: ");

            for (int i = 5; i < 10; i++)
            {
                Console.Write(seats[i] ? "Booked " : "Empty ");
            }
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
                    Console.Write("\n\nPlease select a seat that you'd like to book. (-1 to quit): ");
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
                        if (firstClassFull && !economyFull)
                        {
                            Console.WriteLine("The First Class section is full. Please select a seat in the Economy section.");
                        } else if (economyFull && !firstClassFull)
                        {
                            Console.WriteLine("The Economy section is full. Please select a seat in the First Class section.");
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
