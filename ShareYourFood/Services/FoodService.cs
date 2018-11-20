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
    public class FoodService : IFoodService
    {
        readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public List<FoodModel> GetAllFood() =>
            Mapper.Map<List<Food>, List<FoodModel>>(_foodRepository.GetAllFood());

        public void SaveFood(FoodModel food) =>
            _foodRepository.SaveFood(new Food() { Id = food.Id, Name = food.Name });
    }
}