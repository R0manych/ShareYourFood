using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Models
{
    public class BaseEntryModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int FoodId { get; set; }

        public DateTime Date { get; set; }

        public string FoodName { get; set; }
    }
}