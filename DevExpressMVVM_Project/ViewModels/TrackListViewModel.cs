using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpressMVVM_Project.Data;
using System;
using System.Windows.Input;

namespace DevExpressMVVM_Project.ViewModels
{
    public class TrackListViewModel : ViewModelBase
    {
        public virtual TrackList Tracks { get; set; }
        public ICommand EditTrackCommand { get; set; }

        protected TrackListViewModel()
        {
            Tracks = new TrackList();
            EditTrackCommand = new DelegateCommand<object>(EditTrack);
        }

        private void EditTrack(object trackObject)
        {
            //trackObject is a generic object, so we cast it into a TrackInfo object
            TrackInfo track = trackObject as TrackInfo;
            var document = DocumentManagerService.CreateDocument("TrackView", TrackViewModel.Create(track));
            document.Show();
        }

        //Instantiate this ViewModel through the factory of the framework
        public static TrackListViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackListViewModel());
        }

        [ServiceProperty(SearchMode =ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
    }
}
