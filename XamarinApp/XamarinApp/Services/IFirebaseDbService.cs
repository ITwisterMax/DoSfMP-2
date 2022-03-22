using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Firebase database for users and computers interfaces
    /// </summary>
    public interface IFirebaseDbService
    {
        /// <summary>
        ///     Add user info
        /// </summary>
        ///
        /// <param name="userInfo">User info</param>
        ///
        /// <returns>Task</returns>
        Task AddUserInfo(User userInfo);

        /// <summary>
        ///     Get all users
        /// </summary>
        ///
        /// <returns>List<User></returns>
        List<User> GetAllUsers();

        /// <summary>
        ///     Get current user
        /// </summary>
        ///
        /// <returns>User</returns>
        User GetCurrentUser();

        /// <summary>
        ///     Ban user by email
        /// </summary>
        ///
        /// <param name="email">Email</param>
        ///
        /// <returns>Task</returns>
        Task BanUser(string email);

        /// <summary>
        ///     Add a new computer
        /// </summary>
        ///
        /// <param name="computerInfo"></param>
        ///
        /// <returns>Task</returns>
        Task AddComputer(Computer computerInfo);

        /// <summary>
        ///     Get all computers
        /// </summary>
        ///
        /// <returns>List<Computer></returns>
        List<Computer> GetAllComputers();

        /// <summary>
        ///     Get computer by id
        /// </summary>
        ///
        /// <param name="id">Computer id</param>
        ///
        /// <returns>Computer</returns>
        Computer GetComputerById(string id);

        /// <summary>
        ///     Update computer info
        /// </summary>
        ///
        /// <param name="id">Computer id</param>
        /// <param name="computerInfo">Computer info</param>
        ///
        /// <returns>Task</returns>
        Task UpdateComputer(string id, Computer computerInfo);

        /// <summary>
        ///     Get coputers with current filters
        /// </summary>
        ///
        /// <returns>List<Computer></returns>
        List<Computer> GetComputersWithFilters();
    }
}