using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            
            if(user == null)
            {
                return null;
            }
            
            var passwordHashFromdb = user.Password;
            var passwordHashFromUser = HashThenUnsaltPassword(password, user.PasswordSalt);
            if (passwordHashFromdb.SequenceEqual(passwordHashFromUser))
            {
                return user;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<int> Register(UserRegisterDto userRegisterDto)
        {
            var userEmail = userRegisterDto.Email;
            if(await _userRepository.UserExists(userEmail))
            {
                throw new Exception("User already exists");
            }

            //byte[] passwordHash;
            //byte[] passwordSalt;
            (var passwordHash, var passwordSalt) = HashPassword(userRegisterDto.Password);
            var user = new User()
            {
                Name = userRegisterDto.Name.ToLower(),
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                TownId = userRegisterDto.TownId,
                PhoneNumber = userRegisterDto.PhoneNumber,
                Email = userRegisterDto.Email,
                RegistrationDate = DateTime.Now
                
            };

            await _userRepository.Create(user);
            await _userRepository.Save();
            if(user.UserId != default)
            {
                return user.UserId;
            }
            else
            {
                throw new Exception("Could not save user to db");
            }            
        }


        public string CreateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescritor);
            return tokenHandler.WriteToken(token);

        }


        private (byte[] pwHash, byte[] sltHash) HashPassword(string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) { 
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return (passwordHash, passwordSalt);
        }

        private byte[] HashThenUnsaltPassword(string passwordFromUser, byte[] hashSalt)
        {
            byte[] passwordHash;
            using (var hmac = new System.Security.Cryptography.HMACSHA512(hashSalt))
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordFromUser));
            }

            return passwordHash;
        }

    }
}
