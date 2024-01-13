using System.Xml.Linq;

namespace ECommerceAPI.Models.Repositories
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Mens Watch", Category = "Mens", Price = 99.99 },
            new Product { Id = 2, Name = "Womens Watch", Category = "Womens", Price = 119.99 },
            new Product { Id = 3, Name = "Smartphone", Category = "Electronics", Price = 1299.99 },
            new Product { Id = 4, Name = "Laptop", Category = "Electronics", Price = 1749.00 },
            new Product { Id = 5, Name = "Running Shoes", Category = "Footwear", Price = 79.99 },
            new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 34.99 },
            new Product { Id = 7, Name = "Camera", Category = "Electronics", Price = 695.95 },
            new Product { Id = 8, Name = "Mens T-Shirt", Category = "Mens", Price = 24.95 },
            new Product { Id = 9, Name = "Womens Dress", Category = "Womens", Price = 129.99 },
            new Product { Id = 10, Name = "Headphones", Category = "Electronics", Price = 59.95 },
        };

        public static List<Product> GetProducts()
        {
            return products;
        }

        public static bool ProductExists(int id)
        {
            return products.Any(x => x.Id == id);
        }

        public static Product? GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public static Product? GetProductByName(string name)
        {
            return products.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(x.Name) &&
                x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddProduct(Product product)
        {
            int maxId = products.Max(x => x.Id);
            product.Id = maxId + 1;

            products.Add(product);
        }

        public static void UpdateProduct(Product product)
        {
            var productToUpdate = products.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}