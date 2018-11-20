using AutoMapper;
using AutoMapper.Configuration;
using DataContext.Models;
using ShareYourFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourFood.Utils
{
    public static class MapperInitializer
    {
        public static void Initialize()
        {         
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.CreateMap<Food, FoodModel>();
            baseMappings.CreateMap<UserToFood, EntryModel>()
                .ForMember("Name", opt => opt.MapFrom(c => c.User.Name))
                .ForMember("Email", opt => opt.MapFrom(src => src.User.Email))
                .ForMember("Date", opt => opt.MapFrom(c => c.Date))
                .ForMember("FoodName", opt => opt.MapFrom(src => src.Food.Name))
                ;

            var config = new MapperConfiguration(baseMappings);

            Mapper.Initialize(baseMappings);
        }
    }
}