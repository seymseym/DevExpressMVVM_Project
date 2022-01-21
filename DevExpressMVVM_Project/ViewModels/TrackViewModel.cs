using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpressMVVM_Project.Data;

namespace DevExpressMVVM_Project.ViewModels
{
    [POCOViewModel]
    public class TrackViewModel : ViewModelBase
    {
        public virtual TrackInfo Track { get; set; }

        protected TrackViewModel() // Protected constructor
        {
            // Random Data for Test
            Track = new TrackList()[15]; // Instantiate the property. 15th element of the list.
        }
        public static TrackViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackViewModel());
        }
    }
}