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
using Thirukkural.Content;

namespace Thirukkural {
    public partial class Chapters : PhoneApplicationPage, IText {
        private ProgressIndicator _performanceProgressBar;
        public Chapters() {
            InitializeComponent();
        }

        private void Adhiharam_Click(object sender, RoutedEventArgs e) {
            HyperlinkButton button = sender as HyperlinkButton;
            foreach (UIElement element in ((Grid)button.Content).Children) {
                ((TextBlock)element).Foreground = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            }
            ButtonClick();
            this.NavigationService.Navigate(new Uri("/Kurals.xaml?id=" + button.Tag, UriKind.Relative));           
        }

        private void Iyal_Click(object sender, RoutedEventArgs e) {
            HyperlinkButton button = sender as HyperlinkButton;
            foreach (UIElement element in ((Grid)button.Content).Children) {
                ((TextBlock)element).Foreground = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            }
            ButtonClick();
            this.NavigationService.Navigate(new Uri("/Adhiharams.xaml?id=" + button.Tag, UriKind.Relative));
        }

        private void Paal_Click(object sender, RoutedEventArgs e) {
            HyperlinkButton button = sender as HyperlinkButton;
            foreach (UIElement element in ((Grid)button.Content).Children) {
                ((TextBlock)element).Foreground = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            }
            ButtonClick();
            this.NavigationService.Navigate(new Uri("/Iyals.xaml?id=" + button.Tag, UriKind.Relative));
        }

        void TextBlock_Loaded(object sender, RoutedEventArgs e) {
            ((TextBlock)sender).Foreground = (Brush)Application.Current.Resources["PhoneContrastBackgroundBrush"];
        }

        private void Adhiharam_Loaded(object sender, RoutedEventArgs e) {
            if (adhiharams.ItemsSource == null) {
                var items = (from adhiharm in App.DB.Adhiharams select adhiharm);
                adhiharams.ItemsSource = items;
            }
            App.ToggleAppBarIcon(this);
        }

        private void Iyal_Loaded(object sender, RoutedEventArgs e) {
            if (iyals.ItemsSource == null) {
                var items = (from iyal in App.DB.Iyals select iyal);
                iyals.ItemsSource = items;
            }
            App.ToggleAppBarIcon(this);
        }

        private void Paal_Loaded(object sender, RoutedEventArgs e) {
            if (paals.ItemsSource == null) {
                var items = (from paal in App.DB.Paals select paal);
                paals.ItemsSource = items;
            }
            App.ToggleAppBarIcon(this);
        }

        public void setEnglishText() {
            foreach (Iyal i in iyals.Items) {
                i.Visibility = "Visible";
            }
            foreach (Paal i in paals.Items) {
                i.Visibility = "Visible";
            }
            foreach (Adhiharam i in adhiharams.Items) {
                i.Visibility = "Visible";
            }
            indexName.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Iyal i in iyals.Items) {
                i.Visibility = "Collapsed";
            }
            foreach (Paal i in paals.Items) {
                i.Visibility = "Collapsed";
            }
            foreach (Adhiharam i in adhiharams.Items) {
                i.Visibility = "Collapsed";
            }
            indexName.Visibility = Visibility.Collapsed;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }

        private void ButtonClick() {
            if (null == _performanceProgressBar) {
                _performanceProgressBar = new ProgressIndicator();
                _performanceProgressBar.IsVisible = true;
                SystemTray.ProgressIndicator = _performanceProgressBar;
            }
            _performanceProgressBar.IsIndeterminate = true;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            App.ToggleAppBarIcon(this);
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }
    }
}