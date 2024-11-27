using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CardsServerD100923ER.Core.Models.SubModels
{
    [Owned]
    public class Name
    {
        [Required, StringLength(maximumLength:256, MinimumLength =2)]
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
    }
}
