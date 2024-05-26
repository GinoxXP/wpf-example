namespace wpf_example.Service
{
    public interface IUserService
    {
        void SignUp(string username, string password);

        void SignIn(string username, string password);
    }
}
