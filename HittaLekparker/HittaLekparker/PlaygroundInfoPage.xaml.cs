using HittaLekparker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HittaLekparker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaygroundInfoPage : ContentPage
    {
        //private RootobjectDetailedInfo _rootobjectDetailedInfo;
        //private readonly ApiService _apiService;

        public PlaygroundInfoPage(RootobjectDetailedInfo detailedInfoObject)
        {
            InitializeComponent();
            Title = "Detaljerad information";

            IdentifierLabel.Text = detailedInfoObject.Name;

            var stackLayot = new StackLayout();
            stackLayot.Margin = 10;

            foreach (var item in detailedInfoObject.Attributes)
            {
                if (!string.IsNullOrEmpty(item.Description))
                {
                    var labelA = new Label
                    {
                        Text = item.Description
                    };
                    stackLayot.Children.Add(labelA);
                }

                if (!string.IsNullOrEmpty(item.Value as string ))
                {
                    var labelB = new Label
                    {
                        Text = item.Name +": " + item.Value as string
                    };
                    stackLayot.Children.Add(labelB);
                }
            }
            this.Content = stackLayot;
        }
    }
}
