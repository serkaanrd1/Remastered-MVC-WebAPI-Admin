using AutoMapper;
using RMS.Model.Dtos.Technician;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {

            CreateMap<Technician, TechnicianGetDto>();
            CreateMap<TechnicianPostDto, Technician>();
            CreateMap<TechnicianPutDto, Technician>();

        }
    }
}
