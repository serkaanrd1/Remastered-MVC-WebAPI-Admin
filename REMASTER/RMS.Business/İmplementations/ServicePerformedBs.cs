using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.implementations.Repositories;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.ServicePerformed;
using RMS.Model.Dtos.Technician;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class ServicePerformedBs : IServicePerformedBs
    {
        private readonly IServicePerformedRepository _repo;
        private readonly IMapper _mapper;

        public ServicePerformedBs(IServicePerformedRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<ServicePerformedGetDto>> GetByIdAsync(int serviceLogId, params string[] includeList)
        {
            if (serviceLogId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var serviceperformed = await _repo.GetByIdAsync(serviceLogId, includeList);

            if (serviceperformed == null)
                throw new NotFoundException("bu id li servis kayıtı bulunamadı");

            var dto = _mapper.Map<ServicePerformedGetDto>(serviceperformed);

            return ApiResponse<ServicePerformedGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedAsync(params string[] includeList)
        {
            var servicesperformed = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (servicesperformed.Count > 0)
            {
                var returnList = _mapper.Map<List<ServicePerformedGetDto>>(servicesperformed);

                return ApiResponse<List<ServicePerformedGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByDateAsync(DateTime date, params string[] includeList)
        {
            

            var servicesperformed = await _repo.GetByDateAsync(date, includeList);

            if (servicesperformed.Count > 0)
            {
                var returnList = _mapper.Map<List<ServicePerformedGetDto>>(servicesperformed);

                return ApiResponse<List<ServicePerformedGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByServiceAsync(int serviceId, params string[] includeList)
        {
            if (serviceId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var servicesPerformed = await _repo.GetByServiceIdAsync(serviceId, includeList);

            if (servicesPerformed.Count > 0)
            {
                var returnList = _mapper.Map<List<ServicePerformedGetDto>>(servicesPerformed);

                return ApiResponse<List<ServicePerformedGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ServicePerformedGetDto>>> GetServicesPerformedByVehiclesAsync(int vehicleId, params string[] includeList)
        {
            if (vehicleId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var servicesPerformed = await _repo.GetByVehicleIdAsync(vehicleId, includeList);

            if (servicesPerformed.Count > 0)
            {
                var returnList = _mapper.Map<List<ServicePerformedGetDto>>(servicesPerformed);

                return ApiResponse<List<ServicePerformedGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<ServicePerformed>> InsertAsync(ServicePerformedPostDto dto)
        {
           


            var entity = _mapper.Map<ServicePerformed>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<ServicePerformed>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ServicePerformedPutDto dto)
        {
            if (dto.ServiceLogID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = _mapper.Map<ServicePerformed>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
