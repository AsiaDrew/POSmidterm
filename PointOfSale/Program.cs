using PointOfSale;

//12 items
//meatball, coffee, hotdog, shelves, lamps, end tables
//desks, oven, pillows, blankets, tv stand, bunk beds
//decorative rocks, cinnamonbuns, shrooms, shoe strings
List<Product> items = new List<Product>();
List < Product > addToCart = new List < Product > ();
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

Product.Inventory(items);


//
//static double subtotals()
//{
//    Product.Inventory(); // display items
//    //Product choice; = new Product.addToList(); //addToList needs to be implemented
//    Console.WriteLine("How many would you like?");
//    double userInput = int.Parse(Console.ReadLine());
//    double subtotal = 0;
//    for (int i = 0; i < userInput; i++)
//    {
//        subtotal += userInput * choice.Price;
//    }
//    return userInput;
//}

static void Tender(double grandTotal)
{
    //tender
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




//MAIN PROGRAM
