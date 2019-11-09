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
                Console.Write(seats[i] + " ");
            }

            Console.WriteLine("\nEconomy Seats: ");

            for (int i = 5; i < 10; i++)
            {
                Console.Write(seats[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            bool isNum;
            string userInput;
            bool[] seats = new bool[10];
            int selectedSeat = 0;

            for (int i = 0; i < 10; i++)
            {
                seats[i] = false;
            }

            do
            {

                printSeats(seats);

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

                seats[selectedSeat - 1] = true;

                Console.Clear();

            } while (selectedSeat != -1);

            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }
}
