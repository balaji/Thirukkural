using System;
using System.Linq;
using System.Windows;
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
            App.ToggleAppBarIcon(this); //this is needed for back key press
        }

        void rootPivot_LoadedPivotItem(object sender, PivotItemEventArgs e) {
            App.ToggleAppBarIcon(this);
            if (App.LocalDB.Favourites.Where(f => f.ThirukkuralId == ((Kural)((Pivot)sender).SelectedItem).Id).Count() > 0) {
                addFavouriteEnabled(false);
            } else {
                addFavouriteEnabled(true);
            }
        }

        private void addFavouriteEnabled(bool enable) {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = enable;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = !enable;
        }

        public void setEnglishText() {
            foreach (Kural k in rootPivot.Items) {
                k.Visibility = "Visible";
                k.EOrder = App.Settings.EOrder;
                k.MOrder = App.Settings.MOrder;
                k.SOrder = App.Settings.SOrder;
                k.KOrder = App.Settings.KOrder;
            }
            rootPivotTitleEnglish.Visibility = Visibility.Visible;
        }

        public void clearEnglishText() {
            foreach (Kural k in rootPivot.Items) {
                k.Visibility = "Collapsed";
                k.EOrder = App.Settings.EOrder;
                k.MOrder = App.Settings.MOrder;
                k.SOrder = App.Settings.SOrder;
                k.KOrder = App.Settings.KOrder;
            }
            rootPivotTitleEnglish.Visibility = Visibility.Collapsed;
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

        private void Favourite_Click(object sender, EventArgs e) {
            App.LocalDB.Favourites.InsertOnSubmit(new Favourite() { ThirukkuralId = ((Kural)rootPivot.SelectedItem).Id });
            App.LocalDB.SubmitChanges();
            addFavouriteEnabled(false);
        }

        private void UnFavourite_Click(object sender, EventArgs e) {
            App.LocalDB.Favourites.DeleteOnSubmit(App.LocalDB.Favourites.Where(fa => fa.ThirukkuralId == ((Kural)rootPivot.SelectedItem).Id).First());
            App.LocalDB.SubmitChanges();
            addFavouriteEnabled(true);
        }

        private void Random_Click(object sender, EventArgs e) {
            int random = new Random().Next(1330);
            this.NavigationService.Navigate(new Uri("/Detail.xaml?id=" + random / 10 + "&kuralId=" + random % 10, UriKind.Relative));
        }
    }
}