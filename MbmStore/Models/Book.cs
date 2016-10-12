namespace MbmStore.Models
{
    /// <summary>
    /// Containing information about a single book in the system
    /// </summary>
    public class Book : Product
    {
        #region Private variables
        private string author;
        private short published;
        private string publisher;
        private string isbn;
        #endregion

        #region Public properties
        /// <summary>
        /// The name of the author of the book.
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    author = value;
                }
            }
        }

        /// <summary>
        /// The year the book was published.
        /// </summary>
        public short Published
        {
            get
            {
                return published;
            }
            set
            {
                if (value > 0)
                {
                    published = value;
                }
            }
        }

        /// <summary>
        /// The publisher of the book
        /// </summary>
        public string Publisher
        {
            get
            {
                return publisher ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    publisher = value;
                }
            }
        }


        /// <summary>
        /// The ISBN number of the book.
        /// </summary>
        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    isbn = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Constructor with initializing values.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="published"></param>
        public Book(string author, string title, decimal price, short published)
            : base(title, price)
        {
            this.Author = author;
            this.Published = published;
        }

    }
}