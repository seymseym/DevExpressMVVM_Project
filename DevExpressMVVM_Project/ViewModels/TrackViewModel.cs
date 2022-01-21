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

        public TrackViewModel() // Protected constructor
        {
            // Random Data for Test
            Track = new TrackList()[15]; // Instantiate the property. 15th element of the list.
            ResetNameCommand = new DelegateCommand(ResetName, CanResetName, true);
        }

        public bool CanResetName()
        {
            // It can only be reset if there is a track object assigned to this view model
            // and if Track.Name property is not empty
            return Track != null && !String.IsNullOrEmpty(Track.Name);
        }

        public void ResetName()
        {
            if(Track != null)
            {
                Track.Name = "";
            }
        }

        public static TrackViewModel Create()
        {
            return ViewModelSource.Create(() => new TrackViewModel());
        }
    }
}