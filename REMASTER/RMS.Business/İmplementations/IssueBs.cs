using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Issue;
using RMS.Model.Dtos.Order;
using RMS.Model.Dtos.Service;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class IssueBs : IIssueBs
    {
        private readonly IIssueRepository _repo;
        private readonly IMapper _mapper;
        public IssueBs(IIssueRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("id pozitif bir değer olmalıdır");
            }
            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<IssueGetDto>> GetByIdAsync(int issueId, params string[] includeList)
        {
            if (issueId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var issue = await _repo.GetByIdAsync(issueId, includeList);

            if (issue == null)
                throw new NotFoundException("bu id li sorun kaydı bulunamadı");

            var dto = _mapper.Map<IssueGetDto>(issue);

            return ApiResponse<IssueGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<IssueGetDto>>> GetIssuesByCustomersAsync(int customerId, params string[] includeList)
        {

            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var issues = await _repo.GetByCustomerIdAsync(customerId, includeList);

            if (issues.Count > 0)
            {
                var returnList = _mapper.Map<List<IssueGetDto>>(issues);

                return ApiResponse<List<IssueGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<IssueGetDto>>> GetIssuesByDescAsync(string desc, params string[] includeList)
        {

            var issues = await _repo.GetByDescAsync(desc, includeList);

            if (issues.Count > 0)
            {
                var returnList = _mapper.Map<List<IssueGetDto>>(issues);

                return ApiResponse<List<IssueGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<IssueGetDto>>> GetIssuesByVehicleAsync(int vehicleId, params string[] includeList)
        {
            if (vehicleId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var issues = await _repo.GetByCustomerIdAsync(vehicleId, includeList);

            if (issues.Count > 0)
            {
                var returnList = _mapper.Map<List<IssueGetDto>>(issues);

                return ApiResponse<List<IssueGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<IssueGetDto>>> GetIssuesPerformedAsync(params string[] includeList)
        {
            var issues = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (issues.Count > 0)
            {
                var returnList = _mapper.Map<List<IssueGetDto>>(issues);

                return ApiResponse<List<IssueGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Issue>> InsertAsync(IssuePostDto dto)
        {

            if (dto.Description.Length < 10)
                throw new BadRequestException(" Açıklama en az 10 karakterden oluşmalıdır");



            var entity = _mapper.Map<Issue>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Issue>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(IssuePutDto dto)
        {
            if (dto.IssueID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = _mapper.Map<Issue>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
