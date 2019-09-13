using Hospital.Core.Repository;
using System.Linq;

namespace Hospital.Authentication
{
    public class AuthenticationService
    {
        private static IRepository _repository;

        public AuthenticationService(IRepository repository)
        {
            _repository = repository;
        }
        public static bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
                return true;
            return false;
        }
    }
}
