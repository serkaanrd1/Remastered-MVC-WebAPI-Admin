using AutoMapper;
using RMS.Model.Dtos.Invoice;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {

            CreateMap<Invoice, InvoiceGetDto>();
            CreateMap<InvoicePostDto, Invoice>();
            CreateMap<InvoicePutDto, Invoice>();

        }
    }
}
