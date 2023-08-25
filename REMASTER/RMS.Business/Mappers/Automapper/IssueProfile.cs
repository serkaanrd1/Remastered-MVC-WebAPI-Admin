using AutoMapper;
using RMS.Model.Dtos.Invoice;
using RMS.Model.Dtos.Issue;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Mappers.Automapper
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {

            CreateMap<Issue, IssueGetDto>();
            CreateMap<IssuePostDto, Issue>();
            CreateMap<IssuePutDto, Issue>();

        }
    }
}
