using System.ComponentModel.DataAnnotations;

namespace Breweries.Services.ViewModels.Brewery
{
    public class InputBreweryEditModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }

        public string Url { get; set; }
    }
}
