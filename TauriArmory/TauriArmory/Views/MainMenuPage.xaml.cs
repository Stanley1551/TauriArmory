using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TauriArmory.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage ()
		{
			InitializeComponent ();
		}

        private void CharSearchButton_Clicked(object sender, EventArgs e)
        {
            
            string name = string.Empty;
            Action<PromptResult> SwitchToCharInfoPage = x =>
            {
                if (x.Ok == true)
                    Navigation.PushAsync(new CharInfoPage(name));
            };
            
            Action<PromptTextChangedArgs> UpdateNameString = x => name = x.Value;
            PromptResult result = new PromptResult(true, "Ok");
            
            PromptConfig prompt = new PromptConfig { Title = "Character name"
                , CancelText = "Back"
                , InputType = InputType.Name
                , MaxLength = 12
                , OkText = "Search"
                , IsCancellable = true
                , AndroidStyleId = 1
                , Placeholder = "Name"
                , Message = "The name of the character: "
                , OnAction = (SwitchToCharInfoPage)
                , OnTextChanged = UpdateNameString
                };
            UserDialogs.Instance.Prompt(prompt);
             
        }

        
    }
}
