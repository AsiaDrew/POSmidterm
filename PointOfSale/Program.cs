using PointOfSale;

//Create list of 12 store items
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
    if (line == null)//it pulled out current product and found nothing
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

//Close reader
reader.Close();


//Method to add items to cart
static List<Product> addToCart(List<Product> productList)
{
    List<Product> CartList = new List<Product>();
    Product.Inventory(productList); // display items
    int choice = Validator.Validator.GetUserNumberInt("\nWhat product would you like to add to your cart?");
    int userInput = Validator.Validator.GetUserNumberInt("How many would you like?");
    Product[] products = new Product[userInput];
    Array.Fill(products, productList[choice - 1]);
    CartList.AddRange(products);
    Console.WriteLine($"You have chosen: ");
    return CartList;
}

  



//Display selected item
List<Product> Cart = addToCart(items);
Product.Inventory(Cart);


//Method to calculate subtotal
//static double subtotals()
//{
//    Console.WriteLine("How many would you like?");
//    double userInput = int.Parse(Console.ReadLine());
//    double subtotal = 0;
//    for (int i = 0; i < userInput; i++)
//{
//    subtotal += userInput * choice.Price;
//}
//    return userInput;
//}








//MAIN PROGRAM
