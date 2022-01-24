using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpressMVVM_Project.Data;
using System;
using System.Windows.Input;

namespace DevExpressMVVM_Project.ViewModels
{
    [POCOViewModel]
    public class TrackViewModel : ViewModelBase
    {
        public ICommand ResetNameCommand { get; set; }
        public virtual TrackInfo Track { get; set; }

        protected TrackViewModel() // Protected constructor
        {
            // Random Data for Test
            Track = new TrackList()[15]; // Instantiate the property. 15th element of the list.
            ResetNameCommand = new DelegateCommand(ResetName, CanResetName, true);
        }

        protected TrackViewModel (TrackInfo track)
        {
            if(track == null)
            {
                throw new ArgumentNullException("track", "track is null");
            }

            Load(track);
        }

        private void Load(TrackInfo track)
        {
            this.Track = track;
        }

        public static TrackViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackViewModel());
        }
        public static TrackViewModel Create(TrackInfo track)
        {
            return ViewModelSource.Create(() => new TrackViewModel());
        }

        public bool CanResetName()
        {
            // It can only be reset if there is a track object assigned to this view model
            // and if Track.Name property is not empty
            return Track != null && !String.IsNullOrEmpty(Track.Name);
        }

        public void ResetName()
        {
            if (Track != null)
            {
                if (MessageBoxService.ShowMessage("Are you sure?", "Question",
                                                MessageButton.YesNoCancel,
                                                MessageIcon.Question,
                                                MessageResult.No) == MessageResult.Yes)
                {
                    Track.Name = "";
                }
            }
        } 


        // ServiceProperty attribute on this MessageBoxService property.
        // This determines how to locate any existing surface which might already be there to improve
        // the performance of the application. In this case, we're allowing to search through the 
        // of the ViewModel as well.
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }
    }
}