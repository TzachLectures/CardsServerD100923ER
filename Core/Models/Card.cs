using CardsServerD100923ER.Core.Models.SubModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CardsServerD100923ER.Core.Models
{
    public class Card
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public Address Address { get; set; }
        public Image Image { get; set; }

        public int BizNumber { get; set; }


        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();

        [NotMapped]
        public List<string> Likes { get => Users.Select(u => u.Id).ToList(); }
    }
}
