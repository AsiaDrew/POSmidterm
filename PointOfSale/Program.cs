﻿using PointOfSale;

//Initialized variables
//double subTotal = 0;
//double salesTax = .06;
//double grandTotal = 0;
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
    Console.WriteLine("{0, -4}{1, -20}{2, -10}{3, -78}{4, -8}", "#", "Name", "Item", "Desctription", "Price");
    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
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
            Console.WriteLine("Your Cart:");
            Console.WriteLine("-------------------------------------------------");
            ShowCart(Cart);
            keepShopping = !Validator.Validator.GetContinue("Proceed to checkout?");
        }
        else
        {
            Console.WriteLine("Proceeding to checkout");
            //Console.Clear();
            break;
        }


    }
    //CHECKOUT HAS BEGUN
    double grandTotal = Cart.Sum(p => p.Price) * 1.06;
    Console.WriteLine("----------------------------------------------------------------------------------------------");
    ShowCart(Cart);
    Console.WriteLine($"Your Total is : ${Math.Round(grandTotal, 2)}");
    Console.WriteLine("How would you like to pay?");
    Console.WriteLine("1. Tender");
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
            Console.WriteLine("{0,-29}{1,-7}", $"Amount Tendered:", "$" + tender);
            Console.WriteLine("{0,-29}{1,-7}", $"Change Due:", "$" + Math.Round(tender - grandTotal, 2));

            break;
        }
        //pay with check
        else if (response == 2)
        {
            string checkNumber = Interactions.CheckPayment();
            PrintReceipt(Cart);
            Console.WriteLine("{0,-29}{1,-7}", "Payment Method:", "Check");
            Console.WriteLine("{0,-29}{1,-7}", $"Check Number:", checkNumber);

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
    runProgram = Validator.Validator.GetContinue("Thank you for you purchase! Would you like to start a new order?");
    Console.Clear();

}










//Recipt
static void PrintReceipt(List<Product> cart)
{
    double subtotal = cart.Sum(p => p.Price);
    double taxAmount = .06 * subtotal;
    double grandTotal = subtotal + taxAmount;
    Console.WriteLine("RECEIPT");
    Console.WriteLine("=========================================");
    ShowCart(cart);
    Console.WriteLine("=========================================");
    Console.WriteLine("{0,-29}{1,-7}", "Subtotal:", $"${Math.Round(subtotal, 2)}");
    Console.WriteLine("{0,-29}{1,-7}", $"Tax:",$"${Math.Round(taxAmount, 2)}");
    Console.WriteLine("{0,-29}{1,-7}", "Total", $"${ Math.Round(grandTotal, 2)}");
}

static void ShowCart(List<Product> cart)
{

    var item = cart.GroupBy(p => p.Name);
    foreach (var grp in item)
    {
        Console.WriteLine("{0,-20} {1,-7} {2,-7} ", grp.Key, $"x{grp.Count()}",$"${grp.Count() * grp.First().Price:N2}");
    }
}



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

void PrintPayment(string method, string creditCardNumber, string creditCardMonth, string creditCardYear, int cvv, string checkNumber, double cashTender, double grandTotal)
{
    if (method == "credit")
    {
        Console.WriteLine("Payment Method: Credit Card");
        Console.WriteLine($"Card Number: {creditCardNumber}");
        Console.WriteLine($"Expiration Date: {creditCardMonth} / {creditCardYear}");
        Console.WriteLine($"CVV : {cvv}");
    }
    else if (method == "check")
    {
        Console.WriteLine("Payment Method: Check");
        Console.WriteLine($"Check Number: {checkNumber}");
    }
    else if (method == "cash")
    {
        Console.WriteLine("Payment Method:  Cash");
        Console.WriteLine($"Amount Tendered: ${cashTender}");
        Console.WriteLine($"Change Due: \t ${Math.Round(cashTender - grandTotal, 2)}");
    }
    else
    {
        Console.WriteLine("Payment Method:  Five finger discount.");
    }
    Console.WriteLine("Thank you for shopping with us.");
}














