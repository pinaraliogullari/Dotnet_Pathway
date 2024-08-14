using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors;
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
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            GetAuthorQuery query = new(_context, _mapper);
            query.AuthorId = id;

            GetAuthorValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorViewModel model)
        {
            CreateAuthorCommand command = new(_context, _mapper);
            command.Model = model;

            CreateAuthorValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, UpdateAuthorViewModel model)
        {
            UpdateAuthorCommand command = new(_context,_mapper);
            command.AuthorId = id;
            command.Model = model;

            UpdateAuthorValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new(_context);
            command.AuthorId = id;

            DeleteAuthorValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }
}
