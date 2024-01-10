using AutoMapper;
using Delivery.BLL.Models;
using Delivery.DAL.Models;
using Delivery.Web.Models;

namespace Delivery.Web.Mapping
{
    /// <summary>
    /// Настройка составления типов
    /// </summary>
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();            
        }
    }
}
