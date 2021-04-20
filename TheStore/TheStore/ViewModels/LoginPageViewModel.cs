using System.Windows.Input;
using TheStore.Models;
using TheStore.Models.Products;
using TheStore.Services;
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
            //check user is in db
            //if he is add to current user as active user

            var user = userRepo.FindUserByEMail(EMail).Result as Customer;


            if (user== null)
            {
                Shell.Current.GoToAsync("..");
            }
            else
            {
                CurrentUser.ActiveUser = user;
                Shell.Current.GoToAsync("..");
            }

            

        }
    }
}