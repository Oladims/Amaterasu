using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Amaterasu.Dtos;
using Amaterasu.Models;
using AutoMapper;

namespace Amaterasu.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return db.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = db.Movies.SingleOrDefault(c => c.Id == id);

            if (id != movie.Id)
                return BadRequest();

            if (!MovieExists(id))
                return NotFound();

            Mapper.Map(movieDto, movie);

            //db.Entry(movieDto).State = EntityState.Modified;
            db.SaveChanges();
            //return StatusCode(HttpStatusCode.NoContent);
            return Ok();
        }
        // POST: api/Movies
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            db.Movies.Add(movie);
            db.SaveChanges();

            movieDto.Id = movie.Id;

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
                return NotFound();

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}