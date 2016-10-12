using System;

namespace MbmStore.Models
{
    public class OrderItem
    {
        #region Private variables
        private int orderItemId;
        private int productId;
        private Product product;
        private int quantity;
        #endregion

        #region Public properties
        public int OrderItemId
        {
            get
            {
                return orderItemId;
            }
            set
            {
                orderItemId = value;
            }
        }

        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                if (value != null)
                {
                    product = value;
                }
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        /// <summary>
        /// Will return the total price of this OrderItem by multiplying 
        /// the products price with the quantity
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return decimal.Multiply(Product.Price, Quantity);
            }
        }
        #endregion

        /// <summary>
        /// Default contructor with initializing values for creating a new order item.
        /// As part of the creation the OrderItemId will be set to a random number between 1000 and 9999.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(Product product, int quantity)
        {
            Random rnd = new Random();
            this.orderItemId = rnd.Next(1000, 10000);
            this.Product = product;
            this.productId = product.ProductId;
            this.Quantity = quantity;
        }

    }
}