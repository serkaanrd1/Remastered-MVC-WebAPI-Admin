using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace RemasteredPanel.MvcUI.ApiServices
{
  public class HttpApiService : IHttpApiService
  {
    private readonly IHttpClientFactory _httpClientFactory;
    // IHttpClientFactory tipindeki nesneyi kullanarak HttpClient nesneini IoC containerdan elde edeceğiz. Bu şekilde HttpClient nesnesi elde etmek performans açısından best practice'dir. Çünkü bu şekilde elde etmek, tek bir request içerisind ehep aynı ob je kullanılacağı için bellek yönetimi açısından en iyisidir. 

    public HttpApiService(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }


        public async Task<bool> DeleteData(string requestUri, string token = null)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://localhost:5083/api{requestUri}"),
                Headers =
        {
          {HeaderNames.Accept,"application/json" }
        }
            };

            // servisle haberleşecek olan HttpClient nesnesi elde ediliyor : 
            var client = _httpClientFactory.CreateClient();

            // servise request gönderiliyor : 
            var responseMessage = await client.SendAsync(requestMessage);

            return responseMessage.IsSuccessStatusCode;

        }
        public async Task<T> GetData<T>(string requestUri) 
    {
      T response = default(T);

      // Servise göndereceğim request : 
      var requestMessage = new HttpRequestMessage()
      {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"http://localhost:5083/api{requestUri}"),
        Headers =
        {
          {HeaderNames.Accept,"application/json" }
        }
      };

      // servisle haberleşecek olan HttpClient nesnesi elde ediliyor : 
      var client = _httpClientFactory.CreateClient();

      // servise request gönderiliyor : 
      var responseMessage = await client.SendAsync(requestMessage);

      // servisden gelen yanıt T tipine dönüşütürülüyor :
        var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

        response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

      // servisden gelen yanıt T tipinde döndürülüyor
      return response;
    }

    public async Task<T> PostData<T>(string requestUri, string jsonData)
    {
      T response = default(T);

      var requestMessage = new HttpRequestMessage()
      {
        Method = HttpMethod.Post,
        RequestUri = new Uri($"http://localhost:5083/api{requestUri}"),
        Headers =
        {
          {HeaderNames.Accept,"application/json" }
        },
        Content = new StringContent(jsonData,Encoding.UTF8,"application/json")
      };

      var client = _httpClientFactory.CreateClient();

      var responseMessage = await client.SendAsync(requestMessage);

      var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

      response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

      return response;
    }
  }
}
