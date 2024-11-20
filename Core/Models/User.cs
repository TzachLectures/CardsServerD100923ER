using System.Net;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace CardsServerD100923ER.Core.Models
{
    public class User
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Name
        //Address
        public bool IsAdmin { get; set; }
        public bool IsBusiness { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
