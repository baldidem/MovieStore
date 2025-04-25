using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.DTOs.Customer;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CustomersController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost()]
        public IActionResult Create(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerDto dto)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            _mapper.Map(dto, customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var customers = _context.Customers.Include(c => c.FavoriteGenres).ThenInclude(fg => fg.Genre).ToList();
            var result = _mapper.Map<List<CustomerResponseDto>>(customers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.Include(c => c.FavoriteGenres).ThenInclude(fg => fg.Genre).FirstOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();
            var result = _mapper.Map<CustomerResponseDto>(customer);
            return Ok(result);
        }
    }
}
