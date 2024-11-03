namespace Movie_API.Services.IServices
{
    public interface IMovieService
    {
        Task<T> GetAllAsync<T>(string title); 
        Task<T> SearchMovieAsync<T>(string title);
        Task<T> SearchMovieDetailAsync<T>(string title);
    }
}
