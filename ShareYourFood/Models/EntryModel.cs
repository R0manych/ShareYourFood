using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Models
{
    public class EntryModel : BaseEntryModel
    {
        public List<FoodModel> AvailableFood { get; set; }

        public EntryModel()
        {            
            AvailableFood = new List<FoodModel>();
        }
    }
}