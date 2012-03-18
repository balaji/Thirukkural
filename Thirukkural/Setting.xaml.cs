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

        const string english = "English Text";
        const string muva = "Mu. Va. Text";
        const string kalaignar = "Kalaignar Text";
        const string solomon = "Solomon Pappaiah Text";
        
        Dictionary<int, string> map = new Dictionary<int, string>() {
            {0, english},
            {1, muva},
            {2, kalaignar},
            {3, solomon}
        };

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ListPicker[] lists = new ListPicker[] { first, second, third, fourth };
            foreach (ListPicker l in lists) {
                l.Items.Add(english);
                l.Items.Add(muva);
                l.Items.Add(kalaignar);
                l.Items.Add(solomon);
            }         

            enable(first, App.Settings.EOrder);
            enable(second, App.Settings.MOrder);
            enable(third, App.Settings.KOrder);
            enable(fourth, App.Settings.SOrder);

            choice1.IsChecked = App.Toggle;
        }

        public Setting() {
            InitializeComponent();            
        }

        private void enable(ListPicker l, int v) {
            l.SelectedIndex = v - 1;
            l.IsEnabled = true;
        }

        private void toggle1_Checked(object sender, RoutedEventArgs e) {
            App.Toggle = true;
        }

        private void toggle1_Unchecked(object sender, RoutedEventArgs e) {
            App.Toggle = false;
        }

        private void rearrange(ListPicker[] x, ListPicker sender, int index) {
            foreach (ListPicker l in x) {
                if (l.IsEnabled && l.SelectedItem == sender.SelectedItem) {
                    var previousValue = map[index];
                    var newValue = (string)l.SelectedItem;
                    int previousIndex = getKey(newValue);

                    map[index] = newValue;
                    map[previousIndex] = previousValue;
                    l.SelectedItem = previousValue;
                    break;
                }
            }

            App.Settings.EOrder = getKey(english) + 1;
            App.Settings.MOrder = getKey(muva) + 1;
            App.Settings.SOrder = getKey(solomon) + 1;
            App.Settings.KOrder = getKey(kalaignar) + 1;
        }

        private int getKey(string value) {
            foreach (KeyValuePair<int, string> pair in map)
                if (value.Equals(pair.Value)) return pair.Key;
            return -1;
        }

        private void first_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rearrange(new ListPicker[] { second, third, fourth }, (ListPicker)sender, 0);
        }

        private void second_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rearrange(new ListPicker[] { first, third, fourth }, (ListPicker)sender, 1);
        }

        private void third_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rearrange(new ListPicker[] { first, second, fourth }, (ListPicker)sender, 2);
        }

        private void fourth_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rearrange(new ListPicker[] { first, second, third }, (ListPicker)sender, 3);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            first.SelectionChanged += new SelectionChangedEventHandler(first_SelectionChanged);
            second.SelectionChanged += new SelectionChangedEventHandler(second_SelectionChanged);
            third.SelectionChanged += new SelectionChangedEventHandler(third_SelectionChanged);
            fourth.SelectionChanged += new SelectionChangedEventHandler(fourth_SelectionChanged);
        }
    }
}