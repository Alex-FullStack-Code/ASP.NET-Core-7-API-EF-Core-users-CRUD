namespace CrudApi.Models
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserCommunity>? UserCommunities { get; set; }
    }
}
