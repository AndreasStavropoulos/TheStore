using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TheStore.Models;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IUserRepo userRepo;

        private string eMail;

        public string EMail
        {
            get { return eMail; }
            set
            {
                eMail = value;
                OnPropertyChanged(nameof(EMail));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public Task DisplayAlert { get; private set; }

        public LoginPageViewModel()
        {
            userRepo = new UserRepo();
            LoginCommand = new Command(Login);
            _ = GetUsersAsync();
            
        }

        private async Task GetUsersAsync()
        {
            List<User> users = await userRepo.GetAllUsersAsync();
            if (users.Count == 0)
            {
                DummyData dummyData = new DummyData();
                dummyData.FillDb();
            }
        }

        public async void Login()
        {
            User user = userRepo.FindUserByEMail(EMail).Result;

            if (user != null)
            {
                if (user.Password == Password)
                {                   
                    CurrentUser.ActiveUser = user;
                    Application.Current.MainPage = new AppShell();                    

                    var a = userRepo.GetUserByIdAsync(CurrentUser.ActiveUser.Id);
                    return;
                }
            }

            await App.Current.MainPage.DisplayAlert("Welcome to The Store", "Wrong email or password, please try again", "Ok");
            EMail = string.Empty;
            Password = string.Empty;
            Application.Current.MainPage = new LoginPage();
            
        }
    }
}