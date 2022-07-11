using PointOfSale;

//Initialized variables
double subTotal = 0;
double salesTax = .06;
double grandTotal = 0;


//Create empty list of store items for StreamReader to populate with products
List<Product> items = new List<Product>();

string filePath = "../../../Products.txt";
StreamReader reader = new StreamReader(filePath);

//Reads through Products txt file, products are added to List<Product> items
while (true)
{
    string line = reader.ReadLine();
    if (line == null) //it pulled out current product and found nothing
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
    int purchaseItem = Validator.Validator.GetUserNumberInt("\nWhat product would you like to add to your cart?");
    int purchaseQuantity = Validator.Validator.GetUserNumberInt("How many would you like?");
    Product[] products = new Product[purchaseQuantity];
    Array.Fill(products, productList[purchaseItem - 1]);
    CartList.AddRange(products);
    Console.WriteLine($"You have chosen: ");
    return CartList;
}

//Display back selected item(s)
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
