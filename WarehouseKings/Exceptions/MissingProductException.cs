using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseKings.Exceptions
{
    /// <summary>
    /// Represents a case of a missing product
    /// </summary>
    public class MissingProductException : Exception
    {
        public Store[] StoresContainingProduct { get; private set; }
        
        /// <summary>
        /// Creates new exception with option to provide a collection of stores that *do* contain
        /// the product
        /// </summary>
        public MissingProductException(IEnumerable<Store> storesContainingProduct=null)
        {
            if (storesContainingProduct == null)
                storesContainingProduct = new Store[0];

            StoresContainingProduct = storesContainingProduct.ToArray();
        }
    }
}