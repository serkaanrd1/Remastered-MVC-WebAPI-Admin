using AutoMapper;
using RMS.Model.Dtos.Service;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {

            CreateMap<Service, ServiceGetDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServicePutDto, Service>();

        }
    }
}
