using System.ComponentModel.DataAnnotations;

namespace Breweries.Data.Models
{
    public class BreweryType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
