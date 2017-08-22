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
	public partial class CharInfoPage : ContentPage
	{
		public CharInfoPage (string name)
		{
			InitializeComponent ();

            FillFields(name);
		}

        private async Task FillFields(string name)
        {
            RequestBody request = new RequestBody();
            CharInfoResponseBody response = new CharInfoResponseBody();
            try
            {
                response = await request.GetCharInfoAsync(name);
            }
            catch (Exception error) { Console.WriteLine(error.Message); }
            fillablePts.Text = response.pts.ToString();
            fillableClass.Text = response.Class.ToString();
            fillableLevel.Text = response.level.ToString();
        }
    }
}
