using System;

namespace WarehouseKings
{
    public class Transaction
    {
        public DateTime Time { get; private set; }
        public Product Product { get; private set; }
        public double Price { get; private set; }
        
        public Transaction(Product product, double price)
        {
            Product = product;
            Time = DateTime.Now;
            Price = price;
        }
    }
}