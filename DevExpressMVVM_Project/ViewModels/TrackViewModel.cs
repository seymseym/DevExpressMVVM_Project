using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpressMVVM_Project.Data;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace DevExpressMVVM_Project.ViewModels
{
    [POCOViewModel]
    public class TrackViewModel : ViewModelBase
    {
        public ICommand ResetNameCommand { get; set; }
        //public ICommand SaveCommand { get; set; }
        //public ICommand RevertCommand { get; set; }
        private TrackInfo _track { get; set; }

        public virtual int TrackId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Composer { get; set; }

        public TrackInfo Track
        {
            get
            {
                return _track;
            }
            set
            {
                _track = value;
                RaisePropertyChanged(() => Track);
            }
        }

        protected TrackViewModel() // Protected constructor
            
        {
            // Random Data for Test
            //Track = new TrackList()[15]; // Instantiate the property. 15th element of the list.
        }

        protected TrackViewModel (TrackInfo track)
        {
            if(track == null)
            {
                throw new ArgumentNullException("track", "track is null");
            }

            Load(track);
            ResetNameCommand = new DelegateCommand(ResetName, CanResetName, true);
        }

        // In the View: Delete Binding Track.TrackId --> just TrackId, Name, Composer
        // We've seperated data object from the UI by introducing these properties.

        private void Load(TrackInfo track)
        {
            Track = track;
            TrackId = track.TrackId;
            Name = track.Name;
            Composer = track.Composer;
        }

        public static TrackViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackViewModel());
        }
        public static TrackViewModel Create(TrackInfo track)
        {
            return ViewModelSource.Create(() => new TrackViewModel(track));
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
                    Name = "";
                }
            }
        }

        //void IEditableObject.BeginEdit()
        //{
            
        //}

        //void IEditableObject.EndEdit()
        //{
        //    if (!string.Equals(Name, track.Name))
        //        track.Name = Name;
        //    if (!string.Equals(Composer, track.Composer))
        //        track.Composer = Composer;
        //    if (TrackId != track.TrackId)
        //        track.TrackId = TrackId;
        //}

        //void IEditableObject.CancelEdit()
        //{
        //    Load(this.track);
        //}

        //public void Save() { ((IEditableObject)this).EndEdit(); }
        //public void Revert() { ((IEditableObject)this).CancelEdit(); }


        // ServiceProperty attribute on this MessageBoxService property.
        // This determines how to locate any existing surface which might already be there to improve
        // the performance of the application. In this case, we're allowing to search through the 
        // of the ViewModel as well.
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }
    }
}