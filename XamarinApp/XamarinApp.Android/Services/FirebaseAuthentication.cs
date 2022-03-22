using System;
using System.Threading.Tasks;
using Firebase.Auth;
using XamarinApp.Services;

namespace XamarinApp.Droid.Services
{
    /// <summary>
    ///     Firebase authentication for users
    /// </summary>
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        /// <summary>
        ///     Register a new user
        /// </summary>
        ///
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        ///
        /// <returns>Task<bool></returns>
        public async Task<bool> RegisterWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var registrationResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Login user
        /// </summary>
        ///
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        ///
        /// <returns>Task<bool></returns>
        public async Task<bool> LoginWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                return IsSignIn();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Log out user
        /// </summary>
        ///
        /// <returns>bool</returns>
        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Check if user log in
        /// </summary>
        ///
        /// <returns>bool</returns>
        public bool IsSignIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;

            return user != null;
        }
    }
}