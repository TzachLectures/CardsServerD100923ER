using Microsoft.EntityFrameworkCore;

namespace CardsServerD100923ER.Core.Models.SubModels
{
    [Owned]
    public class Image
    {
        public string Url { get; set; }
        public string Alt { get; set; }
    }
}
