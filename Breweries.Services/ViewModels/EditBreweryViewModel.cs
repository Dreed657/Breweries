using System.Collections.Generic;

namespace Breweries.Services.ViewModels
{
    public class EditBreweryViewModel
    {
        public EditBreweryViewModel()
        {
            this.Statues = new HashSet<string>();
            this.Cities = new HashSet<string>();
            this.States = new HashSet<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Status { get; set; }

        public IEnumerable<string> Statues { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<string> States { get; set; }
    }
}
