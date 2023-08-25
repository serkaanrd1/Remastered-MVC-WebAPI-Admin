using AutoMapper;
using RMS.Model.Dtos.Payment;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {

            CreateMap<Payment, PaymentGetDto>();
            CreateMap<PaymentPostDto, Payment>();
            CreateMap<PaymentPutDto, Payment>();

        }
    }
}
