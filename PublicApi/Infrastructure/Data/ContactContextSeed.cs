using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublicApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicApi.Infrastructure.Data
{
    public class ContactContextSeed
    {
        public static async Task SeedAsync(ContactContext catalogContext,
           ILoggerFactory loggerFactory, int? retry = 0)
        {
            if (catalogContext is null)
            {
                throw new ArgumentNullException(nameof(catalogContext));
            }

            int retryForAvailability = retry.Value;
            try
            {
                if (!await catalogContext.Friends.AnyAsync())
                {
                    await catalogContext.Friends.AddRangeAsync(
                        GetPreconfiguredFriends());

                    await catalogContext.SaveChangesAsync();
                }           
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ContactContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<Friend> GetPreconfiguredFriends()
        {
            return new List<Friend>()
            {
                new Friend { Id = 1, FirstName = "Velazquez", LastName = "Smethley", Birthday = new DateTime(1990, 2, 12), Message = "Hello world !", Picture = "https://localhost:44376/api/picture/Abbott.jpg" },
                new Friend { Id = 2, FirstName = "Abbott", LastName = "Keitch", Birthday = new DateTime(1989, 3, 13), Message = "Good Bye !", Picture = "https://localhost:44376/api/picture/Abbott.jpg" },
                new Friend { Id = 3, FirstName = "Christy", LastName = "Camacho", Birthday = new DateTime(1988, 4, 14), Message = "Happy birthday !", Picture = "https://localhost:44376/api/picture/Christy.jpg" },
                new Friend { Id = 4, FirstName = "Nora", LastName = "Franklin", Birthday = new DateTime(1987, 5, 15), Message = "Happy new year !", Picture = "https://localhost:44376/api/picture/Nora.jpg" },
                new Friend { Id = 5, FirstName = "Tillman", LastName = "Lee", Birthday = new DateTime(1986, 6, 16), Message = "Good morning !", Picture = "https://localhost:44376/api/picture/Tillman.jpg" } 
            };
        }
    }
}
