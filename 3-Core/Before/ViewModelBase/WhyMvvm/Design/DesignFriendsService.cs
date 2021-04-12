using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhyMvvm.Model;

namespace WhyMvvm.Design
{
    public class DesignFriendsService : IFriendsService
    {
        public Task<IEnumerable<Friend>> Refresh()
        {
            var result = new List<Friend>();

            for (var index = 0; index < 10; index++)
            {
                result.Add(
                    new Friend
                    {
                        FirstName = "FirstName" + index,
                        LastName = "LastName" + index,
                        Id = index,
                        PictureUri = new Uri("https://i.picsum.photos/id/237/3500/2095.jpg?hmac=y2n_cflHFKpQwLOL1SSCtVDqL8NmOnBzEW7LYKZ-z_o")
                    });
            }

            return Task.FromResult((IEnumerable<Friend>)result);
        }

        public Task<Friend> Save(Friend updatedFriend)
        {
            throw new NotImplementedException();
        }
    }
}
