namespace Breweries.Services.ViewModels
{
    public class CitiesViewModel
    {
        public CitiesViewModel(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
