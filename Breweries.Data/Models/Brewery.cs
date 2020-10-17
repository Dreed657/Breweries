using System;
using System.ComponentModel.DataAnnotations;

namespace Breweries.Data.Models
{
    public class Brewery
    {
        public Brewery()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int BreweryTypeId { get; set; }
        public virtual BreweryType BreweryType { get; set; }

        public string Street { get; set; }

        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        public string PostalCode { get; set; }

        public string Url { get; set; }
    }
}
