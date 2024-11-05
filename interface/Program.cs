using Contacts;

class Program
{
    static void Main()
    {
        
        var cart = new ShoppingCart();

        
        var cartService = new ShoppingCartService(cart);
        var cartSummaryService = new CartSummaryService(cart);

       
        var menuService = new MenuService(cartService, cartSummaryService);

       
        menuService.ShowMenu();
    }
}
