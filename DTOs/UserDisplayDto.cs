using CrudApi.Models;

namespace CrudApi.DTOs
{
    public class UserDisplayDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int PersonalNumber { get; set; }
        public string? Username { get; set; }

        public List<string>? PostContents { get; set; }

        public List<string>? UserCommunities { get; set; }
    }
}
