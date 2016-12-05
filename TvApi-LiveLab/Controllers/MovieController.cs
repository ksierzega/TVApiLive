using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvApi_LiveLab.Models;

namespace TvApi_LiveLab.Controllers
{
    public class MovieController : ApiController
    {
        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id =1 ,
                    Author= "jasio stasio",
                    Title = "Super film",
                    Comments = new List<string> { "super", "Cool" }
                },
                new Movie
                {
                    Id  = 2,
                    Author ="xxx yyy",
                    Title = "XXX YYY",
                    Comments = new List<string>(),
                }
            };
        }

        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            List<Movie> movies = GetMovies();

            Movie movie =
                movies.Where(m => m.Id == id).SingleOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<Movie> movies = GetMovies();

            return Ok(movies);
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]Movie movie)
        {
            //add to db
            return Ok(movie);
        }

        [HttpDelete, Route("movies/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            List<Movie> movies = GetMovies();

            var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }

            movies.Remove(movie);

            return Ok();                
        }
    }
}
