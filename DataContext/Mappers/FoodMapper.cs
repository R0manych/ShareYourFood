using DataContext.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Mappers
{
    public static class FoodMapper
    {
        public static Food MapFood(DataRow row)
        {
            return new Food()
            {
                Id = Convert.ToInt32(row["ID"]),
                Name = row["NAME"].ToString(),
            };
        }
    }
}
