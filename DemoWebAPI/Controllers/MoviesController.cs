using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieDomain;
using MovieDomainServices;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(_movieRepository.GetAllMovies());
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _movieRepository.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie newMovie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _movieRepository.AddMovie(newMovie);

            // The id will be updated because the object is passed by reference.
            return CreatedAtAction(nameof(Post), newMovie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> Put(int id, [FromBody] Movie updatedMovie)
        {
            if (id != updatedMovie.Id)
            {
                return BadRequest();
            }

            _movieRepository.SaveMovie(updatedMovie);

            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetMovie(id);

            if (movie == null)
            {
                return BadRequest();
            }

            _movieRepository.DeleteMovie(movie);

            return Ok();
        }
    }
}
