using AutoMapper;
using RMS.Model.Dtos.AdminPanelUser;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class AdminPanelUserProfile : Profile
    {
        public AdminPanelUserProfile() 
        {


            CreateMap<AdminPanelUser, AdminPanelUserDto>();


        }
    }
}
