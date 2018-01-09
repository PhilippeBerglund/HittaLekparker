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
		public PlaygroundInfoPage (PlayGround playGround)
		{
			InitializeComponent ();
            Title = "Tillbaka till Sök..";
            IdentifierLabel.Text = playGround.Name;
            GeoTagLabel.Text = playGround.GeographicalPosition.X + ", " + playGround.GeographicalPosition.Y; 


        }
	}
}