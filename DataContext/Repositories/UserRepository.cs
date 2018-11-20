using DataContext.Mappers;
using DataContext.Models;
using DataContext.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
    public class UserRepository : BaseRepository, IUserRepositorty
    {
        private const string FIND_USER_BY_ID = "SELECT u.ID, u.NAME, u.EMAIL FROM F_USER u WHERE u.ID = :id";
        private const string FIND_USER_BY_NAME_AND_EMAIL = "SELECT u.ID, u.NAME, u.EMAIL FROM F_USER u WHERE u.NAME = :name AND u.EMAIL = :email";
        private const string INSERT_USER = "INSERT INTO F_USER(ID, NAME, EMAIL) VALUES(SEQ_USER.NEXTVAL, :name, :email)";
        private const string INSERT_FOOD_TO_USER = "INSERT INTO USER_TO_FOOD(USER_ID, FOOD_ID, DT) VALUES(:userId, :foodId, :dt)";
        private const string SELECT_ALL_ENTRIES = @"SELECT utf.DT, u.Name uName, u.Email, f.NAME fName
            FROM USER_TO_FOOD utf INNER JOIN F_USER u ON utf.USER_ID = u.ID INNER JOIN FOOD f ON utf.FOOD_ID = f.ID 
            ORDER BY DT DESC";

        public bool FindById(int id) => FindAny(FIND_USER_BY_ID, new OracleParameter(":id", id));

        public User GetById(int id) => GetUser(FIND_USER_BY_ID, new OracleParameter(":id", id));

        public bool FindByNameAndEmail(string name, string email) =>
            FindAny(FIND_USER_BY_NAME_AND_EMAIL, new OracleParameter(":name", name), new OracleParameter(":email", email));

        public User GetByNameAndEmail(string name, string email) =>
            GetUser(FIND_USER_BY_NAME_AND_EMAIL, new OracleParameter(":name", name), new OracleParameter(":email", email));

        public void SaveUser(User user) =>
            ExecuteCommand(INSERT_USER, new OracleParameter(":name", user.Name), new OracleParameter(":email", user.Email));

        public void AddFoodToUser(int userId, int foodId, DateTime date) =>
        ExecuteCommand(INSERT_FOOD_TO_USER,
            new OracleParameter(":userId", userId),
            new OracleParameter(":foodId", foodId),
            new OracleParameter(":dt", OracleDbType.TimeStamp, date, ParameterDirection.Input)
        );

        private User GetUser(string query, params object[] parametres) => UserMapper.MapUser(GetNewRows(query, parametres).Tables[0].Rows[0]);

        public List<UserToFood> GetAllEntries()
        {
            var resultTable = GetNewRows(SELECT_ALL_ENTRIES);
            var resultList = new List<UserToFood>();
            foreach (DataRow row in resultTable.Tables[0].Rows)
            {
                resultList.Add(UserToFoodMapper.Map(row));
            }
            return resultList;
        }
    }
}
