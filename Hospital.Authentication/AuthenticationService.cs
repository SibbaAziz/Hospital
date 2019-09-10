namespace Hospital.Authentication
{
    public class AuthenticationService
    {
        public static bool Login(string username, string password)
        {
            return username == "Aziz" && password == "aziz";
        }
    }
}
