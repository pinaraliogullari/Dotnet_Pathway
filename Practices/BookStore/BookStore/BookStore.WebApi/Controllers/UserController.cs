using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.CreateToken;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateToken.CreateTokenCommand;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace BookStoreWebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUserModel)
        {
            CreateUserCommand command = new(_context, _mapper);
            command.Model = newUserModel;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel model)
        {
            CreateTokenCommand command = new (_context, _mapper, _configuration);
            command.Model= model;
            var token= command.Handle();
            return token;
        }
    }
}
