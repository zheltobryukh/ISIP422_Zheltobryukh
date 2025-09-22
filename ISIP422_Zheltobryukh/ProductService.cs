using System.Collections.Generic;
using System.Linq;

namespace ISIP422_Zheltobryukh
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly Stack<SaleRecord> _salesHistory = new Stack<SaleRecord>();
        private readonly List<SaleRecord> _salesReport = new List<SaleRecord>();

        public IEnumerable<Product> GetAll() => _products;
        public IEnumerable<SaleRecord> GetReport() => _salesReport;
        public IEnumerable<SaleRecord> GetHistory() => _salesHistory;

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

                var sale = new SaleRecord(product, amount);
                _salesHistory.Push(sale);
                _salesReport.Add(sale);

                return true;
            }
            return false;
        }

        public bool UndoLastSale()
        {
            if (_salesHistory.Count == 0)
                return false;

            var lastSale = _salesHistory.Pop();
            lastSale.Product.Quantity += lastSale.Quantity;
            _salesReport.Remove(lastSale);
            return true;
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
