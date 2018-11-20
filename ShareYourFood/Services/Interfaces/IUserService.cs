using ShareYourFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourFood.Services.Interfaces
{
    public interface IUserService
    {
        EntryWithCountModel ReportModel(EntryModel model);

        List<EntryModel> GetLastEntries(int count);
    }
}
