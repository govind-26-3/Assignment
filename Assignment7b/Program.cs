using Assignment7b.Model;

namespace Assignment7b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products1 = new List<Product>
            {
                new Product{ProductId=1,Name="HeadPhone",Category="Wearables",Price=1299},
                new Product{ProductId=2,Name="Rich Dad Poor Dad",Category="Book",Price=599},
                new Product{ProductId=3,Name="Table Fan",Category="Electronics",Price=2500},
                new Product{ProductId=4,Name="Washing Machine",Category="Electronics",Price=20000},

            };

            var filterByCategory = products1.Where(p => p.Price > 1000 && p.Category == "Electronics");

            foreach (var item in filterByCategory)
            {
                
                Console.WriteLine($" PRODUCT NAME:{item.Name}  PRODUCT PRICE:{item.Price} ");
            }
        }
    }
}
