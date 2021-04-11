using System;

namespace PublicApi.Entities
{
    public class Friend
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Link { get; set; }

        public string Picture { get; set; }

        public string Location { get; set; }

        public string Message { get; set; }

        public void UpdateDetails(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
