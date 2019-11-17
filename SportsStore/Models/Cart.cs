using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        // properties 
        private List<CartLine> lineCollection = new List<CartLine>();

        // this method is adding item to cart
        public virtual void AddItem(Product product, int quantity)
        {
            // checking if the item is already in line collection
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        // this  is removing item from cart
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        
        // this method adding total price to the cart
        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);
        
        // this method will clear all item from the cart
        public virtual void Clear() => lineCollection.Clear();

        // this method will return line collection to the cart
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
