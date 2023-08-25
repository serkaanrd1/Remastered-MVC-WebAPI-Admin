using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using WS.WebAPI.Controllers;
using RMS.Model.Dtos.Technician;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : BaseController
    {
            private readonly ITechnicianBs _technicianBs;

            public TechniciansController(ITechnicianBs technicianBs)
            {
            _technicianBs = technicianBs;
            }





            [HttpGet]
            [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<TechnicianGetDto>>))]
            [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
            [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
            public async Task<ActionResult> GetAllTechnicians()
            {
                var response = await _technicianBs.GetTechniciansAsync();

                return SendResponse(response);

            }



            [HttpGet("{id}")]
            [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<TechnicianGetDto>>))]
            [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
            [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
            public async Task<ActionResult> GetById([FromRoute] int id)
            {
                var response = await _technicianBs.GetByIdAsync(id);

                return SendResponse(response);
            }

            [HttpPost]
            [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<TechnicianPostDto>>))]
            [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
            [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
            public async Task<ActionResult> SaveNewVehicle([FromBody] TechnicianPostDto dto)
            {
                var response = await _technicianBs.InsertAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = response.Data.TechnicianID }, response.Data);
            }

            [HttpPut]
            [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<TechnicianPutDto>>))]
            [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
            [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
            public async Task<ActionResult> UpdateProduct([FromBody] TechnicianPutDto dto)
            {
                var response = await _technicianBs.UpdateAsync(dto);

                return SendResponse(response);
            }
            [HttpDelete("{id}")]
            [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<TechnicianPutDto>>))]
            [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
            [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
            public async Task<ActionResult> DeleteProduct(int id)
            {
                var response = await _technicianBs.DeleteAsync(id);

                return SendResponse(response);
            }
        }
    }
