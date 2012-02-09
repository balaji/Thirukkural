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
using Thirukkural.Content;
using Microsoft.Phone.Shell;

namespace Thirukkural {
    public partial class Adhiharams : PhoneApplicationPage, IText {
        private ProgressIndicator _performanceProgressBar;
        public Adhiharams() {
            InitializeComponent();
        }

        public void setEnglishText() {
            foreach (Adhiharam a in adhiharams.Items) {
                a.Visibility = "Visible";
            }
            sectionTitle.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Adhiharam a in adhiharams.Items) {
                a.Visibility = "Collapsed";
            }
            sectionTitle.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            string id = "";
            if (NavigationContext.QueryString.TryGetValue("id", out id)) {
                Iyal chosenIyal = (from iyal in App.DB.Iyals where iyal.Id == Int32.Parse(id) select iyal).ToArray<Iyal>()[0];
                PageTitle.Text = chosenIyal.Name;
                adhiharams.ItemsSource = chosenIyal.Adhiharams;
            }
            App.ToggleAppBarIcon(this);
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e) {
            HyperlinkButton button = sender as HyperlinkButton;
            foreach (UIElement element in ((Grid)button.Content).Children) {
                ((TextBlock)element).Foreground = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            }
            if (null == _performanceProgressBar) {
                _performanceProgressBar = new ProgressIndicator();
                _performanceProgressBar.IsVisible = true;
                SystemTray.ProgressIndicator = _performanceProgressBar;
            }
            _performanceProgressBar.IsIndeterminate = true;
            this.NavigationService.Navigate(new Uri("/Kurals.xaml?id=" + button.Tag, UriKind.Relative));
        }

        void TextBlock_Loaded(object sender, RoutedEventArgs e) {
            ((TextBlock)sender).Foreground = (Brush)Application.Current.Resources["PhoneContrastBackgroundBrush"];
        }

        void Chapters_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Chapters.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }

    }
}