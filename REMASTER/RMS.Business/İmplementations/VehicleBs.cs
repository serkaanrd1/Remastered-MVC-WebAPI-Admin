using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Vehicle;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.CustomExceptions;

namespace RMS.Business.İmplementations
{
    public class VehicleBs : IVehicleBs
    {
        private readonly IVehicleRepository _repo;
        private readonly IMapper _mapper;

        public VehicleBs(IVehicleRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<VehicleGetDto>> GetByIdAsync(int vehicleId, params string[] includeList)
        {
            if (vehicleId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var vehicle = await _repo.GetByIdAsync(vehicleId, includeList);

            if (vehicle == null)
                throw new NotFoundException("bu id li araç bulunamadı");

            var dto = _mapper.Map<VehicleGetDto>(vehicle);

            return ApiResponse<VehicleGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesAsync(params string[] includeList)
        {
            var vehicles = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (vehicles.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(vehicles);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByCustomerAsync(int cutomerId, params string[] includeList)
        {
            if (cutomerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var cutomers = await _repo.GetByCustomerAsync(cutomerId, includeList);

            if (cutomers.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(cutomers);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

      

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByYearAsync(int min, int max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("stok değerleri pozitif değer olmalıdır");


            var vehicles = await _repo.GetByYearAsync(min, includeList);
            if (vehicles.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(vehicles);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Vehicle>> InsertAsync(VehiclePostDto dto)
        {
            if (dto.Model.Length < 2)
                throw new BadRequestException("model adı en az 2 karakterden oluşmalıdır");



            var entity = _mapper.Map<Vehicle>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Vehicle>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(VehiclePutDto dto)
        {
          

            if (dto.Make.Length < 2)
                throw new BadRequestException("araç markası en az 2 karakterden oluşmalıdır");

          


            var entity = _mapper.Map<Vehicle>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
