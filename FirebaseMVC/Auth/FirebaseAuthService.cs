using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Readz.Auth.Models;

namespace Readz.Auth
{

    //Manager for managing communication with Firebase
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private const string FIREBASE_SIGN_IN_BASE_URL =
            "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=";
        private const string FIREBASE_SIGN_UP_BASE_URL =
            "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _firebaseApiKey;
        private readonly JsonSerializerOptions _jsonSerializerOptions;


        //constructor - same namespace as the class for which it is the constructor.
        public FirebaseAuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            // analagous to the FetchAPI (like our managers in React)
            // library to make http requests from the application (in the system.net.http library)
            _httpClientFactory = httpClientFactory;

            //go grab from appsettings.json
            _firebaseApiKey = configuration.GetValue<string>("FirebaseApiKey");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        // See firebase documentation for more information
        //  https://firebase.google.com/docs/reference/rest/auth/#section-sign-in-email-password


        public async Task<FirebaseUser> Login(Credentials credentials)
        {
            var url = FIREBASE_SIGN_IN_BASE_URL + _firebaseApiKey;
            return await SignUpOrSignIn(credentials.Email, credentials.Password, url);
        }

  

        public async Task<FirebaseUser> Register(Registration registration)
        {
            var url = FIREBASE_SIGN_UP_BASE_URL + _firebaseApiKey;
            return await SignUpOrSignIn(registration.Email, registration.Password, url);
        }


        // used by both the Login and Register methods 
        private async Task<FirebaseUser> SignUpOrSignIn(string email, string password, string url)
        {
            // new instance of a FireBaseRequest
            var firebaseRequest = new FirebaseRequest(email, password);
            //url comes from the method call
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            //body of the message
            request.Content = new StringContent(
                //serialize to JSON
                JsonSerializer.Serialize(firebaseRequest, _jsonSerializerOptions),
                Encoding.UTF8,
                "application/json");

            var client = _httpClientFactory.CreateClient();

            //like a fetch call in React - just strongly typed
            // await is like .then() in React
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var firebaseResponse =
                JsonSerializer.Deserialize<FirebaseResponse>(content, _jsonSerializerOptions);

            return firebaseResponse.LocalId != null
                ? new FirebaseUser(firebaseResponse.Email, firebaseResponse.LocalId)
                : null;
        }
    }
}
