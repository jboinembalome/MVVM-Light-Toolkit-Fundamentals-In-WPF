using Microsoft.EntityFrameworkCore;
using PublicApi.Entities;
using PublicApi.Infrastructure.Data;
using PublicApi.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PublicApi.Services
{
    public class FriendService : IFriendService
    {
        protected readonly ContactContext _dbContext;

        public FriendService(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<Friend> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Friends.FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<Friend>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Friends.ToListAsync(cancellationToken);
        }

        public async Task<Friend> AddAsync(Friend friend, CancellationToken cancellationToken = default)
        {
            await _dbContext.Friends.AddAsync(friend);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return friend;
        }

        public async Task UpdateAsync(Friend friend , CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(friend).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Friend friend, CancellationToken cancellationToken = default)
        {
            _dbContext.Friends.Remove(friend);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
