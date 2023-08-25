using AutoMapper;
using infrastructure.Utilities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Dtos.Technician;
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
    public class TechnicianBs : ITechnicianBs
    {
        private readonly ITechnicianRepository _repo;
        private readonly IMapper _mapper;

        public TechnicianBs(ITechnicianRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<TechnicianGetDto>> GetByIdAsync(int technicianId, params string[] includeList)
        {
            if (technicianId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var technician = await _repo.GetByIdAsync(technicianId, includeList);

            if (technician == null)
                throw new NotFoundException("bu id li teknisyen bulunamadı");

            var dto = _mapper.Map<TechnicianGetDto>(technician);

            return ApiResponse<TechnicianGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<TechnicianGetDto>>> GetTechniciansAsync(params string[] includeList)
        {
            var technicians = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (technicians.Count > 0)
            {
                var returnList = _mapper.Map<List<TechnicianGetDto>>(technicians);

                return ApiResponse<List<TechnicianGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Technician>> InsertAsync(TechnicianPostDto dto)
        {
            if (dto.FirstName.Length < 2)
                throw new BadRequestException("teknisyen adı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<Technician>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Technician>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(TechnicianPutDto dto)
        {
            if (dto.TechnicianID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");

            if (dto.FirstName.Length < 2)
                throw new BadRequestException("araç markası en az 2 karakterden oluşmalıdır");



            var entity = _mapper.Map<Technician>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
