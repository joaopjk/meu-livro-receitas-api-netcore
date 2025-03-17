using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    public class UserRepository(MyRecipeBookDbContext context) : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _context = context;

        public async Task Add(User user) => await _context.Users.AddAsync(user);

        public async Task<bool> ExistsActiveUserWithEmail(string email) =>
            await _context.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }
}
