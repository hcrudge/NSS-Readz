namespace Readz.Auth.Models
{
    public class FirebaseUser
    {
        public string Email { get; }
        public string FirebaseUserId { get; }

        //Constructor
        public FirebaseUser(string email, string firebaseUserId)
        {
            Email = email;
            FirebaseUserId = firebaseUserId;
        }
    }
}
