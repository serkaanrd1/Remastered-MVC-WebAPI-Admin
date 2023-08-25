using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Service;
using RMS.Model.Dtos.ServicePerformed;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class ServiceBs : IServiceBs
    {
        private readonly IServiceRepository _repo;
        private readonly IMapper _mapper;

        public ServiceBs(IServiceRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<ServiceGetDto>> GetByIdAsync(int serviceId, params string[] includeList)
        {
            if (serviceId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var service = await _repo.GetByIdAsync(serviceId, includeList);

            if (service == null)
                throw new NotFoundException("bu id li servis kayıtı bulunamadı");

            var dto = _mapper.Map<ServiceGetDto>(service);

            return ApiResponse<ServiceGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<ServiceGetDto>>> GetServicesAsync(params string[] includeList)
        {
            var services = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (services.Count > 0)
            {
                var returnList = _mapper.Map<List<ServiceGetDto>>(services);

                return ApiResponse<List<ServiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ServiceGetDto>>> GetServicesByDescAsync(string desc, params string[] includeList)
        {

            var services = await _repo.GetByDescAsync(desc, includeList);

            if (services.Count > 0)
            {
                var returnList = _mapper.Map<List<ServiceGetDto>>(services);

                return ApiResponse<List<ServiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ServiceGetDto>>> GetServicesByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("fiyatlar pozitif değer olmalıdır");


            var services = await _repo.GetByPriceAsync(min, max, includeList);

            if (services.Count > 0)
            {
                var returnList = _mapper.Map<List<ServiceGetDto>>(services);

                return ApiResponse<List<ServiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public Task<ApiResponse<List<ServiceGetDto>>> GetVehiclesByNameAsync(string name, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Service>> InsertAsync(ServicePostDto dto)
        {

            var entity = _mapper.Map<Service>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Service>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ServicePutDto dto)
        {
            if (dto.ServiceID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");


            var entity = _mapper.Map<Service>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
