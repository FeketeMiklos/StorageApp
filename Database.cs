using SQLite;
using StorageApp.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageApp
{
    public class Database
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
            { 
                return;
            }

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Product>();

            var count = await database.Table<Product>().CountAsync();

            //dummy data for testing
            if (count == 0)
            {
                var products = new List<Product>
                {
                    new Product { Name = "Coca Cola", Barcode = "1234", Price = 1.99m, Quantity = 5 },
                    new Product { Name = "Sprite", Barcode = "0987", Price = 1.59m, Quantity = 0 },
                    new Product { Name = "Coca Cola Zero", Barcode = "5678", Price = 2.25m, Quantity = 2 },
                    new Product { Name = "Pepsi", Barcode = "1213", Price = 0.99m, Quantity = 15 },
                    new Product { Name = "Pepsi Cherry", Barcode = "1312", Price = 1.19m, Quantity = 50 }
                };

                await database.InsertAllAsync(products);
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();
            return await database.Table<Product>().ToListAsync();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            await Init();
            return await database.Table<Product>().Where(p => p.Name == name).ToListAsync();
        }
        
        public async Task<List<Product>> GetProductsByBarcodeAsync(string barcode)
        {
            await Init();
            return await database.Table<Product>().Where(p => p.Barcode == barcode).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            await Init();
            return await database.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProductAsync(Product item)
        {
            await Init();
            if (item.Id != 0)
                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
        }

        public async Task<int> DeleteProductAsync(Product item)
        {
            await Init();
            return await database.DeleteAsync(item);
        }
    }
}
