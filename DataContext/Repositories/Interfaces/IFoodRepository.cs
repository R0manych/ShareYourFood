using DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        /// <summary>
        /// Добавляет новое блюдо
        /// </summary>
        /// <param name="food"></param>
        void SaveFood(Food food);

        /// <summary>
        /// Возвращает список всех добавленных блюд
        /// </summary>
        /// <returns></returns>
        List<Food> GetAllFood();

        /// <summary>
        /// Возвращает количество съеденных блюд foodId за время между startDt и endDt
        /// </summary>
        /// <param name="foodId"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        int GetCountByDate(int foodId, DateTime startDt, DateTime endDt);

        /// <summary>
        /// Возвращает количество съеденных блюд foodId за пользователем userId
        /// </summary>
        /// <param name="foodId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int GetCountByUser(int foodId, int userId);
    }
}
