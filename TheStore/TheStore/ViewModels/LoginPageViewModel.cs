using System.Windows.Input;
using TheStore.Models;
using TheStore.Models.Products;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public CurrentUser CurrentUser { get; set; }

        private IUserRepo userRepo;

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

        public LoginPageViewModel()
        {
            userRepo = new UserRepo();
            LoginCommand = new Command(Login);
            CurrentUser = new CurrentUser();
        }

        public void Login()
        {
            var user = userRepo.FindUserByEMail(EMail).Result;

            if (user == null)
            {
                Password = "";
                Shell.Current.GoToAsync("//" + nameof(LoginPage));
            }
            else
            {
                if (user.Password == Password)
                {
                    CurrentUser.ActiveUser = user;
                    Shell.Current.GoToAsync("//" + nameof(HomePage));
                }
                else
                {
                    Password = "";
                    Shell.Current.GoToAsync("//" + nameof(LoginPage));
                }
            }
        }
    }
}