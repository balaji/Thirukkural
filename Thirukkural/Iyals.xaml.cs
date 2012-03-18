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
    public partial class Iyals : PhoneApplicationPage, IText {
        private ProgressIndicator _performanceProgressBar;
        public Iyals() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            string id = "";
            if (NavigationContext.QueryString.TryGetValue("id", out id)) {
                Paal chosenPaal = (from paal in App.DB.Paals where paal.Id == Int32.Parse(id) select paal).ToArray<Paal>()[0];
                PageTitle.Text = chosenPaal.Name;
                iyals.ItemsSource = chosenPaal.Iyals;
            }
            App.ToggleAppBarIcon(this);
            if (_performanceProgressBar != null) {
                _performanceProgressBar.IsIndeterminate = false;
            }
        }

        public void setEnglishText() {
            foreach (Iyal i in iyals.Items) {
                i.Visibility = "Visible";
            }
            sectionTitle.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Iyal i in iyals.Items) {
                i.Visibility = "Collapsed";
            }
            sectionTitle.Visibility = Visibility.Collapsed;
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
            this.NavigationService.Navigate(new Uri("/Adhiharams.xaml?id=" + button.Tag, UriKind.Relative));
        }

        void TextBlock_Loaded(object sender, RoutedEventArgs e) {
            ((TextBlock)sender).Foreground = (Brush)Application.Current.Resources["PhoneContrastBackgroundBrush"];
        }

        void Chapters_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Chapters.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Favourites.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }

    }
}