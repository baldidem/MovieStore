using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Movie;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MoviesController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(MovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            var mapped = _mapper.Map<MovieResponseDto>(movie);
            return Ok(mapped);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieDto dto)
        {
            var existing = _context.Movies.Find(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _context.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).ToList();
            var result = _mapper.Map<List<MovieResponseDto>>(movies);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _context.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            var result = _mapper.Map<MovieResponseDto>(movie);
            return Ok(result);
        }
    }
}
