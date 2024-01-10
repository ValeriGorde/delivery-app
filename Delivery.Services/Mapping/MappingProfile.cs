using AutoMapper;
using Delivery.BLL.Models;
using Delivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.BLL.Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<OrderDTO, Order>().ReverseMap();

            
        }
    }
}
