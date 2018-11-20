using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Models
{
    public class EntryWithCountModel : BaseEntryModel
    {
        public int CountPerDay { get; set; }

        public int CountPerUser { get; set; }

        public bool IsNew { get; set; }

        public EntryWithCountModel(EntryModel model)
        {
            Name = model.Name;
            Date = model.Date;
            Email = model.Email;
            FoodId = model.FoodId;
            FoodName = model.AvailableFood.FirstOrDefault(p => p.Id == model.FoodId).Name;
        }
    }
}