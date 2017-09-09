using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TauriArmoryAPITest.Responses;
using TauriArmoryAPITest;
using TauriArmory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using System.Diagnostics;

namespace TauriArmory.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharInfoPage : ContentPage
	{
        


        public CharInfoPage (string name)
		{
			InitializeComponent();
            BindingContext = new CharInfoViewModel(name);
		}

        
    }
}
