using CardsServerD100923ER.Core.Models.SubModels;
using System.Net;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace CardsServerD100923ER.Core.Models
{
    public class User
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Name Name { get; set; }
        public Address Address { get; set; }
        public Image Image { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
        public bool IsBusiness { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
