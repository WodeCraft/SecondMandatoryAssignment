using System;
using System.Collections.Generic;
using System.Linq;

namespace MbmStore.Models
{
    public class MusicCD : Product
    {
        #region Private variables
        private string artist;
        private string label;
        private short released;
        private List<Track> tracks;
        #endregion

        #region Public properties
        public string Artist
        {
            get
            {
                return artist ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    artist = value;
                }
            }
        }

        public string Label
        {
            get
            {
                return label ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    label = value;
                }
            }
        }

        public short Released
        {
            get
            {
                return released;
            }
            set
            {
                if (value > 0)
                {
                    released = value;
                }
            }
        }

        public List<Track> Tracks
        {
            get
            {
                return tracks;
            }
        }
        #endregion

        /// <summary>
        /// Default construtor
        /// </summary>
        public MusicCD()
        {
            this.tracks = new List<Track>();
        }

        /// <summary>
        /// Constructor with initializing values
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="released"></param>
        public MusicCD(int productId, string artist, string title, decimal price, short released)
            : base(productId, title, price)
        {

            this.Artist = artist;
            this.Released = released;
            this.tracks = new List<Track>();
        }

        /// <summary>
        /// This method will add a track to the tracklist of a MusicCD
        /// </summary>
        /// <param name="track"></param>
        public void AddTrack(Track track)
        {
            if (track != null)
            {
                tracks.Add(track);
            }
        }

        /// <summary>
        /// This method will return the complete playing time of a MusicCD.
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetPlayingTime()
        {
            // Using the Aggregate Linq method to adding the playing time of all tracks together
            return tracks.Aggregate(TimeSpan.Zero, (sum, next) => sum.Add(next.Length));
        }

    }
}