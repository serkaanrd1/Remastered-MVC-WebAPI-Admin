using AutoMapper;
using RMS.Model.Dtos.Customer;
using RMS.Model.Dtos.Dealer;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class DealerProfile : Profile
    {

        public DealerProfile() 
        {

            CreateMap<Dealer, DealerGetDto>();
            CreateMap<DealerPostDto, Dealer>();
            CreateMap<DealerPutDto, Dealer>();






        }



    }
}
