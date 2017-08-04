using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TauriArmoryAPITest.Responses;
using TauriArmoryAPITest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TauriArmory.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        private async Task SearchButton_Clicked(object sender, EventArgs e)
        {
            string name = textEntry.Text;
            RequestBody request = new RequestBody();
            CharInfoResponseBody response = new CharInfoResponseBody();
            try
            {
                response = await request.GetCharInfoAsync(name);
            }
            catch (Exception error) { Console.WriteLine(error.Message); }
            fillableName.Text = response.name;
            fillablePts.Text = response.pts.ToString();
            fillableClass.Text = response.Class.ToString();
            fillableLevel.Text = response.level.ToString();
        }
    }
}
