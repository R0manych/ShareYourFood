using DataContext.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Mappers
{
    public static class UserMapper
    {
        public static User MapUser(DataRow row)
        {
            return new User()
            {
                Id = Convert.ToInt32(row["ID"]),
                Name = row["NAME"].ToString(),
                Email = row["EMAIL"].ToString()
            };
        }
    }
}
