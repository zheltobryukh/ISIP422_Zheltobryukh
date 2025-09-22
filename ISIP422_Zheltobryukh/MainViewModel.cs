using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP422_Zheltobryukh
{
    public class MainViewModel
    {
        private readonly ProductService _productService;

        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            _productService = new ProductService();
            _productService.SeedTestData();
            Products = new ObservableCollection<Product>(_productService.GetAll());
        }
    }
}
