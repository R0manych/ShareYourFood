using DataContext.Repositories;
using DataContext.Repositories.Interfaces;
using Ninject.Modules;
using ShareYourFood.Services;
using ShareYourFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepositorty>().To<UserRepository>();
            Bind<IFoodRepository>().To<FoodRepository>();
            Bind<IFoodService>().To<FoodService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}