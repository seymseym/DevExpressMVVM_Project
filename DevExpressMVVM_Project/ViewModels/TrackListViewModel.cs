using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpressMVVM_Project.Data;

namespace DevExpressMVVM_Project.ViewModels
{
    public class TrackListViewModel : ViewModelBase
    {
        public virtual TrackList Tracks { get; set; }

        protected TrackListViewModel()
        {
            Tracks = new TrackList();
        }

        //Instantiate this ViewModel through the factory of the framework
        public static TrackListViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackListViewModel());
        }
    }
}
