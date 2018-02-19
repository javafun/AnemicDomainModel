using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Logic.Entities
{
    public class Customer : Entity
    {
        private string _name;
        private string _email;

        public virtual CustomerName Name
        {
            get => (CustomerName)_name; 
            set => _name = value;
        }
        public virtual Email Email
        {
            get => (Email)_email;
            set => _email = value;
        }
        public virtual CustomerStatus Status { get; set; }
        public virtual DateTime? StatusExpirationDate { get; set; }
        public virtual decimal MoneySpent { get; set; }
        public virtual IList<PurchasedMovie> PurchasedMovies { get; set; }
    }
}
