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

        // ================== Add Product ==================
        void AddProduct()
        {
            try
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Product p = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                products.Add(p);

                Console.WriteLine($"Product {p.Name} Added!");
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }


        // ================== View Products ==================
        void ViewProducts()
        {
            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
            }
        }

        // ================== Search (Overloading) ==================
        Product SearchProduct(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        Product SearchProduct(string name)
        {
            foreach (var p in products)
            {
                if (p.Name.ToLower() == name.ToLower())
                    return p;
            }
            return null;
        }

        // ================== OUT ==================
        bool FindProduct(int id, out Product found)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    found = p;
                    return true;
                }
            }

            found = null;
            return false;
        }


        // ================== Search Menu ==================
        void SearchMenu()
        {
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by Name");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (FindProduct(id, out Product p))
                    Console.WriteLine($"Found: {p.Name}");
                else
                    Console.WriteLine("Not found!");
            }
            else
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                var p = SearchProduct(name);

                if (p != null)
                    Console.WriteLine($"Found: {p.Name}");
                else
                    Console.WriteLine("Not found!");
            }
        }

        // ================== REF ==================
        void UpdateQuantity(ref int quantity, int amount)
        {
            quantity -= amount;
        }

        // ================== Add To Cart ==================
        void AddToCart()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var product = SearchProduct(id);

                if (product == null)
                {
                    Console.WriteLine("Product not found!");
                    return;
                }

                Console.Write("Enter Quantity: ");
                int qty = Convert.ToInt32(Console.ReadLine());

                if (qty > product.Quantity)
                {
                    Console.WriteLine("Insufficient quantity!");
                    return;
                }

                UpdateQuantity(ref product.Quantity, qty);

                cart.Add(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = qty
                });

                Console.WriteLine("Added to cart!");
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }


        // ================== Recursion ==================
        void ShowCartRecursive(int index)
        {
            if (index >= cart.Count)
                return;

            var item = cart[index];
            Console.WriteLine($"{item.Name} - {item.Quantity}");

            ShowCartRecursive(index + 1);
        }

        void ViewCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            ShowCartRecursive(0);
        }


         // ================== Checkout ==================
        void Checkout()
        {
            double total = 0;

            foreach (var item in cart)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine($"Total Price: {total}");
            cart.Clear();
        }



        static void Main(string[] args)
        {
            Program app = new Program();

            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Add To Cart");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Checkout");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Enter your choice:");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: app.AddProduct(); break;
                        case 2: app.ViewProducts(); break;
                        case 3: app.SearchMenu(); break;
                        case 4: app.AddToCart(); break;
                        case 5: app.ViewCart(); break;
                        case 6: app.Checkout(); break;
                        case 7: return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }
            }
         
           
        }
    }
}
