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
    public partial class Detail : PhoneApplicationPage, IText {
        public Detail() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            string id = "";
            if (NavigationContext.QueryString.TryGetValue("id", out id)) {
                Adhiharam ad = (from adhiharam in App.DB.Adhiharams where adhiharam.Id == Int32.Parse(id) select adhiharam).ToArray<Adhiharam>()[0];
                rootPivotTitle.Text = ad.Id + ". " + ad.Name;
                rootPivotTitleEnglish.Text = ad.EnglishText;
                rootPivot.ItemsSource = ad.Kurals;
                rootPivot.LoadedPivotItem += new EventHandler<PivotItemEventArgs>(rootPivot_LoadedPivotItem);
            }
            string kuralIndex = "";
            if (NavigationContext.QueryString.TryGetValue("kuralId", out kuralIndex)) {
                if (kuralIndex == "0") kuralIndex = "10";
                rootPivot.SelectedIndex = Int32.Parse(kuralIndex) - 1;
            }
            App.ToggleAppBarIcon(this);
        }

        void rootPivot_LoadedPivotItem(object sender, PivotItemEventArgs e) {
            App.ToggleAppBarIcon(this);
        }
        
        public void setEnglishText() {
            foreach (Kural k in rootPivot.Items) {
                k.Visibility = "Visible";
            }
            rootPivotTitleEnglish.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Kural k in rootPivot.Items) {
                k.Visibility = "Collapsed";
            }
            rootPivotTitleEnglish.Visibility = Visibility.Collapsed;
        }

        void Chapters_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Chapters.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }
    }
}