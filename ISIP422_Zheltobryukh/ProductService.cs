using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP422_Zheltobryukh
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll() => _products;

        public void AddProduct(Product product) => _products.Add(product);

        public void RemoveProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                _products.Remove(product);
        }

        public void RestockProduct(int id, int amount)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                product.Quantity += amount;
        }

        public bool SellProduct(int id, int amount)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null && product.Quantity >= amount)
            {
                product.Quantity -= amount;
                return true;
            }
            return false;
        }

        public Product FindById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> FindByName(string name) =>
            _products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

        public IEnumerable<Product> FindByCategory(string category) =>
            _products.Where(p => p.Category.ToLower() == category.ToLower());

        public void SeedTestData()
        {
            AddProduct(new Product("Хлеб", 50, 10, "Еда"));
            AddProduct(new Product("Молоко", 70, 5, "Еда"));
            AddProduct(new Product("Телефон", 15000, 2, "Электроника"));
            AddProduct(new Product("Ноутбук", 55000, 1, "Электроника"));
            AddProduct(new Product("Книга", 500, 7, "Книги"));
        }
    }
}
