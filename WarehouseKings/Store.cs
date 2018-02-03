using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseKings.Exceptions;

namespace WarehouseKings
{
    public class Store
    {
        private static double MAX_CASH_FOR_DAY = 10000;
        
        private WarehouseManager _manager;
        private WorkingHours _workingHours;
        private List<ProductRecord> _records;
        private List<Transaction> _transactions = new List<Transaction>();
        
        
        /// <summary>
        /// Creates a new store
        /// </summary>
        /// <param name="manager">manager of the chain of stores, that this store is part of</param>
        /// <param name="workingHours">represents opening and closing hours</param>
        /// <param name="records">current inventory of products</param>
        public Store(WarehouseManager manager, WorkingHours workingHours, IEnumerable<ProductRecord> records)
        {
            _manager = manager;
            _workingHours = workingHours;
            _records = records.ToList();
        }

        /// <summary>
        /// seaches the product records of the store and returns it for a given product
        /// </summary>
        /// <param name="product">Product object to find</param>
        /// <returns>ProductRecord object if found or null if not</returns>
        public ProductRecord GetProductRecord(Product product)
        {
            return _records
                .FirstOrDefault(record => record.Product.Equals(product));
        }
        
        /// <summary>
        /// Buyes a product from this store
        /// </summary>
        /// <returns>Product object containing info about the bought product</returns>
        /// <exception cref="ClosedStoreException">thrown when the store is closed</exception>
        /// <exception cref="MissingProductException">thrown when the store is missing the product</exception>
        public Product Buy(Product product)
        {
            // check time at the begining of this function and pass it to other funcs needing the time
            // so we won't 'kick out' a customer that entered a bit before closing time
            var currentTime = DateTime.Now;
            if (!IsOpen(currentTime))
                throw new ClosedStoreException();

            ProductRecord record = GetProductRecord(product);
            if (record == null || record.ProductCount < 1)
                throw new MissingProductException(_manager.GetStoresWithProduct(product));
                    
            // valid product purchase request
            _transactions.Add(new Transaction(record.Product, record.ProductPrice));
            record.ProductCount--;
            
            // check if we need to restock now
            if (record.ProductCount < 1)
                record.Restock(20); // for now lets keep restocking 20 units each time

            return record.Product;
        }

        /// <summary>
        /// Checks if store is open by working hours and by max-cash-for-day
        /// </summary>
        private bool IsOpen(DateTime currentTime)
        {
            return _workingHours.IsCurrentlyWorkingHours(currentTime) 
                   && !IsStoreReachedMaxCashToday(currentTime);
        }
        
        private bool IsStoreReachedMaxCashToday(DateTime currentTime)
        {
            // calc money made today
            double moneyMadeToday = _transactions
                .Where(trans => trans.Time.Date == currentTime.Date)
                .Select(trans => trans.Price)
                .Aggregate(0.00, (acc, currentPrice) => acc + currentPrice);
            
            return moneyMadeToday >= MAX_CASH_FOR_DAY;
        }
    }
}