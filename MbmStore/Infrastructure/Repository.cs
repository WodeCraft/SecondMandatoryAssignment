using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MbmStore.Infrastructure
{
    /// <summary>
    /// This class will handle access to the data needed for this website.
    /// At the moment all data is stored in memory and not persisted. Data will be created on each call to the constructor.
    /// 
    /// It could be argued that this class should be a singleton instead. Right now each list of data will be created for
    /// each instance of this class. But given the small amount of data present, this is improvement does not seem worth it.
    /// </summary>
    public class Repository
    {

        public List<Product> Products = new List<Product>();
        public List<Customer> Customers = new List<Customer>();
        public List<Invoice> Invoices = new List<Invoice>();


        private static Repository _instance;

        public static Repository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Constructor that will create all the data and store it in local lists. No data is persisted.
        /// </summary>
        private Repository()
        {
            Random rnd = new Random();

            #region Products
            // Books
            Book book = new Book(rnd.Next(1000, 50000), "Steve Turner", "A Hard Day's Write: The Stories Behind Every Beatles Song", 150m, 2005);
            book.Publisher = "It Books";
            book.ISBN = "0060844094";
            book.ImageUrl = "AHardDaysWrite.jpg";
            book.Category = "Book";
            Products.Add(book);

            book = new Book(rnd.Next(1000, 50000), "Stephen King", "The Shining: The Deluxe Special Edition", 199m, 2016);
            book.Publisher = "Cemetery Dance Publications";
            book.ISBN = "978-1-58767-530-0";
            book.ImageUrl = "TheShining.jpg";
            book.Category = "Book";
            Products.Add(book);

            // Music CDs
            MusicCD cd = new MusicCD(rnd.Next(1000, 50000), "Beatles", "Abbey Road (Remastered)", 128m, 2009);
            cd.Label = "EMI";
            cd.ImageUrl = "AbbeyRoadAlbumCover.jpg";
            cd.Category = "Music";
            cd.AddTrack(new Track { Title = "Come Together", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 4, 20) });
            cd.AddTrack(new Track { Title = "Something", Composer = "Harrison", Length = new TimeSpan(0, 3, 3) });
            cd.AddTrack(new Track { Title = "Maxwell's Silver Hammer", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 3, 27) });
            cd.AddTrack(new Track { Title = "Oh! Darling", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 3, 26) });
            cd.AddTrack(new Track { Title = "Octopus's Garden", Composer = "Starr", Length = new TimeSpan(0, 2, 51) });
            cd.AddTrack(new Track { Title = "I Want You (She's So Heavy)", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 7, 47) });
            cd.AddTrack(new Track { Title = "Here Comes The Sun", Composer = "Harrison", Length = new TimeSpan(0, 3, 5) });
            cd.AddTrack(new Track { Title = "Because", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 2, 45) });
            cd.AddTrack(new Track { Title = "You Never Give Me Your Money", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 4, 2) });
            cd.AddTrack(new Track { Title = "Sun King", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 2, 26) });
            cd.AddTrack(new Track { Title = "Mean Mr. Mustard", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 1, 6) });
            cd.AddTrack(new Track { Title = "Polythene Pam", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 1, 12) });
            cd.AddTrack(new Track { Title = "She Came In Through The Bathroom Window", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 1, 57) });
            cd.AddTrack(new Track { Title = "Golden Slumbers", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 1, 31) });
            cd.AddTrack(new Track { Title = "Carry The Weight", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 1, 36) });
            cd.AddTrack(new Track { Title = "The End", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 2, 5) });
            cd.AddTrack(new Track { Title = "Her Majesty", Composer = "Lennon/McCartney", Length = new TimeSpan(0, 0, 23) });
            Products.Add(cd);

            cd = new MusicCD(rnd.Next(1000, 50000), "Fields of the Nepthilim", "Earth Inferno", 99m, 1991);
            cd.Label = "Beggars Banquet";
            cd.ImageUrl = "Earth_Inferno_Fields_of_the_Nephilim.jpeg";
            cd.Category = "Music";
            cd.AddTrack(new Track { Title = "Intro (Dead But Dreaming)", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 16, 8) });
            cd.AddTrack(new Track { Title = "Moonchild", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 5, 25) });
            cd.AddTrack(new Track { Title = "Submission", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 7, 34) });
            cd.AddTrack(new Track { Title = "Preacher Man", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 4, 51) });
            cd.AddTrack(new Track { Title = "Love Under Will", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 6, 17) });
            cd.AddTrack(new Track { Title = "Sumerland", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 8, 26) });
            cd.AddTrack(new Track { Title = "Last Exit for the Lost", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 10, 18) });
            cd.AddTrack(new Track { Title = "Psychonaut", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 9, 5) });
            cd.AddTrack(new Track { Title = "Dawnrazor", Composer = "Fields of the Nephilim", Length = new TimeSpan(0, 9, 9) });
            Products.Add(cd);

            // Movies
            Movie movie = new Movie(rnd.Next(1000, 50000), "Jungle Book", 160.50m, "junglebook.jpg", "Jon Favreau");
            movie.Category = "Movie";
            Products.Add(movie);
            movie = new Movie(rnd.Next(1000, 50000), "Blade Runner", 198.95m, "bladerunner.jpg", "Ridley Scott");
            movie.Category = "Movie";
            Products.Add(movie);
            movie = new Movie(rnd.Next(1000, 50000), "Subway", 89.50m, "subway.jpg", "Luc Besson");
            movie.Category = "Movie";
            Products.Add(movie);
            #endregion

            #region Customers
            Customer PhilLynott = new Customer(1039, "Phil", "Lynott", "Rock'n Hard 42", "29387", "Place");
            PhilLynott.Birthdate = new DateTime(1949, 8, 20);
            PhilLynott.AddPhone("555-938276");
            Customers.Add(PhilLynott);
            Customer OlufSand = new Customer(1991, "Oluf", "Sand", "Ved Skoven 12", "8394", "Vester Vad");
            OlufSand.Birthdate = new DateTime(1956, 2, 29);
            Customers.Add(OlufSand);
            Customer MazJobrani = new Customer(2014, "Maz", "Jobrani", "31st street", "9384", "New York");
            MazJobrani.AddPhone("515-394851");
            MazJobrani.Birthdate = new DateTime(1972, 2, 26);
            Customers.Add(MazJobrani);
            #endregion

            #region Invoices & OrderItems
            Invoice invoice = new Invoice(12938, new DateTime(2016, 4, 28), PhilLynott);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(Book) && p.Title.Contains("The Shining")).Single(), 1);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(Movie) && p.Title.Contains("Subway")).Single(), 1);
            Invoices.Add(invoice);

            invoice = new Invoice(12939, new DateTime(2015, 12, 21), OlufSand);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(Book) && p.Title.Contains("The Shining")).Single(), 1);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(MusicCD) && p.Title.Contains("Earth Inferno")).Single(), 2);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(Movie) && p.Title.Contains("Blade Runner")).Single(), 1);
            invoice.AddOrderItem(Products.Where(p => p.GetType() == typeof(Book) && p.Title.Contains("The Shining")).Single(), 1);
            Invoices.Add(invoice);
            #endregion
        }
    }
}