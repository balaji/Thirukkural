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
    public class LocalDatabase : DataContext {
        public static string DBConnectionString = "Data Source=isostore:/database5.sdf";
        public LocalDatabase(string connectionString)
            : base(connectionString) {
        }

        public Table<Favourite> Favourites;
    }
}
