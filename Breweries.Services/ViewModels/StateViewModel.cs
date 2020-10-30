namespace Breweries.Services.ViewModels
{
    public class StateViewModel
    {
        public StateViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
