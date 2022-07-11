using PointOfSale;

//Initialized variables
double subTotal = 0;
double salesTax = .06;
double grandTotal = 0;
bool runProgram = true;
bool keepShopping = true;

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

//MAIN PROGRAM

Console.WriteLine("Welcome to D.A.T Store!");
List<Product> Cart = new List<Product>();
Cart = Cart.Concat(addToCart(items)).ToList();
while (keepShopping)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Shop");
    Console.WriteLine("2. Go to cart");
    Console.WriteLine("3. Proceed to checkout");
    int option = 0;
    while (true)
    {
        option = Validator.Validator.GetUserNumberInt("Enter your choice:");
        if (!Validator.Validator.InRange(option, 1, 3))
        {
            Console.WriteLine("Invalid Selection");
            continue;
        }
        else
        {
            break;
        }
    }
    if (option == 1)
    {
        Console.WriteLine("What would you like to buy?");
        Cart = Cart.Concat(addToCart(items)).ToList();
        continue;
    }
    else if (option == 2)
    {
        Product.Inventory(Cart);
        keepShopping = !Validator.Validator.GetContinue("Proceed to checkout?");
    } 
    else
    {
        Console.WriteLine("Proceeding to checkout");
        break;
    }


}

////Recipt
//static string PrintReceipt()
//{
//    double subtotal = 0;
//    double taxAmount = .06 * subtotal;
//    double grandTotal = subtotal + taxAmount;
//    Console.WriteLine("RECEIPT");
//    Console.WriteLine("==========");
//    Console.WriteLine($"Subtotal:                 ${Math.Round(subtotal, 2)}");
//    Console.WriteLine($"Tax:                      ${Math.Round(taxAmount, 2)}");
//    Console.WriteLine($"Total:                    ${Math.Round(grandTotal, 2)}");
//    return PrintReceipt();
//}





//Method to add items to cart
static List<Product> addToCart(List<Product> productList)
{
    List<Product> CartList = new List<Product>();
    Product.Inventory(productList); // display items
    int purchaseItem = Validator.Validator.GetUserNumberInt("\nWhat product would you like to add to your cart?");
    int purchaseQuantity = Validator.Validator.GetUserNumberInt("How many would you like?");
    CartList.AddRange(Enumerable.Repeat(productList[purchaseItem - 1], purchaseQuantity).ToList());
    Console.WriteLine($"You have chosen: {productList[purchaseItem - 1].Name} x {purchaseQuantity} @ ${productList[purchaseItem - 1].Price} ea. = ${productList[purchaseItem - 1].Price * purchaseQuantity}");
    return CartList;
}

