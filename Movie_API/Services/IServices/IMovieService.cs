namespace Movie_API.Services.IServices
{
    public interface IMovieService
    {
        Task<T> GetAllAsync<T>(); 
    }
}
