using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageApp.Resources.Entities
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public Product()
        {
            
        }

        public Product(string name, string barcode, decimal price, decimal quantity)
        {
            Name = name;
            Barcode = barcode;
            Price = price;
            Quantity = quantity;
        }
    }
}
