using AutoMapper;
using RMS.Model.Dtos.Customer;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile() 
        {


            CreateMap<Customer, CustomerGetDto>();
            CreateMap<CustomerPostDto, Customer>();
            CreateMap<CustomerPutDto, Customer>();






        }









    }
}
