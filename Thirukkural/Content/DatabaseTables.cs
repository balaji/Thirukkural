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
    public class Paal : INotifyPropertyChanged, INotifyPropertyChanging {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id {
            get { return _id; }
            set { if (_id != value) { NotifyPropertyChanging("Id"); _id = value; NotifyPropertyChanged("Id"); } }
        }

        [Column]
        private string _visibility;
        public string Visibility {
            get { return _visibility; }
            set { if (_visibility != value) { NotifyPropertyChanging("Visibility"); _visibility = value; NotifyPropertyChanged("Visibility"); } }
        }

        [Column]
        private string _name;
        public string Name {
            get { return _name; }
            set { if (_name != value) { NotifyPropertyChanging("Name"); _name = value; NotifyPropertyChanged("Name"); } }
        }

        [Column]
        private string _englishText;
        public string EnglishText {
            get { return _englishText; }
            set { if (_englishText != value) { NotifyPropertyChanging("EnglishText"); _englishText = value; NotifyPropertyChanged("EnglishText"); } }
        }

        private EntitySet<Iyal> _Iyals;
        [Association(Storage = "_Iyals", OtherKey = "_paalId", ThisKey = "Id")]
        public EntitySet<Iyal> Iyals {
            get { return this._Iyals; }
            set { this._Iyals.Assign(value); }
        }

        public Paal() {
            _Iyals = new EntitySet<Iyal>(new Action<Iyal>(this.attachIyal), new Action<Iyal>(this.detachIyal));
        }
        private void attachIyal(Iyal iyal) { NotifyPropertyChanging("Iyal"); iyal.Paal = this; }
        private void detachIyal(Iyal iyal) { NotifyPropertyChanging("Iyal"); iyal.Paal = null; }

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

    [Table]
    public class Iyal : INotifyPropertyChanged, INotifyPropertyChanging {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id {
            get { return _id; }
            set { if (_id != value) { NotifyPropertyChanging("Id"); _id = value; NotifyPropertyChanged("Id"); } }
        }

        [Column]
        private string _name;
        public string Name {
            get { return _name; }
            set { if (_name != value) { NotifyPropertyChanging("Name"); _name = value; NotifyPropertyChanged("Name"); } }
        }

        [Column]
        private string _visibility;
        public string Visibility {
            get { return _visibility; }
            set { if (_visibility != value) { NotifyPropertyChanging("Visibility"); _visibility = value; NotifyPropertyChanged("Visibility"); } }
        }

        [Column]
        private string _index;
        public string Index {
            get { return _index; }
            set { if (_index != value) { NotifyPropertyChanging("Index"); _index = value; NotifyPropertyChanged("Index"); } }
        }

        [Column]
        private string _englishText;
        public string EnglishText {
            get { return _englishText; }
            set { if (_englishText != value) { NotifyPropertyChanging("EnglishText"); _englishText = value; NotifyPropertyChanged("EnglishText"); } }
        }

        [Column]
        internal int _paalId;
        private EntityRef<Paal> _Paal;
        [Association(Storage = "_Paal", ThisKey = "_paalId", OtherKey = "Id", IsForeignKey = true)]
        public Paal Paal {
            get { return _Paal.Entity; }
            set { NotifyPropertyChanging("Paal"); _Paal.Entity = value; if (value != null) { _paalId = value.Id; } NotifyPropertyChanging("Paal"); }
        }

        private EntitySet<Adhiharam> _Adhiharams;
        [Association(Storage = "_Adhiharams", OtherKey = "_iyalId", ThisKey = "Id")]
        public EntitySet<Adhiharam> Adhiharams {
            get { return this._Adhiharams; }
            set { this._Adhiharams.Assign(value); }
        }

        public Iyal() {
            _Adhiharams = new EntitySet<Adhiharam>(new Action<Adhiharam>(this.attachAdhiharam), new Action<Adhiharam>(this.detachAdhiharam));
        }
        private void attachAdhiharam(Adhiharam adhiharam) { NotifyPropertyChanging("Adhiharam"); adhiharam.Iyal = this; }
        private void detachAdhiharam(Adhiharam adhiharam) { NotifyPropertyChanging("Adhiharam"); adhiharam.Iyal = null; }
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

    [Table]
    public class Adhiharam : INotifyPropertyChanged, INotifyPropertyChanging {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id {
            get { return _id; }
            set { if (_id != value) { NotifyPropertyChanging("Id"); _id = value; NotifyPropertyChanged("Id"); } }
        }

        [Column]
        private string _name;
        public string Name {
            get { return _name; }
            set { if (_name != value) { NotifyPropertyChanging("Name"); _name = value; NotifyPropertyChanged("Name"); } }
        }

        [Column]
        private string _visibility;
        public string Visibility {
            get { return _visibility; }
            set { if (_visibility != value) { NotifyPropertyChanging("Visibility"); _visibility = value; NotifyPropertyChanged("Visibility"); } }
        }

        [Column]
        private string _englishText;
        public string EnglishText {
            get { return _englishText; }
            set { if (_englishText != value) { NotifyPropertyChanging("EnglishText"); _englishText = value; NotifyPropertyChanged("EnglishText"); } }
        }

        [Column]
        internal int _iyalId;
        private EntityRef<Iyal> _Iyal;
        [Association(Storage = "_Iyal", ThisKey = "_iyalId", OtherKey = "Id", IsForeignKey = true)]
        public Iyal Iyal {
            get { return _Iyal.Entity; }
            set { NotifyPropertyChanging("Iyal"); _Iyal.Entity = value; if (value != null) { _iyalId = value.Id; } NotifyPropertyChanging("Iyal"); }
        }

        private EntitySet<Kural> _Kurals;
        [Association(Storage = "_Kurals", OtherKey = "_adhiharamId", ThisKey = "Id")]
        public EntitySet<Kural> Kurals {
            get { return this._Kurals; }
            set { this._Kurals.Assign(value); }
        }

        public Adhiharam() {
            _Kurals = new EntitySet<Kural>(new Action<Kural>(this.attachAdhiharam), new Action<Kural>(this.detachAdhiharam));
        }
        private void attachAdhiharam(Kural kural) { NotifyPropertyChanging("Kural"); kural.Adhiharam = this; }
        private void detachAdhiharam(Kural kural) { NotifyPropertyChanging("Kural"); kural.Adhiharam = null; }
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

    [Table]
    public class Kural : INotifyPropertyChanged, INotifyPropertyChanging {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id {
            get { return _id; }
            set { if (_id != value) { NotifyPropertyChanging("Id"); _id = value; NotifyPropertyChanged("Id"); } }
        }

        [Column]
        private string _tamilKural;
        public string TamilKural {
            get { return _tamilKural; }
            set { if (_tamilKural != value) { NotifyPropertyChanging("TamilKural"); _tamilKural = value; NotifyPropertyChanged("TamilKural"); } }
        }

        [Column]
        private string _visibility;
        public string Visibility {
            get { return _visibility; }
            set { if (_visibility != value) { NotifyPropertyChanging("Visibility"); _visibility = value; NotifyPropertyChanged("Visibility"); } }
        }

        private int eOrder = 1;
        private int kOrder = 2;
        private int mOrder = 3;
        private int sOrder = 4;

        public int EOrder {
            get { return eOrder; }
            set { if (eOrder != value) { NotifyPropertyChanging("EOrder"); eOrder = value; NotifyPropertyChanged("EOrder"); } }
        }

        public int KOrder {
            get { return kOrder; }
            set { if (kOrder != value) { NotifyPropertyChanging("KOrder"); kOrder = value; NotifyPropertyChanged("KOrder"); } }
        }

        public int MOrder {
            get { return mOrder; }
            set { if (mOrder != value) { NotifyPropertyChanging("MOrder"); mOrder = value; NotifyPropertyChanged("MOrder"); } }
        }

        public int SOrder {
            get { return sOrder; }
            set { if (sOrder != value) { NotifyPropertyChanging("SOrder"); sOrder = value; NotifyPropertyChanged("SOrder"); } }
        }

        [Column]
        private string _englishExplanation;
        public string EnglishExplanation {
            get { return _englishExplanation; }
            set { if (_englishExplanation != value) { NotifyPropertyChanging("EnglishExplanation"); _englishExplanation = value; NotifyPropertyChanged("EnglishExplanation"); } }
        }

        [Column]
        private string _kalignarExplanation;
        public string KalignarExplanation {
            get { return _kalignarExplanation; }
            set { if (_kalignarExplanation != value) { NotifyPropertyChanging("KalignarExplanation"); _kalignarExplanation = value; NotifyPropertyChanged("KalignarExplanation"); } }
        }

        [Column]
        private string _solomonExplanation;
        public string SolomonExplanation {
            get { return _solomonExplanation; }
            set { if (_solomonExplanation != value) { NotifyPropertyChanging("SolomonExplanation"); _solomonExplanation = value; NotifyPropertyChanged("SolomonExplanation"); } }
        }

        [Column]
        private string _muvaExplanation;
        public string MuvaExplanation {
            get { return _muvaExplanation; }
            set { if (_muvaExplanation != value) { NotifyPropertyChanging("MuvaExplanation"); _muvaExplanation = value; NotifyPropertyChanged("MuvaExplanation"); } }
        }

        [Column]
        internal int _adhiharamId;
        private EntityRef<Adhiharam> _Adhiharam;
        [Association(Storage = "_Adhiharam", ThisKey = "_adhiharamId", OtherKey = "Id", IsForeignKey = true)]
        public Adhiharam Adhiharam {
            get { return _Adhiharam.Entity; }
            set { NotifyPropertyChanging("Adhiharam"); _Adhiharam.Entity = value; if (value != null) { _adhiharamId = value.Id; } NotifyPropertyChanging("Adhiharam"); }
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
