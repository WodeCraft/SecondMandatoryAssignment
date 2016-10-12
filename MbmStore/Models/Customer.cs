using System;
using System.Collections.Generic;

namespace MbmStore.Models
{
    public class Customer
    {
        #region Private variables
        private int customerId;
        private List<string> phonenumbers = new List<string>();
        private DateTime birthdate;
        private string firstname;
        private string lastname;
        private string address;
        private string zip;
        private string city;
        #endregion

        #region Public properties
        public int CustomerId
        {
            get
            {
                return customerId;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    firstname = value;
                }
            }
        }
        public string Lastname
        {
            get
            {
                return lastname ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    lastname = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        public string Address
        {
            get
            {
                return address ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    address = value;
                }
            }
        }
        public string Zip
        {
            get
            {
                return zip ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    zip = value;
                }
            }
        }
        public string City
        {
            get
            {
                return city ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    city = value;
                }
            }
        }

        public List<string> Phonenumbers
        {
            get
            {
                return phonenumbers;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                int age = CalculateAge(value);
                if (age < 0 || age > 120)
                {
                    throw new Exception("Age not accepted");
                }
                else
                {
                    birthdate = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return CalculateAge(birthdate);
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Customer(int customerId, string firstname, string lastname, string address, string zip, string city)
        {
            this.customerId = customerId;
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Zip = zip;
            City = city;
        }

        /// <summary>
        /// Mehtod for adding a new phone number to the list of phone numbes.
        /// </summary>
        /// <param name="phone"></param>
        public void AddPhone(string phone)
        {
            if (phonenumbers == null)
            {
                phonenumbers = new List<string>();
            }
            if (string.IsNullOrEmpty(phone) == false)
            {
                phonenumbers.Add(phone);
            }
        }

        /// <summary>
        /// Method for calculating the age of a customer based on the difference between the specified <paramref name="checkedDate"/> and DateTime.Now.
        /// </summary>
        /// <param name="checkedDate"></param>
        /// <returns></returns>
        private int CalculateAge(DateTime checkedDate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - checkedDate.Year;

            if (now.Month < checkedDate.Month
                || (now.Month == checkedDate.Month && now.Day < checkedDate.Day))
            {
                age--;
            }

            return age;
        }

    }
}