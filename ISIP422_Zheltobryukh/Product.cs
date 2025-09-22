using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP422_Zheltobryukh
{
    public class Product
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public bool InStock => Quantity > 0;

        public Product(string name, decimal price, int quantity, string category)
        {
            Id = _nextId++;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}: {Name}, {Price}₽, {Quantity} шт., Категория: {Category}, {(InStock ? "В наличии" : "Нет на складе")}";
        }
    }

}
