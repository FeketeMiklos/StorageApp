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
    }
}
