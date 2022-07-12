using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    internal class Interactions
    {
        public static void Tender(double grandTotal, out double tender)
        {
            //tender take money from customer, check amount, and give change if needed
            
            
            while (true)
            {
                Console.WriteLine("How much are you paying with?");
                tender = double.Parse(Console.ReadLine());
                if (tender >= grandTotal)
                {
                    Console.WriteLine($"Thanks, your change is ${Math.Round(tender - grandTotal, 2)} ");
                    break;
                }
                else if (tender < grandTotal)
                {
                    Console.WriteLine($"Thats not enough, you still owe ${Math.Round(grandTotal - tender, 2)}");
                    Console.WriteLine($"Please pay full amount of ${Math.Round(grandTotal, 2)}");
                }
                else
                {
                    Console.WriteLine("Invalid, try again.");
                }
            }

        }
        //validate check number
        public static string CheckPayment(double grandTotal)
        {
            //check
            while (true)
            {
                Console.WriteLine("Please enter your check number: ");
                string checkNumber = Console.ReadLine();
                bool check = double.TryParse($"{checkNumber}", out _);
                if (check)
                {
                    while (true)
                    {
                        Console.WriteLine($"Please fill out check for the exact amount of ${grandTotal}.");
                        Console.Write("$");
                        double.TryParse(Console.ReadLine(), out double checkTotal);
                        if(checkTotal != grandTotal)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    return checkNumber;
                }
                else
                {
                    Console.WriteLine("That check number didnt go through.. try again");
                    continue;
                }
            }
        }

        //credit card:
        ///get credit card number
        public static string GetCreditNumber()
        {
            while (true)
            {
                Console.WriteLine("Please enter your credit card number");
                string creditCardNumber = Console.ReadLine().Trim().ToLower();
                bool isNumeric = double.TryParse($"{creditCardNumber}", out _);

                if (isNumeric && creditCardNumber.Length == 16)
                {
                    return creditCardNumber;
                }
                else
                {
                    Console.WriteLine("That is not a valid credit card number. Please try again.");
                    continue;
                }
            }
        }
        //get expiration month
        public static string GetCreditCardMonth()
        {
            while (true)
            {
                Console.WriteLine("In which month does your credit card expire? Please enter in MM format.");
                string creditCardMonth = Console.ReadLine().Trim().ToLower();
                bool month = double.TryParse($"{creditCardMonth}", out _);
                int monthNum = int.Parse(creditCardMonth);

                if (month && creditCardMonth.Length == 2 && monthNum <= 12)
                {
                    return creditCardMonth;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid expiration date. Please try again.");
                    continue;
                }
            }
        }
        //get expiration year
        public static string GetCreditCardYear()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("In which year does your credit card expire? Please enter in YYYY format");
                string creditCardYear = Console.ReadLine().Trim().ToLower();
                bool year = double.TryParse($"{creditCardYear}", out _);
                int yearNum = int.Parse(creditCardYear);

                if (year && creditCardYear.Length == 4 && yearNum > 2021)
                {
                    return creditCardYear;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid expiration date, try again.");
                    continue;
                }
            }
        }
        //get cvv
        public static int GetCVV()
        {
            while (true)
            {
                Console.WriteLine("Please enter your CVV");
                if(!int.TryParse(Console.ReadLine(), out int cvv) || cvv.ToString().Length != 3)
                {
                    Console.WriteLine("invalid input");
                }
                else
                {
                    return cvv;
                }
                
            }
        }

    }
}
