namespace Contacts
{
    public interface IShoppingCart
    {
        // Prideda prekę į krepšelį
        void AddProduct(Product.Product product);

        // Pašalina prekę iš krepšelio
        void RemoveProduct(Product.Product product);

        // Grąžina visų prekių sąrašą
        List<Product.Product> GetProducts();
    }
}
