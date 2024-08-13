using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            GetAuthorQuery query = new(_context, _mapper);
            query.AuthorId = id;

            GetAuthorValidator validator = new();
            validator.ValidateAndThrow(query);

            var result= query.Handle();
            return Ok(result);
        }
    }
}
