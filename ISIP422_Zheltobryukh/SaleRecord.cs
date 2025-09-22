using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP422_Zheltobryukh
{
    public class SaleRecord
    {
        public Product Product { get; }
        public int Quantity { get; }
        public decimal TotalPrice => Product.Price * Quantity;

        public SaleRecord(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Product.Name} - {Quantity} шт. на сумму {TotalPrice}₽";
        }
    }
}

