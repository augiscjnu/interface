using System;
using System.Collections.Generic;

namespace Contacts
{
    public class ShoppingCart : IShoppingCart
    {
        private List<Product.Product> _products = new List<Product.Product>();

        public void AddProduct(Product.Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Prekė pridėta: {product}");
        }

        public void RemoveProduct(Product.Product product)
        {
            _products.Remove(product);
            Console.WriteLine($"Prekė pašalinta: {product}");
        }

        public List<Product.Product> GetProducts()
        {
            return _products;
        }
    }
}
