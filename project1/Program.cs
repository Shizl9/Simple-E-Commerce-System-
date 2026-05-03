namespace project1
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Quantity;
    }
    internal class Program
    {
        List<Product> products = new List<Product>();
        List<Product> cart = new List<Product>();
        void AddToCart() 
        {
            //add products to the list
            Console.WriteLine("Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product p = new Product();
            p.Id = id;
            p.Name = name;
            p.Price = price;
            p.Quantity = quantity;

            products.Add(p);

            Console.WriteLine("Product Added!");
        }

        void ViewProducts()
        {
            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
            }

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add to Cart");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Exit");

                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddToCart();
                        break;
                    case 2:
                        ViewProducts();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
         
           
        }
    }
}
