using System.Threading.Tasks;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Firebase authentication for users interface
    /// </summary>
    public interface IFirebaseAuthentication
    {
        /// <summary>
        ///     Register a new user
        /// </summary>
        ///
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        ///
        /// <returns>Task<bool></returns>
        Task<bool> RegisterWithEmailAndPasswordAsync(string email, string password);

        /// <summary>
        ///     Login user
        /// </summary>
        ///
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        ///
        /// <returns>Task<bool></returns>
        Task<bool> LoginWithEmailAndPasswordAsync(string email, string password);

        /// <summary>
        ///     Log out user
        /// </summary>
        ///
        /// <returns>bool</returns>
        bool SignOut();

        /// <summary>
        ///     Check if user log in
        /// </summary>
        ///
        /// <returns>bool</returns>
        bool IsSignIn();
    }
}