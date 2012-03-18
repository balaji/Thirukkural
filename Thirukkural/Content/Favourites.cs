using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace Thirukkural.Content {
    [Table]
    public class Favourite : INotifyPropertyChanged, INotifyPropertyChanging {

        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id {
            get { return _id; }
            set { if (_id != value) { NotifyPropertyChanging("Id"); _id = value; NotifyPropertyChanged("Id"); } }
        }

        private int _kuralId;
        [Column]
        public int ThirukkuralId {
            get { return _kuralId; }
            set { if (_kuralId != value) { NotifyPropertyChanging("ThirukkuralId"); _kuralId = value; NotifyPropertyChanged("ThirukkuralId"); } }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region INotifyPropertyChanging Members
        public event PropertyChangingEventHandler PropertyChanging;
        private void NotifyPropertyChanging(string propertyName) {
            if (PropertyChanging != null) {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        #endregion
    }

   
}
