using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Issue;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Order;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class IssueController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public IssueController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<IssueItem>>>("/issues");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewIssueDto dto)
        {
            try
            {
                var postData = new
                {
                    CustomerId = dto.CustomerID,
                    Description = dto.Description,
                    VehicleId = dto.VehicleID
                };

                var response = await _apiService.PostData<ResponseBody<IssueItem>>("/issues", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Şikayet Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Bir hata oluştu ancak hata mesajı alınamadı." });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Şikayet Kaydedilemedi <br /> {errorMessages}"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Bir hata oluştu: {ex.Message}"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/issues/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Issue Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Issue Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetIssue(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<IssueItem>>($"/issues/{id}");

            return Json(new
            {
                CustomerId = response.Data.CustomerID,
                Description = response.Data.Description,
                IssueId = response.Data.IssueID
            });

        }
    }
}
