using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
