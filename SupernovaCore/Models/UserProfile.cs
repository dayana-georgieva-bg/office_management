using AutoMapper;
using SupernovaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupernovaCore
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Supernova_teamContext, EmployeesInformation>();
            CreateMap<Supernova_teamContext, CompanyResource>();
        }


    }
}
