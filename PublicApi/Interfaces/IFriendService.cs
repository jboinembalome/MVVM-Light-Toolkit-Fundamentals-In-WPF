using PublicApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicApi.Interfaces
{
    public interface IFriendService
    {
        Task<Friend> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Friend>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<Friend> AddAsync(Friend friend, CancellationToken cancellationToken = default);
        Task UpdateAsync(Friend friend, CancellationToken cancellationToken = default);
        Task DeleteAsync(Friend friend, CancellationToken cancellationToken = default);
    }
}
