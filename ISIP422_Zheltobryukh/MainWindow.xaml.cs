using System.Linq;
using System.Windows;

namespace ISIP422_Zheltobryukh
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddProductWindow();
            if (addWindow.ShowDialog() == true)
            {
                var product = addWindow.NewProduct;
                _viewModel.ProductService.AddProduct(product);
                _viewModel.Products.Add(product);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product product)
            {
                _viewModel.ProductService.RemoveProduct(product.Id);
                _viewModel.Products.Remove(product);
            }
        }

        private void Restock_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product product)
            {
                _viewModel.ProductService.RestockProduct(product.Id, 5);
                ProductsList.Items.Refresh();
            }
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product product)
            {
                if (_viewModel.ProductService.SellProduct(product.Id, 1))
                {
                    ProductsList.Items.Refresh();
                    MessageBox.Show("Товар продан!");
                }
                else
                {
                    MessageBox.Show("Недостаточно товара на складе!");
                }
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ProductService.UndoLastSale())
            {
                ProductsList.Items.Refresh();
                MessageBox.Show("Последняя продажа отменена!");
            }
            else
            {
                MessageBox.Show("Нет продаж для отмены.");
            }
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            var report = _viewModel.ProductService.GetReport();
            if (!report.Any())
            {
                MessageBox.Show("Продаж пока нет.");
                return;
            }

            string text = "Отчёт о продажах:\n";
            foreach (var sale in report)
                text += sale + "\n";

            text += $"\nИтого: {report.Sum(s => s.TotalPrice)}₽";
            MessageBox.Show(text);
        }
    }
}
