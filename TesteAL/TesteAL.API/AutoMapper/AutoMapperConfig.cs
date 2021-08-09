using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAL.Domain.Entities;
using TesteAL.Domain.Interfaces.Services;
using TesteAL.Service.ViewModel;

namespace TesteAL.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
        }
    }
}
