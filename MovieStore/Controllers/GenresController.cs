using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Genre;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenresController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _context.Genres.ToList();
            var result = _mapper.Map<List<GenreResponseDto>>(genres);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            var result = _mapper.Map<GenreResponseDto>(genre);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(GenreDto dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            var result = _mapper.Map<GenreResponseDto>(genre);
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GenreDto dto)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();

            _mapper.Map(dto, genre);
            _context.SaveChanges();
            var result = _mapper.Map<GenreResponseDto>(genre);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
