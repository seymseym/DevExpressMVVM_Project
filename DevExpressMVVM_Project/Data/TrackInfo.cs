using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressMVVM_Project.Data
{
    public class TrackInfo : ViewModelBase
    {
        public TrackInfo() { } // Constructor
        public TrackInfo(int trackId, string name, int albumId, int mediaTypeId, int genreId,
                         string composer, double milliseconds, double bytes)
        {
            TrackId = trackId;
            Name = name;
            AlbumId = albumId;
            MediaTypeId = mediaTypeId;
            GenreId = genreId;
            Composer = composer;
            Milliseconds = milliseconds;
            Bytes = bytes;
        }

        private int trackId;
        public int TrackId
        {
            get
            {
                return GetProperty(() => this.trackId);
            }
            set
            {
                SetProperty(() => this.trackId, value);
            }
        }

        private string name;
        public string Name
        {
            get => GetProperty(() => name);
            set => SetProperty(() => name, value);
        }

        private int albumId;
        public int AlbumId
        {
            get => GetProperty(() => albumId);
            set => SetProperty(() => albumId, value);
        }

        private int mediaTypeId;
        public int MediaTypeId
        {
            get => GetProperty(() => mediaTypeId);
            set => SetProperty(() => mediaTypeId, value);
        }

        private int genreId;
        public int GenreId
        {
            get => GetProperty(() => genreId);
            set => SetProperty(() => genreId, value);
        }

        private string composer;
        public string Composer
        {
            get => GetProperty(() => composer);
            set => SetProperty(() => composer, value);
        }

        private double milliseconds;
        public double Milliseconds
        {
            get => GetProperty(() => milliseconds);
            set => SetProperty(() => milliseconds, value);
        }

        private double bytes;
        public double Bytes
        {
            get => GetProperty(() => bytes);
            set => SetProperty(() => bytes, value);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Milliseconds: {1}, Composer: {2}",
                Name, Milliseconds, Composer);
        }
    }
}
