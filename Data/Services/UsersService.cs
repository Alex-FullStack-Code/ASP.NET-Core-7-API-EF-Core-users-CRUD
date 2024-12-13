using CrudApi.DTOs;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApiContext _context;
        public UsersService(ApiContext context) 
        {
            _context = context;
        }

        private static UserDto UserToDto(User user) =>
            new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                PersonalNumber = user.PersonalNumber,
                UsernameId = user.UsernameId,
            };

        public async Task<User> Add(UserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                PersonalNumber = userDto.PersonalNumber,
                UsernameId = userDto.UsernameId
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserDisplayDto>> GetAll()
        {
            var user = await _context.Users.Select(u => new UserDisplayDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                PersonalNumber = u.PersonalNumber,
                Username = u.Username.Name,
                PostContents = u.Posts.Select(p =>p.Content).ToList(),
                UserCommunities = u.UserCommunities.Select(c =>c.Community.Name).ToList()
            }).ToListAsync();

            return user;

        }

        public async Task<UserDisplayDto> GetById(int id)
        {
            var user = await _context.Users.Where(u =>u.Id == id).Select(u => new UserDisplayDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                PersonalNumber = u.PersonalNumber,
                Username = u.Username.Name,
                PostContents = u.Posts.Select(p => p.Content).ToList(),
                UserCommunities = u.UserCommunities.Select(c => c.Community.Name).ToList()
            }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserDto> Update(int id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Age = userDto.Age;
                user.PersonalNumber = userDto.PersonalNumber;
                user.UsernameId = userDto.UsernameId;

                await _context.SaveChangesAsync();
            }
            return userDto;
        }
    }
}
