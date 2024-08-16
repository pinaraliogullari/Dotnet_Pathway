using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.TokenOperations.Models;

namespace BookStoreWebApi.Application.UserOperations.Commands.CreateToken
{
    public class LoginCommand
    {
        public LoginModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user= _context.Users.FirstOrDefault(x=>x.Email==Model.Email &&x.Password==Model.Password);
            if (user is not null)
            {
                TokenHandler tokenHandler = new(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı");

        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
