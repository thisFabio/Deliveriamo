using CommunityToolkit.Mvvm.ComponentModel;
using DeliveriamoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveriamoApp.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private bool isEnabled = true;
        private bool isLoading = false;
        private string userName;
        private string password;



        public bool IsEnabled { get { return isEnabled; } set { this.SetProperty(ref isEnabled, value); } }
        public bool IsLoading { get { return isLoading; } set { this.SetProperty(ref isLoading, value); } }
        public string Username { get { return userName; } set { this.SetProperty(ref userName, value); } }
        public string Password { get { return password; } set { this.SetProperty(ref password, value); } }


        public ICommand Login { get; set; }

        public LoginViewModel()
        {
            Login = new Command(async () =>
            {
                IsLoading = true;
                IsEnabled = false;
                using(var httpClient = new HttpClient())
                {
                    var client = new Client("https://localhost:7232",httpClient);
                    var res = await client.LoginAsync(new LoginRequestDto()
                    {
                        Username = this.Username,
                        Password = this.Password
                    });
                    if (res.Success && !String.IsNullOrEmpty(res.Token))
                    {
                        ((App)App.Current).Token = res.Token;
                        await Shell.Current.GoToAsync("//HomePage");

                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert("Attenzione", String.IsNullOrEmpty(res.ErrorMessage)?"Credenziali non valide.":res.ErrorMessage, "Ok");
                    }

                }
                IsEnabled = true;
                IsLoading = false;


            });
        }
    }
}
