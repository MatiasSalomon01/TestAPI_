using TestAPI_.Entities;
using TestAPI_.Models.CIty;

namespace TestAPI_.Models.Country
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityViewModel> Cities { get; set; }
    }
}
