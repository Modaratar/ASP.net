namespace MvcApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Passenger> Passengers { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public IndexViewModel(IEnumerable<Passenger> passengers, PageViewModel pageViewModel,
            FilterViewModel filterViewModel)
        {
            Passengers = passengers;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
