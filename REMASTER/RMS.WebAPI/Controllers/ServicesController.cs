using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Business.İnterfaces;
using WS.WebAPI.Controllers;
using RMS.Model.Dtos.Service;

namespace RMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        private readonly IServiceBs _serviceBs;

        public ServicesController(IServiceBs serviceBs)
        {
            _serviceBs = serviceBs;
        }





        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServiceGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetAllTechnicians()
        {
            var response = await _serviceBs.GetServicesAsync();

            return SendResponse(response);

        }



        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServiceGetDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _serviceBs.GetByIdAsync(id);

            return SendResponse(response);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePostDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> SaveNewVehicle([FromBody] ServicePostDto dto)
        {
            var response = await _serviceBs.InsertAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.ServiceID }, response.Data);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateProduct([FromBody] ServicePutDto dto)
        {
            var response = await _serviceBs.UpdateAsync(dto);

            return SendResponse(response);
        }
        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ServicePutDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _serviceBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
