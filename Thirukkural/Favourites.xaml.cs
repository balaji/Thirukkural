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

namespace Thirukkural {
    public partial class Favourites : PhoneApplicationPage {
        private ProgressIndicator _performanceProgressBar;
        public Favourites() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            var ids = App.LocalDB.Favourites.Select(fav => fav.ThirukkuralId).ToList();
            var source = (ids.Count() > 0) ? App.DB.Kurals.Where(kural => ids.Contains(kural.Id)) : null;
            favourites.ItemsSource = source;
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }

        void TextBlock_Loaded(object sender, RoutedEventArgs e) {
            ((TextBlock)sender).Foreground = (Brush)Application.Current.Resources["PhoneContrastBackgroundBrush"];
        }

        void Chapters_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Chapters.xaml", UriKind.Relative));
        }

        private void applyBrush(UIElement element) {
            if (element is TextBlock) {
                ((TextBlock)element).Foreground = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            }

            if (element is Grid) {
                foreach (UIElement childElement in ((Grid)element).Children) {
                    applyBrush(childElement);
                }
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e) {
            HyperlinkButton button = sender as HyperlinkButton;
            foreach (UIElement element in ((Grid)button.Content).Children) {
                applyBrush(element);
            }
            if (null == _performanceProgressBar) {
                _performanceProgressBar = new ProgressIndicator();
                _performanceProgressBar.IsVisible = true;
                SystemTray.ProgressIndicator = _performanceProgressBar;
            }
            _performanceProgressBar.IsIndeterminate = true;
            string adId = App.DB.Kurals.Where(kural => kural.Id == (int)button.Tag).Select(kural => kural.Adhiharam.Id).First().ToString();
            int index = (int)button.Tag % 10;
            this.NavigationService.Navigate(new Uri("/Detail.xaml?id=" + adId + "&kuralId=" + index, UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }
    }
}