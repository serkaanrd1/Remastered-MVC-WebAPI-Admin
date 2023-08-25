using AutoMapper;
using RMS.Model.Dtos.Technician;
using RMS.Model.Dtos.Vehicle;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {

            CreateMap<Vehicle, VehicleGetDto>();
            CreateMap<VehiclePostDto, Vehicle>();
            CreateMap<VehiclePutDto, Vehicle>();

        }
    }
}
