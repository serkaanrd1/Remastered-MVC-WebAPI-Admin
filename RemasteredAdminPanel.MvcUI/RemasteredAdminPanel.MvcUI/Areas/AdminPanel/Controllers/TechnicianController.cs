using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Technician;
using RemasteredPanel.MvcUI.ApiServices;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using System.Text.Json;

namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class TechnicianController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public TechnicianController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<TechnicianItem>>>("/technicians");

            return View(response.Data);

        }



        [HttpPost]
        public async Task<IActionResult> Save(NewTechniciansDto dto)
        {
            try
            {
                var postData = new
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };

                var response = await _apiService.PostData<ResponseBody<TechnicianItem>>("/technicians", JsonSerializer.Serialize(postData));

                if (response.StatusCode == 201)
                    return Json(new { IsSuccess = true, Message = "Çalışan Başarıyla Kaydedildi" });

                if (response.ErrorMessages == null)
                    return Json(new { IsSuccess = false, Message = "Çalışan Başarıyla Kaydedildi" });

                var errorMessages = string.Join("<br />", response.ErrorMessages);

                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Çalışan Kaydedilemedi <br /> {errorMessages}"
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
              await _apiService.DeleteData($"/technicians/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Çalışan Silindi" });

            return Json(new { IsSuccess = false, Message = "Çalışan Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetTechnician(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<TechnicianItem>>($"/technicians/{id}");

            return Json(new
            {
                FirstName = response.Data.FirstName,
                LastName = response.Data.LastName,
                PicturePath = response.Data.PicturePath,
                TechnicianId = response.Data.TechnicianID
            });

        }
    }
}
