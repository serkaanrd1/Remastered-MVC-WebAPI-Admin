using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Service;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Technician;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class ServiceController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public ServiceController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<ServiceItem>>>("/services");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewServiceDto dto)
        {
            try
            {
                var postData = new
                {
                    ServiceName = dto.ServiceName,
                    Price = dto.Price
                };

                var response = await _apiService.PostData<ResponseBody<ServiceItem>>("/services", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Servis Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Servis Başarıyla Kaydedildi" });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Servis Kaydedilemedi <br /> {errorMessages}"
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
              await _apiService.DeleteData($"/services/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Servis Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Servis Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetService(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<ServiceItem>>($"/services/{id}");

            return Json(new
            {
                ServiceName = response.Data.ServiceName,
                Price = response.Data.Price,
                ServiceId = response.Data.ServiceID
            });

        }
    }
}
