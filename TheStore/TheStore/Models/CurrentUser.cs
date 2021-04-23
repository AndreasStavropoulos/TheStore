namespace TheStore.Models
{
    public class CurrentUser
    {
        public User ActiveUser { get; set; }

        private static CurrentUser Instance { get; set; }

        private CurrentUser(){}        

        public static CurrentUser GetInstance()
        {
            return Instance ?? (Instance = new CurrentUser());
        }
    }
}