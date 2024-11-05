namespace Contacts
{
    public class ShoppingCartService
    {
        private IShoppingCart _cart;

        public ShoppingCartService(IShoppingCart cart)
        {
            _cart = cart;
        }

        public void AddProduct(Product.Product product)
        {
            _cart.AddProduct(product);
        }

        public void RemoveProduct(string productName)
        {
            var product = _cart.GetProducts().FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                _cart.RemoveProduct(product);
            }
            else
            {
                Console.WriteLine($"Prekė su pavadinimu '{productName}' nerasta.");
            }
        }

        public void ViewCart()
        {
            Console.WriteLine("\nKrepšelio turinys:");
            foreach (var product in _cart.GetProducts())
            {
                Console.WriteLine(product);
            }
        }
    }
}
namespace Contacts
{
    public class CartSummaryService
    {
        private IShoppingCart _cart;

        public CartSummaryService(IShoppingCart cart)
        {
            _cart = cart;
        }

        public decimal CalculateTotalPrice()
        {
            return _cart.GetProducts().Sum(p => p.Price);
        }
    }
}
namespace Contacts
{
    public class MenuService
    {
        private ShoppingCartService _cartService;
        private CartSummaryService _cartSummaryService;

        public MenuService(ShoppingCartService cartService, CartSummaryService cartSummaryService)
        {
            _cartService = cartService;
            _cartSummaryService = cartSummaryService;
        }

        public void ShowMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                
                Console.WriteLine("\nPasirinkite veiksmą:");
                Console.WriteLine("1 - Pridėti prekę į krepšelį");
                Console.WriteLine("2 - Pašalinti prekę iš krepšelio");
                Console.WriteLine("3 - Peržiūrėti krepšelio turinį");
                Console.WriteLine("4 - Apskaičiuoti bendrą krepšelio kainą");
                Console.WriteLine("5 - Išeiti");
                Console.Write("Jūsų pasirinkimas: ");

               
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductToCart();
                        break;

                    case "2":
                        RemoveProductFromCart();
                        break;

                    case "3":
                        _cartService.ViewCart();
                        break;

                    case "4":
                        CalculateTotalPrice();
                        break;

                    case "5":
                        isRunning = false;
                        Console.WriteLine("Ačiū, kad naudojotės mūsų paslaugomis!");
                        break;

                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Pasirinkite 1, 2, 3, 4 arba 5.");
                        break;
                }
            }
        }

        private void AddProductToCart()
        {
            Console.Write("Įveskite prekės pavadinimą: ");
            string name = Console.ReadLine();

            Console.Write("Įveskite prekės kainą: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                var product = new Product.Product(name, price);
                _cartService.AddProduct(product);
            }
            else
            {
                Console.WriteLine("Klaida: neteisinga kaina.");
            }
        }

        private void RemoveProductFromCart()
        {
            Console.Write("Įveskite prekės pavadinimą, kurį norite pašalinti: ");
            string name = Console.ReadLine();

            _cartService.RemoveProduct(name);
        }

        private void CalculateTotalPrice()
        {
            decimal total = _cartSummaryService.CalculateTotalPrice();
            Console.WriteLine($"\nBendra krepšelio kaina: {total} EUR");
        }
    }
}
