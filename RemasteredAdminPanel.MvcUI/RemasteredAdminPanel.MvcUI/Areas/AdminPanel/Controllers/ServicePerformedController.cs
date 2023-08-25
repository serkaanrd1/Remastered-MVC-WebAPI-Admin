using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.ServicePerformed;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class ServicePerformedController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public ServicePerformedController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<ServicePerformedItem>>>("/servicesperformed");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewServicePerformedDto dto)
        {
            try
            {
                var postData = new
                {
                    ServiceId = dto.ServiceID,
                    VehicleId = dto.VehicleID
                };

                var response = await _apiService.PostData<ResponseBody<CustomerItem>>("/servicesperformed", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Servis Kayıt Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Servis Kayıt Başarıyla Kaydedildi" });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Servis Kayıt Kaydedilemedi <br /> {errorMessages}"
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
              await _apiService.DeleteData($"/servicesperformed/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Servis Kayıt Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Servis Kayıt Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetServicePerformed(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<ServicePerformedItem>>($"/servicesperformed/{id}");

            return Json(new
            {
                ServiceId = response.Data.ServiceID,
                VehicleId = response.Data.VehicleID,
                ServiceLogId = response.Data.ServiceLogID
            });

        }
    }
}
