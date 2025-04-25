using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Actor;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorsController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ActorDto dto)
        {
            var actor = _mapper.Map<Actor>(dto);
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return Ok(actor);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, ActorDto dto)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null) return NotFound();
            _mapper.Map(dto, actor);
            _context.SaveChanges();
            return Ok(actor);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null) return NotFound();
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = _context.Actors.ToList();
            var result = _mapper.Map<List<ActorResponseDto>>(actors);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null) return NotFound();
            var result = _mapper.Map<ActorResponseDto>(actor);
            return Ok(result);
        }
    }
}
