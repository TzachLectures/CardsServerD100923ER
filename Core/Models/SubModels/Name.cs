using Microsoft.EntityFrameworkCore;

namespace CardsServerD100923ER.Core.Models.SubModels
{
    [Owned]
    public class Name
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
    }
}
