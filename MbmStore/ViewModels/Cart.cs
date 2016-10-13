using MbmStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MbmStore.ViewModels
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public decimal TotalPrice
        {
            get
            {
                return lines.Sum(e => e.Product.Price * e.Quantity);
            }
        }

        public List<CartLine> Lines
        {
            get
            {
                return lines;
            }
        }

        public Cart()
        {

        }

        public void AddItem(Product product, int quantity)
        {
            CartLine item = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                lines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            lines.RemoveAll(i => i.Product.ProductId == product.ProductId);
        }

        public void Clear()
        {
            lines.Clear();
        }
    }
}