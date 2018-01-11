using HittaLekparker.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HittaLekparker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PlayGround> Playgrounds { get; set; } = new ObservableCollection<PlayGround>();

        private readonly ApiService _apiService;
        public MainPage()
        {
            _apiService = DependencyService.Get<ApiService>();

            InitializeComponent();
            this.result.ItemsSource = Playgrounds;
            this.result.ItemSelected += Result_ItemSelected;
        }


        private async void Result_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var playground = result.SelectedItem as PlayGround;

            var info = await _apiService.GetPlaygroundInfo(playground.Id);

            await Navigation.PushAsync(new PlaygroundInfoPage(info));
        }


        async void searchBtn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            var text = textEntry.Text;

            var result = await _apiService.GetPlaygrounds(text);
            Playgrounds.Clear();
            if (result.Length < 1)
            {
                await DisplayAlert("Varning", "Namnet på lekparken verkar fel..", "Sök igen");
            }
            foreach (var item in result)
            {
                Playgrounds.Add(item);
            }
            button.IsEnabled = true;

        }

        async void areaBtn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            var area = areaEntry.Text;
            if (!string.IsNullOrWhiteSpace(area))
            {
                area = areaEntry.Text.Replace("ö", "o").Replace("å", "a").Replace("ä", "a");
            }
            else area = areaEntry.Text;

            var result = await _apiService.GetPlaygroundLocation(area);
            Playgrounds.Clear();
            if (result.Length < 1)
            {
                await DisplayAlert("Varning", "Namnet verkar inte stämma..", "Sök igen");
            }
            foreach (var item in result)
            {
                Playgrounds.Add(item);
            }
            button.IsEnabled = true;

        }
    }

}
