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
    public class FoodRepository : BaseRepository, IFoodRepository
    {
        private const string INSERT_FOOD = "INSERT INTO FOOD(ID, NAME) VALUES (SEQ_FOOD.NEXTVAL, :name)";
        private const string GET_FOOD_COUNT_BY_DATE = "SELECT COUNT(*) count FROM USER_TO_FOOD WHERE FOOD_ID = :foodId AND TRUNC(DT) BETWEEN :startDt AND :endDt";
        private const string GET_ALL_FOOD = "SELECT f.ID, f.NAME FROM FOOD f";
        private const string GET_FOOD_COUNT_BY_USER = "SELECT COUNT(*) count FROM USER_TO_FOOD WHERE FOOD_ID = :foodId AND USER_ID = :userId";

        public List<Food> GetAllFood()
        {
            var resultTable = GetNewRows(GET_ALL_FOOD);
            var allFood = new List<Food>();
            foreach (var row in resultTable.Tables[0].Rows)
            {
                allFood.Add(FoodMapper.MapFood((DataRow)row));
            }
            return allFood;
        }

        public int GetCountByDate(int foodId, DateTime startDt, DateTime endDt)
        {
            var resultTable = GetNewRows(GET_FOOD_COUNT_BY_DATE, new OracleParameter(":foodId", foodId), new OracleParameter(":startDt", startDt), new OracleParameter(":endDt", endDt));
            return Convert.ToInt32(resultTable.Tables[0].Rows[0]["count"]);
        }

        public int GetCountByUser(int foodId, int userId)
        {
            var resultTable = GetNewRows(GET_FOOD_COUNT_BY_USER, new OracleParameter(":foodId", foodId), new OracleParameter(":userId", userId));
            return Convert.ToInt32(resultTable.Tables[0].Rows[0]["count"]);
        }

        public void SaveFood(Food food) => ExecuteCommand(INSERT_FOOD, new OracleParameter(":name", food.Name));        
    }
}
