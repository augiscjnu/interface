namespace Product
{
    public class Product
    {
        // Prekės pavadinimas
        public string Name { get; set; }

        // Prekės kaina
        public decimal Price { get; set; }

        // Konstruktorius prekei su pavadinimu ir kaina
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Užtikrina gražų prekės atvaizdą, kai ją išvedame į konsolę
        public override string ToString()
        {
            return $"{Name} - {Price} EUR";
        }
    }
}
