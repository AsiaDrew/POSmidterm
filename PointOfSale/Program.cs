using PointOfSale;

//12 items
//meatball, coffee, hotdog, shelves, lamps, end tables
//desks, oven, pillows, blankets, tv stand, bunk beds
//decorative rocks, cinnamonbuns, shrooms, shoe strings
List<Product> items = new List<Product>();

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
