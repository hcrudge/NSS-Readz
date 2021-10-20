using System.Threading.Tasks;
using Readz.Auth.Models;

namespace Readz.Auth
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseUser> Login(Credentials credentials);
        Task<FirebaseUser> Register(Registration registration);
    }
}