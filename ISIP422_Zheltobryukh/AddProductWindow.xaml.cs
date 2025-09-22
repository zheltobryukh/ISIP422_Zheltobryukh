using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ISIP422_Zheltobryukh
{
    public partial class AddProductWindow : Window
    {
        public Product NewProduct { get; private set; }

        public AddProductWindow()
        {
            InitializeComponent();
            CategoryComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            decimal price;
            int quantity;
            string category = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название товара.");
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text.Trim(), out quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество.");
                return;
            }

            NewProduct = new Product(name, price, quantity, category);
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
