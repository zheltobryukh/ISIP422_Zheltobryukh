using System.Collections.ObjectModel;

namespace ISIP422_Zheltobryukh
{
    public class MainViewModel
    {
        public ProductService ProductService { get; private set; }
        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            ProductService = new ProductService();
            ProductService.SeedTestData();
            Products = new ObservableCollection<Product>(ProductService.GetAll());
        }
    }
}
