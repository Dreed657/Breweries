using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Breweries.Data.Models
{
    public class State
    {
        public State()
        {
            this.Breweries = new HashSet<Brewery>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }
    }
}
