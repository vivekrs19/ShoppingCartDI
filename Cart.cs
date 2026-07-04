using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        
        private readonly List<Product> _products = new List<Product>();
        public IEnumerable<Product> GetProducts() => _products;
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        
    }
}
