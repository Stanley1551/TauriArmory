using Acr.UserDialogs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TauriArmoryAPITest;
using TauriArmoryAPITest.Responses;
using TauriArmoryAPITest.Constants;

namespace TauriArmory.ViewModels
{
    public class CharInfoViewModel : INotifyPropertyChanged
    {
        string nameandtitle;
        int level;
        ConstantStrings.RaceId race;
        string realm;
        ConstantStrings.ClassId @class;
        int points;
        string guildname;
        string factionlogo;

        public CharInfoViewModel(string name)
        {
            FillFields(name);
        }

        private async Task FillFields(string name)
        {
            UserDialogs.Instance.ShowLoading("Fetching character data...");
            RequestBody request = new RequestBody();
            CharInfoResponseBody response = new CharInfoResponseBody();
            try
            {
                response = await request.GetCharInfoAsync(name);
            }
            catch (Exception error) { Console.WriteLine(error.Message); }

            if (response.title == null || response.title == string.Empty)
            {
                NameAndTitle = response.name;
            }
            else
            {
                NameAndTitle = response.name + " (" + response.title + ")";
            }

            Level = response.level;
            Race = response.race;
            Realm = response.realm;
            Class = response.Class;
            Points = response.pts;
            GuildName = response.guildName;
            FactionLogo = response.faction_string_class == "Horde" ? "horde_logo" : "alliance_logo";
            UserDialogs.Instance.HideLoading();
        }

        public string NameAndTitle {
            get { return nameandtitle; }

            set {
                nameandtitle = value;
                OnPropertyChanged("NameAndTitle");
            }
        }

        public int Level {
            get { return level; }
            set {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        public ConstantStrings.RaceId Race {
            get { return race; }
            set {
                race = value;
                OnPropertyChanged("Race");
            }
        }
        public string Realm {
            get { return realm; }
            set {
                realm = value;
                OnPropertyChanged("Realm");
            }
        }

        public ConstantStrings.ClassId Class {
            get { return @class; }
            set {
                @class = value;
                OnPropertyChanged("Class");
            }
        }

        public int Points {
            get { return points; }
            set {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        public string GuildName {
            get { return guildname; }
            set {
                if(!(value is null))
                {
                    guildname = value;
                    OnPropertyChanged("GuildName");
                }
            }
        }

        public string FactionLogo {
            get { return factionlogo; }
            set {
                if(!(value is null))
                {
                    factionlogo = value;
                    OnPropertyChanged("FactionLogo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}