using PointOfSale;

//12 items
//meatball, coffee, hotdog, shelves, lamps, end tables
//desks, oven, pillows, blankets, tv stand, bunk beds
//decorative rocks, cinnamonbuns, shrooms, shoe strings
List<Product> items = new List<Product>();
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

//MAIN PROGRAM
 static double GetItem(double productCount)
{
    Console.WriteLine("How many would you like?");
    double userInput = double.Parse(Console.ReadLine());
    for (int i = 0; i < userInput; i++)
    {
        userInput++;
    }
    return userInput;
}