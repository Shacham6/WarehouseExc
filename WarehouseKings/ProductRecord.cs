namespace WarehouseKings
{
    public class ProductRecord
    {
        public Product Product { get; private set; }
        public int ProductCount { get; set; }
        public double ProductPrice { get; private set; }

        public ProductRecord(Product product, int productCount, double productPrice)
        {
            Product = product;
            ProductCount = productCount;
            ProductPrice = productPrice;
        }
        
        // easier to use ctor (takes productName instead of Product object)
        // though this isn't optimal if we know our Product class will have more values soon
        public ProductRecord(string productName, int productCount, double productPrice)
            : this(new Product(productName), productCount, productPrice)
        {
        }

        public void Restock(int desiredAmount)
        {
            // magic! we got our desired amount just like that =D
            ProductCount = desiredAmount;
        }

        public override string ToString()
        {
            return string.Format("Product: {0}, Count: {1}, Price: {2}", 
                Product, ProductCount, ProductPrice);
        }
    }
}