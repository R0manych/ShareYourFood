using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        DataSet GetNewRows(string sqlQuery, params object[] parametres);

        void ExecuteCommand(string sqlQuery, params object[] parametres);
    }
}
