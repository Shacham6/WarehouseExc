using System;

namespace WarehouseKings
{
    /// <summary>
    /// This class represents 'Product Information', which currently has no more than just a name
    /// </summary>
    public class Product : IEquatable<Product>
    {
        public string Name { get; private set; }

        public Product(string name)
        {
            Name = name;
        }

        public bool Equals(Product other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}