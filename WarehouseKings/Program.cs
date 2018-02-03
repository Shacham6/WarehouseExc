using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseKings.Exceptions;

namespace WarehouseKings
{
    public class Program
    {
        public static void Main()
        {
            var warehouseManager = new WarehouseManager();
            var stores = new[]
            {
                new Store(warehouseManager, new WorkingHours(0830, 1900), new[]
                {
                    new ProductRecord("Sofa", 20, 1000),
                    new ProductRecord("HD TV", 1000, 500)
                })
            };

            foreach (var store in stores)
                warehouseManager.Stores.Add(store);

            var sofa = new Product("Sofa");
            var r = stores[0].GetProductRecord(sofa);
            Console.WriteLine(r);

            try
            {
                stores[0].Buy(sofa);
            }
            catch (ClosedStoreException ex)
            {
                
            }

            Console.WriteLine(r);
        }
    }
}