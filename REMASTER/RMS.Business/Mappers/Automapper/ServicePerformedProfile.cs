using AutoMapper;
using RMS.Model.Dtos.Payment;
using RMS.Model.Dtos.ServicePerformed;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class ServicePerformedProfile : Profile
    {
        public ServicePerformedProfile()
        {

            CreateMap<ServicePerformed, ServicePerformedGetDto>();
            CreateMap<ServicePerformedPostDto, ServicePerformed>();
            CreateMap<ServicePerformedPutDto, ServicePerformed>();

        }
    }
}
