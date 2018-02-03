using System.Collections.Generic;
using System.Linq;

namespace WarehouseKings
{
    public class WarehouseManager
    {
        public List<Store> Stores { get; private set; }
        
        public WarehouseManager()
        {
            Stores = new List<Store>();
        }

        public Store[] GetStoresWithProduct(Product product)
        {
            return Stores.Where(
                store =>
                {
                    var record = store.GetProductRecord(product);
                    return record != null && record.ProductCount > 0;
                }
            ).ToArray();
        }
    }
}