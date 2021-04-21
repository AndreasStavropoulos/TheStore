using System.Threading.Tasks;
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
        public Task DisplayAlert { get; private set; }

        public LoginPageViewModel()
        {
            userRepo = new UserRepo();
            LoginCommand = new Command(Login);
        }

        public async void Login()
        {
            User user = userRepo.FindUserByEMail(EMail).Result;

            if (user!=null)
            {
                if (user.Password == Password)
                {
                    var currentUser = CurrentUser.GetInstance();
                    currentUser.ActiveUser = user;
                    ActiveUser = user;
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    return;
                }
            }
           
            
            await App.Current.MainPage.DisplayAlert("Welcome to The Store", "Wrong email or password, please try again", "Ok");
            EMail = string.Empty;
            Password = string.Empty;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}