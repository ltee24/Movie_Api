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
            var apiMovie = await _movieService.GetAllAsync<AllModels>(title);
            if (await _movieDetail.GetAsync(u => u.Title.ToLower() == apiMovie.Title.ToLower()) == null)
            {
                MovieDetail movie = _mapper.Map<MovieDetail>(apiMovie);
                await _movieDetail.CreateAsync(movie);
            }
            if (await _actor.GetAsync(u => u.Actors.ToLower() == apiMovie.Actors.ToLower()) == null)
            {
                Actor movie = _mapper.Map<Actor>(apiMovie);
                await _actor.CreateAsync(movie);
            }

            return Ok(apiMovie);
        }

        [HttpGet("searchByParamT")]
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

        [HttpGet("searchByParamS")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchModel>> SearchMovieDetail([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }
            var searchMovieCollections = await _movieService.SearchMovieDetailAsync<SearchModel>(title);
            return Ok(searchMovieCollections);  

        }
            

    }
}

