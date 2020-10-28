namespace Breweries.Admin.ViewModels
{
    public class BreweyTypeViewModel
    {
        public BreweyTypeViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
