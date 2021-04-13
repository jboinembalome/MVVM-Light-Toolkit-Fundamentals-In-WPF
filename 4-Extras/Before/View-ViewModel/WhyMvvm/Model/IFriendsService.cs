using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyMvvm.Model
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Refresh();
        Task<Friend> Save(Friend updatedFriend);
    }
}
