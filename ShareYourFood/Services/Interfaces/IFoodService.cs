using ShareYourFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourFood.Services.Interfaces
{
    public interface IFoodService
    {
        void SaveFood(FoodModel food);

        List<FoodModel> GetAllFood();
    }
}
