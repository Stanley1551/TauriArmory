using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TauriArmoryAPITest.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using TauriArmoryAPITest;
using TauriArmoryAPITest.Responses;
using TauriArmoryAPITest.Constants;
using System.Collections.Generic;

namespace TauriArmory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuildRosterPage : ContentPage
    {
        public ObservableCollection<GuildMember> Members { get; set; }

        public GuildRosterPage(string name)
        {
            
            InitializeComponent();
            Members = new ObservableCollection<GuildMember>();
            if (name != null && name != string.Empty)
                FillItems(name);
            BindingContext = this;
            LV.ItemsSource = Members;
        }

        private async void FillItems(string name)
        {
            UserDialogs.Instance.ShowLoading("Fetching guild data...");
            RequestBody request = new RequestBody();
            GuildRosterResponseBody response = new GuildRosterResponseBody();
            try
            {
                response = await request.GetGuildRosterAsync(name);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            if(response != null && response.MemberList != null && response.MemberList.Count >= 1)
            {
                foreach(GuildMember member in response.MemberList)
                {
                    Members.Add(member);
                }
            }

            UserDialogs.Instance.HideLoading();
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}