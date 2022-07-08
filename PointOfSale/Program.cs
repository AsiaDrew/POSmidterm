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
        Product newProduct = new Product();
        items.Add(newProduct);
    }
}

//when finished close it 
reader.Close();

//
static double subtotals()
{
    //Product.WriteList(); writeList needs to be implemented
    //Product choice; = new Product.addToList(); //addToList needs to be implemented
    Console.WriteLine("How many would you like?");
    double userInput = int.Parse(Console.ReadLine());
    double subtotal = 0;
    for (int i = 0; i < userInput; i++)
    {
        subtotal += userInput * choice.Price;
    }
    return userInput;
}



//MAIN PROGRAM
