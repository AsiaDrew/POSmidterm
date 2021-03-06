using PointOfSale;

//Initialized variables
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

while (runProgram)
{
    Console.WriteLine("Welcome to D.A.T Store!");
    List<Product> Cart = new List<Product>();
    Cart = Cart.Concat(addToCart(items)).ToList();
    while (keepShopping)
    {
        Console.WriteLine("\nWhat would you like to do?");
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
            Console.Clear();
            Console.WriteLine("What would you like to buy?");
            Cart = Cart.Concat(addToCart(items)).ToList();
            continue;
        }
        else if (option == 2)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Your Cart:");
                Console.WriteLine("---------------------------------------");
                ShowCart(Cart);
                if (Validator.Validator.GetContinue("Remove anything from cart?") && Cart.Count > 0)
                {
                    Console.Clear();
                    RemoveFromCart(Cart);
                }
                else if (Cart.Count <= 0)
                {
                    Console.WriteLine("Cart is empty.");
                    break;
                }
                else
                {
                    break;
                }
            }
            if (Cart.Count <= 0)
            {
                continue;
            }
            keepShopping = !Validator.Validator.GetContinue("\nProceed to checkout?");
            Console.Clear();
        }
        else
        {
            Console.Clear();
            break;
        }


    }
    //CHECKOUT HAS BEGUN
    Console.WriteLine("Proceeding to checkout");
    double grandTotal = Math.Round(Cart.Sum(p => p.Price) * 1.06, 2);
    Console.WriteLine("-------------------------------------");
    ShowCart(Cart);
    Console.WriteLine($"\nYour Total is : ${Math.Round(grandTotal, 2)}");
    Console.WriteLine("\nHow would you like to pay?");
    Console.WriteLine("1. Cash");
    Console.WriteLine("2. Check");
    Console.WriteLine("3. Credit Card");
    while (true)
    {
        //Validate payment choice
        int response = Validator.Validator.GetUserNumberInt("Enter your choice:");
        if (!Validator.Validator.InRange(response, 1, 3))
        {
            Console.WriteLine("Invalid Selection");
            continue;
        }
        //Pay with cash
        if (response == 1)
        {
            Interactions.Tender(grandTotal, out double tender);
            PrintReceipt(Cart);
            Console.WriteLine("{0,-29}{1,-7}", "Payment Method:", "Cash");
            Console.WriteLine("{0,-29}{1,-7}", "Amount Tendered:", "$" + tender);
            Console.WriteLine("{0,-29}{1,-7}", "Change Due:", "$" + Math.Round(tender - grandTotal, 2));

            break;
        }
        //pay with check
        else if (response == 2)
        {
            string checkNumber = Interactions.CheckPayment(grandTotal);
            PrintReceipt(Cart);
            Console.WriteLine("{0,-29}{1,-7}", "Payment Method:", "Check");
            Console.WriteLine("{0,-29}{1,-7}", "Check Number:", checkNumber);
            break;
        }
        //pay with card
        else if (response == 3)
        {
            string cardNumber = Interactions.GetCreditNumber();
            string cardMonth = Interactions.GetCreditCardMonth();
            string cardYear = Interactions.GetCreditCardYear();
            int cardCVV = Interactions.GetCVV();
            PrintReceipt(Cart);
            Console.WriteLine("Payment Method: Credit Card");
            Console.WriteLine($"Card Number: {cardNumber}");
            Console.WriteLine($"Expiration Date: {cardMonth} / {cardYear}");
            Console.WriteLine($"CVV : {cardCVV}");
            break;
        }
    }
    if (!Validator.Validator.GetContinue("\nThank you for you purchase! Would you like to start a new order?"))
    {
        Console.Clear();
        Console.WriteLine("Goodbye! Thank you for shopping at D.A.T. Store!");
        runProgram = false;
    }
    else
    {
        Console.Clear();
    }
}

//METHODS------------------------------------------------------------------------------

//Receipt
static void PrintReceipt(List<Product> cart)
{
    double subtotal = cart.Sum(p => p.Price);
    double taxAmount = .06 * subtotal;
    double grandTotal = subtotal + taxAmount;
    Console.WriteLine("\nRECEIPT");
    Console.WriteLine("=========================================");
    ShowCart(cart);
    Console.WriteLine("=========================================");
    Console.WriteLine("{0,-29}{1,-7}", "Subtotal:", $"${Math.Round(subtotal, 2)}");
    Console.WriteLine("{0,-29}{1,-7}", $"Tax:", $"${Math.Round(taxAmount, 2)}");
    Console.WriteLine("{0,-29}{1,-7}", "Total", $"${Math.Round(grandTotal, 2)}");
}

static void ShowCart(List<Product> cart)
{

    var item = cart.GroupBy(p => p.Name);
    int index = 1;
    foreach (var grp in item)
    {
        
        Console.WriteLine("{0, -3}{1,-20} {2,-7} {3,-7} ",index, grp.Key, $"x{grp.Count()}", $"${grp.Count() * grp.First().Price:N2}");
        index++;
    }
}

//Add items to cart
static List<Product> addToCart(List<Product> productList)
{
    List<Product> CartList = new List<Product>();
    Console.WriteLine("{0, -4}{1, -20}{2, -10}{3, -78}{4, -8}", "#", "Name", "Category", "Description", "Price");
    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
    Product.Inventory(productList); // display items
    int purchaseItem = 0;
    while (true)
    {
        purchaseItem = Validator.Validator.GetUserNumberInt("\nWhat product would you like to add to your cart? (Enter a #)");
        if (!Validator.Validator.InRange(purchaseItem, 1, productList.Count()))
        {
            Console.WriteLine("That product is not an option, please select again.");
        }
        else
        {
            break;
        }
    }
    int purchaseQuantity = 0;
    while (true)
    {
        purchaseQuantity = Validator.Validator.GetUserNumberInt("How many would you like?");
        if (purchaseQuantity <= 0)
        {
            Console.WriteLine("Please enter a positive quantity");
        }
        else
        {
            break;
        }
    }
    //line total
    CartList.AddRange(Enumerable.Repeat(productList[purchaseItem - 1], purchaseQuantity).ToList());
    Console.WriteLine($"You have chosen: {productList[purchaseItem - 1].Name} x {purchaseQuantity} @ ${productList[purchaseItem - 1].Price} ea. = ${(productList[purchaseItem - 1].Price * purchaseQuantity):N2}");
    return CartList;
}
//Remove from cart
static void RemoveFromCart(List<Product> cartList)
{
     ShowCart(cartList);
    var item = cartList.GroupBy(p => p.Name);
    //picked an item within their cart
    int removeItem = 0;
    while (true)
    {
        removeItem = Validator.Validator.GetUserNumberInt("\nWhat product would you like to remove from your cart? (Enter a #)");
        if (!Validator.Validator.InRange(removeItem, 1, item.Count()))
        {
            Console.WriteLine("That product is not an option, please select again.");
        }
        else
        {
            break;
        }
    }
    int index = 1;
    Product result = null;
    foreach (var grp in item)
    {
        if (index == removeItem)
        {
            result = grp.First();
        }
        index++;

    }
    int removeQuantity = 0;
    while (true)
    {
        removeQuantity = Validator.Validator.GetUserNumberInt("How many would you like to remove?");
        if (removeQuantity <= 0 || removeQuantity > cartList.Where(i => i.Name == result.Name).Count())
        {
            Console.WriteLine("Please enter a positive quantity");
        }
        else
        {
            break;
        }
    }
    cartList.RemoveRange(cartList.IndexOf(result), removeQuantity);
}
