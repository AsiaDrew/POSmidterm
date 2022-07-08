using PointOfSale;

//12 items
//meatball, coffee, hotdog, shelves, lamps, end tables
//desks, oven, pillows, blankets, tv stand, bunk beds
//decorative rocks, cinnamonbuns, shrooms, shoe strings
List<Product> items = new List<Product>();
//<<<<<<< HEAD
//List<Product> addToCart = new List<Product>();
//=======

double subTotal = 0;
double salesTax = .06;
double grandTotal = 0;

string filePath = "../../../Products.txt";
StreamReader reader = new StreamReader(filePath);


while (true)
{
    string line = reader.ReadLine();
    if (line == null)//it pulled out current student and found nothing
    {
        break;
    }
    else
    {
        string[] values = line.Split(',');
        Product newProduct = new Product(values[0], values[1], values[2], double.Parse(values[3]));
        items.Add(newProduct);
    }
}

//when finished close it 
reader.Close();



static List<Product> addToCart(List<Product> list)
{
    List<Product> itemList = new List<Product>();
    Product.Inventory(list); // display items
    int choice = Validator.Validator.GetUserNumberInt("What product would you like to add to your cart?");
    itemList.Add(list[choice - 1]); //addToList needs to be implemented
    Console.WriteLine($"You have chosen: ");

    return itemList;
}

    //tender
static void Tender(double grandTotal)
{
    Console.WriteLine("How much are you paying with?");
    double tender = double.Parse(Console.ReadLine());
    if (tender >= grandTotal)
    {
        Console.WriteLine($"Thanks, your change is ${Math.Round(tender - grandTotal, 2)} ");
    }
    else if (tender < grandTotal)
    {
        Console.WriteLine($"Thats not enough, {Math.Round(grandTotal - tender, 2)} id due.");
    }
    else
    {
        Console.WriteLine("Invalid, try again.");
    }
}
    //check
static string CheckPayment()
{
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
//credit card:
///get credit card number
static string GetCreditNumber()
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
static string GetCreditCardMonth()
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
string GetCreditCardYear()
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
static int GetCVV()
{
    while (true)
    {
        Console.WriteLine("Please enter your CVV");
        int cvv = int.Parse(Console.ReadLine());
        return cvv;
    }
}




List<Product> Cart = addToCart(items);
Product.Inventory(Cart);

//static double subtotals()
//{


//    Console.WriteLine("How many would you like?");
//    double userInput = int.Parse(Console.ReadLine());
//    double subtotal = 0;
//    for (int i = 0; i < userInput; i++)
//    {
//        subtotal += userInput * choice.Price;
//    }
//    return userInput;
//}








//MAIN PROGRAM
