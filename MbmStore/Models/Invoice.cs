using System;
using System.Collections.Generic;
using System.Linq;

namespace MbmStore.Models
{
    public class Invoice
    {
        #region Private variables
        private int invoiceId;
        private DateTime orderDate;
        private Customer customer;
        private List<OrderItem> orderItems;
        #endregion

        #region Public properties
        public int InvoiceId
        {
            get
            {
                return invoiceId;
            }
            set
            {
                invoiceId = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
            }
        }

        /// <summary>
        /// Returning the total price for the invoice by adding 
        /// the total prices of all the order items.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return orderItems.Sum(item => item.TotalPrice);
            }
        }

        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                if (value != null)
                {
                    customer = value;
                }
            }
        }

        public List<OrderItem> OrderItems
        {
            get
            {
                return orderItems;
            }
        }
        #endregion

        /// <summary>
        /// Default constructor with initializing values
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="orderDate"></param>
        /// <param name="customer"></param>
        public Invoice(int invoiceId, DateTime orderDate, Customer customer)
        {
            this.InvoiceId = invoiceId;
            this.OrderDate = orderDate;
            this.Customer = customer;
            orderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Method for adding an OrderItem to an Invoice.
        /// As part of this the TotalPrice will also be updated by adding the 
        /// total price of the OrderItem to the total price of the Invoice.
        /// 
        /// If the specified product is already added to the invoice, the 
        /// quantity is increased by the quantity specified in the parameter.
        /// </summary>
        /// <param name="product">The product to be part of the OrderItem.</param>
        /// <param name="quantity">The quantity to be added.</param>
        public void AddOrderItem(Product product, int quantity)
        {
            OrderItem oi = orderItems.SingleOrDefault(item => item.Product.Title == product.Title);
            if (oi == null)
            {
                oi = new OrderItem(product, quantity);
                orderItems.Add(oi);
            }
            else
            {
                oi.Quantity += quantity;
            }
        }

    }
}