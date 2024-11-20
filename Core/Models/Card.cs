using System.ComponentModel.DataAnnotations;
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

        //Image {}
        //Address {}

        public int BizNumber { get; set; }
        //public List<string> Likes { get; set; } = new List<string>();         
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
