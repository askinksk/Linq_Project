using Project4.Entities;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Category> categories = new List<Category>
        {
            new Category { CategoryId=1, CategoryName="Bilgisayar"},
            new Category { CategoryId = 2, CategoryName = "Telefon" },
            new Category { CategoryId = 3, CategoryName = "Televizyon" },
        };

        List<Product> products = new List<Product>
       {
           new Product { ProductId=1, CategoryId=1 ,  ProductName="Hp Laptop", QuantityPerUnit="RTX 4090", UnitPrice=25000, UnitInStock=4},
           new Product { ProductId=2, CategoryId=1 ,  ProductName="MSI Laptop", QuantityPerUnit="96 Gb Ram", UnitPrice=29000, UnitInStock=7},
           new Product { ProductId=3, CategoryId=2 ,  ProductName="Apple", QuantityPerUnit="516 Gb Hafıza", UnitPrice=23000, UnitInStock=0},
           new Product { ProductId=4, CategoryId=3 ,  ProductName="Samsung", QuantityPerUnit="100 ınc", UnitPrice=15000, UnitInStock=1},
           new Product { ProductId=5, CategoryId=1 ,  ProductName="Monster Laptop", QuantityPerUnit="5 Tb SSD", UnitPrice=25000, UnitInStock=6}
       };
        var result = from p in products
                     join c in categories
                     on p.CategoryId equals c.CategoryId
                     where p.UnitPrice>15000
                     orderby p.UnitPrice descending 
                     select new ProductDto { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

        foreach (var productDto in result)
        {
            Console.WriteLine("{0} ----- {1}", productDto.ProductName , productDto.CategoryName);
        }

        //ClassicLinqTest(products);

                     //AscDescTest(products);

                     //FindAllTest(products);

                     //FindTest(products);

                     //AnyTest(products);

                     // Test(products);
    }

    private static void ClassicLinqTest(List<Product> products)
    {
        var result = from p in products
                     where p.UnitPrice < 27000
                     orderby p.UnitPrice descending, p.ProductName ascending
                     select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

        foreach (var product in result)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void AscDescTest(List<Product> products)
    {//Single Line Query
        var result = products.Where(p => p.ProductName.Contains("Laptop")).OrderBy(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
        foreach (var product in result)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void FindAll(List<Product> products)
    {
        var result = products.FindAll(p => p.ProductName.Contains("top"));
        Console.WriteLine(result);
    }

    private static void FindTest(List<Product> products)
    {
        var result = products.Find(p => p.ProductId == 3);
        Console.WriteLine(result.ProductName);
    }

    private static void AnyTest(List<Product> products)
    {
        var result = products.Any(p => p.ProductName == "Hp");
        Console.WriteLine(result);
    }

    private static void Test(List<Product> products)
    {
        Console.WriteLine("Algoritmik---------------");
        foreach (var product in products)
        {
            if (product.UnitPrice > 5000 && product.UnitInStock > 3)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        Console.WriteLine("Linq---------------");

        var result = products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3);

        foreach (var product in result)
        {
            Console.WriteLine(product.ProductName);
        }
        GetProducts(products);
    }

    static List<Product> GetProducts(List<Product> products)
    {
        List<Product> filterProducts = new List<Product>();
        foreach (var product in products)
        {
            if (product.UnitPrice > 5000 && product.UnitInStock > 3)
            {
                filterProducts.Add(product);
            }

        }
        return filterProducts;
    }

    static List<Product> GetProductsLinq(List<Product> products)
    {
        return products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3).ToList();
    }
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
    class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }


    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}