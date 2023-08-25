using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using RMS.Model.Dtos.Technician;
using WS.WebAPI.Controllers;
using RMS.Model.Dtos.ServicePerformed;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesPerformedController : BaseController
    {
        private readonly IServicePerformedBs _servicePerformedBs;

        public ServicesPerformedController(IServicePerformedBs servicePerformedBs)
        {
            _servicePerformedBs = servicePerformedBs;
        }





        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePerformedGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetAllServicePerformed()
        {
            var response = await _servicePerformedBs.GetServicesPerformedAsync();

            return SendResponse(response);

        }



        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePerformedGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _servicePerformedBs.GetByIdAsync(id);

            return SendResponse(response);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePerformedPostDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> SaveNewVehicle([FromBody] ServicePerformedPostDto dto)
        {
            var response = await _servicePerformedBs.InsertAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.ServiceLogID }, response.Data);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePerformedPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateProduct([FromBody] ServicePerformedPutDto dto)
        {
            var response = await _servicePerformedBs.UpdateAsync(dto);

            return SendResponse(response);
        }
        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePerformedPutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _servicePerformedBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
