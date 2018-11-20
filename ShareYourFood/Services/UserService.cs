using AutoMapper;
using DataContext.Models;
using DataContext.Repositories.Interfaces;
using ShareYourFood.Models;
using ShareYourFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepositorty _userRepository;
        readonly IFoodRepository _foodRepository;

        public UserService(IUserRepositorty userRepository, IFoodRepository foodRepository)
        {
            _userRepository = userRepository;
            _foodRepository = foodRepository;
        }

        public List<EntryModel> GetLastEntries(int count) =>
            Mapper.Map<List<UserToFood>, List<EntryModel>>(_userRepository.GetAllEntries().Take(count).ToList());

        public EntryWithCountModel ReportModel(EntryModel model)
        {
            model.Date = DateTime.Now;
            var resultReportModel = new EntryWithCountModel(model)
            {
                IsNew = !_userRepository.FindByNameAndEmail(model.Name, model.Email)
            };

            if (resultReportModel.IsNew)
            {
                _userRepository.SaveUser(new User(model.Name, model.Email));
            }

            var userId = _userRepository.GetByNameAndEmail(model.Name, model.Email).Id;

            _userRepository.AddFoodToUser(userId, model.FoodId, model.Date);

            resultReportModel.CountPerDay = _foodRepository.GetCountByDate(model.FoodId, DateTime.Today, DateTime.Today.AddDays(1));
            resultReportModel.CountPerUser = _foodRepository.GetCountByUser(model.FoodId, userId);           

            return resultReportModel;
        }
    }
}