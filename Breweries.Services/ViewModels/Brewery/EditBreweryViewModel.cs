using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Breweries.Services.ViewModels.Brewery
{
    public class EditBreweryViewModel
    {
        public EditBreweryViewModel()
        {
            this.Statues = new HashSet<string>();
            this.Cities = new HashSet<string>();
            this.States = new HashSet<string>();
        }
        
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Status { get; set; }

        public IEnumerable<string> Statues { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<string> States { get; set; }
    }
}
