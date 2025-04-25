using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Director;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorsController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(DirectorDto dto)
        {
            var director = _mapper.Map<Director>(dto);
            _context.Directors.Add(director);
            _context.SaveChanges();
            return Ok(director);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, DirectorDto dto)
        {
            var director = _context.Directors.Find(id);
            if (director == null) return NotFound();
            _mapper.Map(dto, director);
            _context.SaveChanges();
            return Ok(director);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var director = _context.Directors.Find(id);
            if (director == null) return NotFound();
            _context.Directors.Remove(director);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var directors = _context.Directors.ToList();
            var result = _mapper.Map<List<DirectorResponseDto>>(directors);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var director = _context.Directors.Find(id);
            if (director == null) return NotFound();
            var result = _mapper.Map<DirectorResponseDto>(director);
            return Ok(result);
        }
    }
}
