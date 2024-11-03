
using Movie_API.Models;
using Movie_API.Services.IServices;
using static OMDb_Utility.SD;

namespace Movie_API.Services
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string movieUrl;
        public MovieService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            movieUrl = configuration.GetValue<string>("ServiceUrls:OMDbAPI");
        }
        public async Task<T>  GetAllAsync<T>(string title)
        {
            return  await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{movieUrl}t={title}",
            });

        }

        public async Task<T> SearchMovieAsync<T>(string title)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{movieUrl}t={title}",
            });


        }

        public async Task<T> SearchMovieDetailAsync<T>(string title)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{movieUrl}s={title}",
            });
        }
    }
}
