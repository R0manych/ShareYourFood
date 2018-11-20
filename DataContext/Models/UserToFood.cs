using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Models
{
    public class UserToFood
    {
        public User User { get; set; }

        public Food Food { get; set; }

        public DateTime Date { get; set; }
    }
}
