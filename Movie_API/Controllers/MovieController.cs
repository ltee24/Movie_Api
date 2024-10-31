using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_API.Models;
using Movie_API.Repository.IRepository;
using Movie_API.Services.IServices;
using Newtonsoft.Json;

namespace Movie_API.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IRepository<MovieDetail> _movieDetail;
        private readonly IMapper _mapper;
        public MovieController(IMovieService movieService,IRepository<MovieDetail> movieDetail,IMapper mapper)
        {
            _movieService = movieService;
            _movieDetail = movieDetail;
            _mapper = mapper;
                
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllModels>> GetMovieDetails()
        {
            //List<AllModels> list = new();
            var drake = await _movieService.GetAllAsync<AllModels>();
            if(await _movieDetail.GetAsync(u=>u.Title.ToLower() == drake.Title.ToLower()) == null)
            {
                MovieDetail thor = _mapper.Map<MovieDetail>(drake);
                await _movieDetail.CreateAsync(thor);
            } 

            return Ok(drake);
        }
    }
}
