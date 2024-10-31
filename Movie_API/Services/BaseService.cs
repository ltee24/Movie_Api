using Movie_API.Models;
using Movie_API.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace Movie_API.Services
{
    public class BaseService : IBaseService
    {
        public ApiResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ApiResponse();
            this.httpClient = httpClient;
            
        }
        public  async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MovieAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                //if (apiRequest.Data != null)
                //{
                //    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                //}
                message.Method = HttpMethod.Get;
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.GetAsync(new Uri (apiRequest.Url));
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;

            }
            catch(Exception e) 
            {
                var dto = new ApiResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var ApiResponse =  JsonConvert.DeserializeObject<T>(res);
                return ApiResponse;
            }
        }
    }
}
