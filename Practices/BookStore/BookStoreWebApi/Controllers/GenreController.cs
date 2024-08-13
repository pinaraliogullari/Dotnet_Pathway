using AutoMapper;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenre;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetRenges()
        {
            GetGenresQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetRenges(int id)
        {
            GetGenreQuery query = new(_context, _mapper);
            query.GenreId = id;

            GetGenreValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new(_context, _mapper);
            command.Model = newGenre;

            CreateGenreValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            //return Created("",newGenre.Name);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody] UpdateGenreModel updateGenre, int id)
        {
            UpdateGenreCommand command = new(_context);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new(_context);
            command.GenreId = id;

            DeleteGenreValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
