namespace MbmStore.Models
{
    public class Movie : Product
    {
        #region Private fields
        private string director;
        private string producer;
        #endregion

        #region Public properties

        public string Director
        {
            get { return director; }
        }

        public string Producer
        {
            get
            {
                return producer ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    producer = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Default constructor with initializing values for Title and Price.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public Movie(string title, decimal price) : base(title, price)
        {
        }

        /// <summary>
        /// Constructor with initializing values
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="imageUrl"></param>
        /// <param name="director"></param>
        public Movie(string title, decimal price, string imageUrl, string director) : base(title, price)
        {
            this.ImageUrl = imageUrl;
            this.director = director;
        }
    }
}