using DataContext.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Mappers
{
    public static class UserToFoodMapper
    {
        public static UserToFood Map(DataRow row)
        {
            return new UserToFood()
            {
                User = new User()
                {
                    Name = row["uName"].ToString(),
                    Email = row["EMAIL"].ToString()
                },
                Food = new Food()
                {
                    Name = row["fName"].ToString()
                },
                Date = Convert.ToDateTime(row["DT"])
            };
        }
    }
}
