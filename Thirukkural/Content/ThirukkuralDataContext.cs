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
using System.Data.Linq;

namespace Thirukkural.Content {
    public class ThirukkuralDataContext : DataContext {

        public static string DBConnectionString = "Data Source = 'appdata:/Content/alpha.sdf'; File Mode = read only;";
        //public static string DBConnectionString = "Data Source=isostore:/alpha.sdf";

        public ThirukkuralDataContext(string connectionString)
            : base(connectionString) {
        }

        public Table<Paal> Paals;
        public Table<Iyal> Iyals;
        public Table<Adhiharam> Adhiharams;
        public Table<Kural> Kurals;        
    }
}
