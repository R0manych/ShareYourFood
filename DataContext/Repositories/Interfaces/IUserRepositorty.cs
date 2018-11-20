using DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories.Interfaces
{
    public interface IUserRepositorty
    {
        /// <summary>
        /// Возвращает true если есть пользователь с заданным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool FindById(int id);

        /// <summary>
        /// Возвращает true если есть пользователь с заданным именем и почтой
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool FindByNameAndEmail(string name, string email);

        /// <summary>
        /// Добавляет нового пользователя
        /// </summary>
        /// <param name="user"></param>
        void SaveUser(User user);

        /// <summary>
        /// Запоминает, что пользователь userId съел foodId во время date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="foodId"></param>
        /// <param name="date"></param>
        void AddFoodToUser(int userId, int foodId, DateTime date);

        /// <summary>
        /// Возвращает пользователя с заданным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);

        /// <summary>
        /// Возвращает пользователя с заданным именем и почтой
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetByNameAndEmail(string name, string email);

        /// <summary>
        /// Возвращает все записи о пользователях и их блюдах
        /// </summary>
        /// <returns></returns>
        List<UserToFood> GetAllEntries();
    }
}
