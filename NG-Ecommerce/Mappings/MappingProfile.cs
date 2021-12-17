using AutoMapper;
using EcommerceCore.Models;
using EcommerceCore.Models.Users;
using NG_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, AppUser>();
            CreateMap<ProductDto, Product>();
        }
    }
}
