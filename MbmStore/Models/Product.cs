using System.Text;

namespace MbmStore.Models
{
    public class Product
    {
        #region Private variables
        private int productId;
        private string title;
        private decimal price;
        private string imageUrl;
        private string category;
        #endregion

        #region Public properties
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
        public string Title
        {
            get
            {
                return title ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    title = value;
                }
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public string ImageUrl
        {
            get
            {
                return imageUrl ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    imageUrl = value;
                }
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    category = value;
                }
            }
        }

        #endregion

        /// <summary>
        /// Default construtor
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Constructor with initializing values for creating a new product.
        /// As part of the creation the ProductId will be set to a random number between 1000 and 49999.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public Product(int productId, string title, decimal price)
        {
            this.productId = productId;
            this.Title = title;
            this.Price = price;
        }

        /// <summary>
        /// This method will return the information about a product as a string.
        /// </summary>
        /// <returns></returns>
        public virtual string Details()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("ID: {0}", productId));
            sb.AppendLine(string.Format("Title: {0}", title));
            sb.AppendLine(string.Format("Price: {0:0.00}", price));
            sb.AppendLine(string.Format("ImageUrl: {0}", imageUrl));
            return sb.ToString();
        }
    }
}