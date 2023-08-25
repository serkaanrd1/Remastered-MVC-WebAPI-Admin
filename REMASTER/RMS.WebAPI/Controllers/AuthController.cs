using Infrastructure.Utilities.ApiResponses;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.WebAPI.Controllers;
using RMS.Business.İnterfaces;
using RMS.Model.Dtos.AdminPanelUser;

namespace RMS.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAdminPanelUserBs _adminPanelUserBs;


        public AuthController(IAdminPanelUserBs adminPanelUserBs)
        {
            _adminPanelUserBs = adminPanelUserBs;
        }

        [HttpGet("login")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AdminPanelUserDto>>))]
        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> LogInAsync([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _adminPanelUserBs.LogInAsync(userName, password);

            return SendResponse(response);

        }







    }

}

