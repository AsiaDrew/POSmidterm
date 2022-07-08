using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    internal class Interactions
    {
        public static void Tender(double grandTotal)
        {
            //tender take money from customer, check amount, and give change if needed
            Console.WriteLine("How much are you paying with?");
            double tender = double.Parse(Console.ReadLine());
            if (tender >= grandTotal)
            {
                Console.WriteLine($"Thanks, your change is ${Math.Round(tender - grandTotal, 2)} ");
            }
            else if (tender < grandTotal)
            {
                Console.WriteLine($"Thats not enough, {Math.Round(grandTotal - tender, 2)}");
            }
            else
            {
                Console.WriteLine("Invalid, try again.");
            }
        }
        //validate check number
        static string CheckPayment()
        {
            //check
            while (true)
            {
                Console.WriteLine("Please enter your check number: ");
                string checkNumber = Console.ReadLine();
                bool check = double.TryParse($"{checkNumber}", out _);
                if (check)
                {
                    return checkNumber;
                }
                else
                {
                    Console.WriteLine("That check number didnt go through.. try again");
                    continue;
                }
            }
        }
    }
}
