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
    public partial class Kurals : PhoneApplicationPage, IText {
        private ProgressIndicator _performanceProgressBar;
        public Kurals() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            string id = "";
            if (NavigationContext.QueryString.TryGetValue("id", out id)) {
                Adhiharam ad = (from adhiharam in App.DB.Adhiharams where adhiharam.Id == Int32.Parse(id) select adhiharam).ToArray<Adhiharam>()[0];
                PageTitle.Text = ad.Id + ". " + ad.Name;
                sectionTitle.Text = ad.EnglishText;
                adhiharams.ItemsSource = ad.Kurals;
            }
            App.ToggleAppBarIcon(this);
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }
        public void setEnglishText() {
            sectionTitle.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            sectionTitle.Visibility = Visibility.Collapsed;
        }
        void TextBlock_Loaded(object sender, RoutedEventArgs e) {
            ((TextBlock)sender).Foreground = (Brush)Application.Current.Resources["PhoneContrastBackgroundBrush"];
        }

        void Chapters_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Chapters.xaml", UriKind.Relative));
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
            string adId = PageTitle.Text.Split('.')[0];
            int index = (int)button.Tag % 10;
            this.NavigationService.Navigate(new Uri("/Detail.xaml?id=" + adId + "&kuralId=" + index, UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }
    }
}