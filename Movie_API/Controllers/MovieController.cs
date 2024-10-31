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
        private readonly IRepository<Actor> _actor;
        private readonly IMapper _mapper;
        public MovieController(IMovieService movieService, IRepository<MovieDetail> movieDetail, IMapper mapper, IRepository<Actor> actor)
        {
            _movieService = movieService;
            _movieDetail = movieDetail;
            _mapper = mapper;
            _actor = actor;

        }
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllModels>> GetMovieDetails([FromQuery] string title)
        {
            //List<AllModels> list = new();
            var drake = await _movieService.GetAllAsync<AllModels>(title);
            if (await _movieDetail.GetAsync(u => u.Title.ToLower() == drake.Title.ToLower()) == null)
            {
                MovieDetail thor = _mapper.Map<MovieDetail>(drake);
                await _movieDetail.CreateAsync(thor);
            }
            if (await _actor.GetAsync(u => u.Actors.ToLower() == drake.Actors.ToLower()) == null)
            {
                Actor thor = _mapper.Map<Actor>(drake);
                await _actor.CreateAsync(thor);
            }

            return Ok(drake);
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllModels>> SearchMovie([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }
            var searchedMovie = await _movieService.SearchMovieAsync<AllModels>(title);
            return Ok(searchedMovie);
        }



    }
}

