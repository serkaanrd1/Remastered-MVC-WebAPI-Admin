using AutoMapper;
using RMS.Model.Dtos.Order;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<Order, OrderGetDto>();
            CreateMap<OrderPostDto, Order>();
            CreateMap<OrderPutDto, Order>();

        }
    }
}
