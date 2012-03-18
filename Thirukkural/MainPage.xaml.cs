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
using Microsoft.Phone.Shell;
using System.Windows.Navigation;
using Thirukkural.Content;

namespace Thirukkural {
    public partial class MainPage : PhoneApplicationPage, IText {
        private ProgressIndicator _performanceProgressBar;
        public MainPage() {
            InitializeComponent();
            var items = (from paal in App.DB.Paals select paal);
            paals.ItemsSource = items;
        }

        public void setEnglishText() {
            foreach (Paal p in paals.Items) {
                p.Visibility = "Visible";
            }
            sectionTitle.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Paal p in paals.Items) {
                p.Visibility = "Collapsed";
            }
            sectionTitle.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedFrom(e);
            ApplicationBar.IsVisible = false;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            ApplicationBar.IsVisible = true;
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
            this.NavigationService.Navigate(new Uri("/Iyals.xaml?id=" + button.Tag, UriKind.Relative));
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
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            App.ToggleAppBarIcon(this);
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Favourites.xaml", UriKind.Relative));
        }
    }
}