using Movie_API.Models;

namespace Movie_API.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set;  }
        Task<T>  SendAsync<T>(ApiRequest apiRequest);
    }
}
