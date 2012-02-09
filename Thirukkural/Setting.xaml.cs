using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Thirukkural {
    public partial class Setting : PhoneApplicationPage {
        public Setting() {
            InitializeComponent();
            toggle.IsChecked = App.Toggle;
        }

        private void toggle_Checked(object sender, RoutedEventArgs e) {
            App.Toggle = true;
        }

        private void toggle_Unchecked(object sender, RoutedEventArgs e) {
            App.Toggle = false;
        }
    }
}