using System;

namespace MbmStore.Models
{
    /// <summary>
    /// Class representing a single track on a MusicCD
    /// </summary>
    public class Track
    {
        #region Private variables
        private string title;
        private TimeSpan length;
        private string composer;
        #endregion

        #region Public properties
        /// <summary>
        /// The title of the track
        /// </summary>
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

        /// <summary>
        /// The playing lenght of the track
        /// </summary>
        public TimeSpan Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        /// <summary>
        /// The composer of the track
        /// </summary>
        public string Composer
        {
            get
            {
                return composer ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    composer = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Track()
        {

        }

        /// <summary>
        /// Constructor with an initializing value for Title
        /// </summary>
        /// <param name="title"></param>
        public Track(string title, TimeSpan length)
        {
            this.Title = title;
            this.Length = length;
        }

    }
}