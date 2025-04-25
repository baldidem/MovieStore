using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Purchase;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public PurchasesController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PurchaseDto dto)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == dto.MovieId);
            if (movie == null) return NotFound("Movie not found");

            var purchase = new Purchase
            {
                CustomerId = dto.CustomerId,
                MovieId = dto.MovieId,
                Price = movie.Price,
                PurchaseDate = DateTime.UtcNow
            };

            _context.Purchases.Add(purchase);
            _context.SaveChanges();
            return Ok(purchase);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(int customerId)
        {
            var purchases = _context.Purchases
                .Where(p => p.CustomerId == customerId)
                .Include(p => p.Movie)
                .ToList();

            var result = _mapper.Map<List<PurchaseResponseDto>>(purchases);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase == null) return NotFound();
            _context.Purchases.Remove(purchase);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
