using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.Droid.Services
{
    /// <summary>
    ///     Firebase database for users and computers
    /// </summary>
    public class FirebaseDbService : IFirebaseDbService
    {
        /// <summary>
        ///     Database client instance
        /// </summary>
        private readonly FirebaseClient DatabaseClient = 
            new FirebaseClient("URL");

        /// <summary>
        ///     Add user info
        /// </summary>
        ///
        /// <param name="userInfo">User info</param>
        ///
        /// <returns>Task</returns>
        public async Task AddUserInfo(User userInfo)
        {
            await DatabaseClient
                .Child("Users")
                .PostAsync(userInfo);
        }

        /// <summary>
        ///     Get all users
        /// </summary>
        ///
        /// <returns>List<User></returns>
        public List<User> GetAllUsers()
        {
            var taskGetAllUsers = DatabaseClient
                .Child("Users")
                .OnceAsync<User>();

            taskGetAllUsers.Wait();

            if (taskGetAllUsers.Exception != null)
            {
                Console.WriteLine(taskGetAllUsers.Exception.Message);
                return null;
            }

            IEnumerable<FirebaseObject<User>> resultUsers = taskGetAllUsers.Result;

            return resultUsers.Select(item => new User
            {
                Email = item.Object.Email,
                IsAdmin = item.Object.IsAdmin,
                IsBlocked = item.Object.IsBlocked
            }).ToList();
        }

        /// <summary>
        ///     Get current user
        /// </summary>
        ///
        /// <returns>User</returns>
        public User GetCurrentUser()
        {
            string currentUserEmail = FirebaseAuth.Instance.CurrentUser.Email;

            var taskGetAllUsers = DatabaseClient
                .Child("Users")
                .OnceAsync<User>();

            taskGetAllUsers.Wait();

            if (taskGetAllUsers.Exception != null)
            {
                Console.WriteLine(taskGetAllUsers.Exception.Message);
                return null;
            }

            IEnumerable<FirebaseObject<User>> resultUsers = taskGetAllUsers.Result;

            return resultUsers.Select(item => new User
            {
                Email = item.Object.Email,
                IsAdmin = item.Object.IsAdmin,
                IsBlocked = item.Object.IsBlocked
            }).First(u => u.Email == currentUserEmail);
        }

        /// <summary>
        ///     Ban user by email
        /// </summary>
        ///
        /// <param name="email">Email</param>
        ///
        /// <returns>Task</returns>
        public async Task BanUser(string email)
        {
            var userToBan = (await DatabaseClient
                .Child("Users")
                .OnceAsync<User>()).FirstOrDefault(u => u.Object.Email == email);

            var newUser = new User
            {
                Email = email,
                IsAdmin = false,
                IsBlocked = true
            };

            await DatabaseClient
                .Child("Users")
                .Child(userToBan?.Key)
                .PutAsync(newUser);
        }

        /// <summary>
        ///     Add a new computer
        /// </summary>
        ///
        /// <param name="computerInfo"></param>
        ///
        /// <returns>Task</returns>
        public async Task AddComputer(Computer computerInfo)
        {
            await DatabaseClient
                .Child("Computers")
                .PostAsync(computerInfo);
        }

        /// <summary>
        ///     Get all computers
        /// </summary>
        ///
        /// <returns>List<Computer></returns>
        public List<Computer> GetAllComputers()
        {
            var taskGetAllComputers = DatabaseClient
                .Child("Computers")
                .OnceAsync<Computer>();

            taskGetAllComputers.Wait();

            if (taskGetAllComputers.Exception != null)
            {
                Console.WriteLine(taskGetAllComputers.Exception.Message);
                return null;
            }

            IEnumerable<FirebaseObject<Computer>> resultComputers = taskGetAllComputers.Result;

            return resultComputers.Select(item => new Computer
            {
                Id = item.Object.Id,
                Name = item.Object.Name,
                Description = item.Object.Description,
                ProcessorGeneration = item.Object.ProcessorGeneration,
                ProcessorCores = item.Object.ProcessorCores,
                ProcessorThreads = item.Object.ProcessorThreads,
                RamSize = item.Object.RamSize,
                SsdSize = item.Object.SsdSize,
                HddSize = item.Object.HddSize,
                PsuPower = item.Object.PsuPower,
                Price = item.Object.Price,
                Image = new CloudFileData
                {
                    FileName = item.Object.Image?.FileName ?? "",
                    DownloadUrl = item.Object.Image?.DownloadUrl ?? "https://www.generationsforpeace.org/wp-content/uploads/2018/03/empty.jpg"
                },
                Video = new CloudFileData
                {
                    FileName = item.Object.Video?.FileName ?? "",
                    DownloadUrl = item.Object.Video?.DownloadUrl ?? ""
                }
            }).ToList();
        }

        /// <summary>
        ///     Get computer by id
        /// </summary>
        ///
        /// <param name="id">Computer id</param>
        ///
        /// <returns>Computer</returns>
        public Computer GetComputerById(string id)
        {
            var taskGetAllComputers = DatabaseClient
                .Child("Computers")
                .OnceAsync<Computer>();

            taskGetAllComputers.Wait();

            if (taskGetAllComputers.Exception != null)
            {
                Console.WriteLine(taskGetAllComputers.Exception.Message);
                return null;
            }

            IEnumerable<FirebaseObject<Computer>> resultComputers = taskGetAllComputers.Result;

            return resultComputers.Where(c => c.Object.Id == id).Select(item => new Computer
            {
                Id = item.Object.Id,
                Name = item.Object.Name,
                Description = item.Object.Description,
                ProcessorGeneration = item.Object.ProcessorGeneration,
                ProcessorCores = item.Object.ProcessorCores,
                ProcessorThreads = item.Object.ProcessorThreads,
                RamSize = item.Object.RamSize,
                SsdSize = item.Object.SsdSize,
                HddSize = item.Object.HddSize,
                PsuPower = item.Object.PsuPower,
                Price = item.Object.Price,
                Image = new CloudFileData
                {
                    FileName = item.Object.Image?.FileName ?? "",
                    DownloadUrl = item.Object.Image?.DownloadUrl ?? "https://www.generationsforpeace.org/wp-content/uploads/2018/03/empty.jpg"
                },
                Video = new CloudFileData
                {
                    FileName = item.Object.Video?.FileName ?? "",
                    DownloadUrl = item.Object.Video?.DownloadUrl ?? ""
                }
            }).FirstOrDefault();
        }

        /// <summary>
        ///     Update computer info
        /// </summary>
        ///
        /// <param name="id">Computer id</param>
        /// <param name="computerInfo">Computer info</param>
        ///
        /// <returns>Task</returns>
        public async Task UpdateComputer(string id, Computer computerInfo)
        {
            var toUpdateComputer = (await DatabaseClient
                .Child("Computers")
                .OnceAsync<Computer>()).FirstOrDefault(c => c.Object.Id == id);

            await DatabaseClient
                .Child("Computers")
                .Child(toUpdateComputer?.Key)
                .PutAsync(computerInfo);
        }

        /// <summary>
        ///     Get coputers with current filters
        /// </summary>
        ///
        /// <returns>List<Computer></returns>
        public List<Computer> GetComputersWithFilters()
        {
            var taskGetAllComputers = DatabaseClient
                .Child("Computers")
                .OnceAsync<Computer>();

            taskGetAllComputers.Wait();

            if (taskGetAllComputers.Exception != null)
            {
                Console.WriteLine(taskGetAllComputers.Exception.Message);
                return null;
            }

            IEnumerable<FirebaseObject<Computer>> resultComputers = taskGetAllComputers.Result;

            return resultComputers.Where(c => 
                (Filters.ProcessorGenerationMin != null ? c.Object.ProcessorGeneration >= Filters.ProcessorGenerationMin : true) &&
                (Filters.ProcessorGenerationMax != null ? c.Object.ProcessorGeneration <= Filters.ProcessorGenerationMax : true) &&
                (Filters.ProcessorCoresMin != null ? c.Object.ProcessorCores >= Filters.ProcessorCoresMin : true) &&
                (Filters.ProcessorCoresMax != null ? c.Object.ProcessorCores <= Filters.ProcessorCoresMax : true) &&
                (Filters.ProcessorThreadsMin != null ? c.Object.ProcessorThreads >= Filters.ProcessorThreadsMin : true) &&
                (Filters.ProcessorThreadsMax != null ? c.Object.ProcessorThreads <= Filters.ProcessorThreadsMax : true) &&
                (Filters.RamSizeMin != null ? c.Object.RamSize >= Filters.RamSizeMin : true) &&
                (Filters.RamSizeMax != null ? c.Object.RamSize <= Filters.RamSizeMax : true) &&
                (Filters.SsdSizeMin != null ? c.Object.SsdSize >= Filters.SsdSizeMin : true) &&
                (Filters.SsdSizeMax != null ? c.Object.SsdSize <= Filters.SsdSizeMax : true) &&
                (Filters.HddSizeMin != null ? c.Object.HddSize >= Filters.HddSizeMin : true) &&
                (Filters.HddSizeMax != null ? c.Object.HddSize <= Filters.HddSizeMax : true) &&
                (Filters.PsuPowerMin != null ? c.Object.PsuPower >= Filters.PsuPowerMin : true) &&
                (Filters.PsuPowerMax != null ? c.Object.PsuPower <= Filters.PsuPowerMax : true) &&
                (Filters.PriceMin != null ? c.Object.Price >= Filters.PriceMin : true) &&
                (Filters.PriceMax != null ? c.Object.Price <= Filters.PriceMax : true)
            ).Select(item => new Computer {
                Id = item.Object.Id,
                Name = item.Object.Name,
                Description = item.Object.Description,
                ProcessorGeneration = item.Object.ProcessorGeneration,
                ProcessorCores = item.Object.ProcessorCores,
                ProcessorThreads = item.Object.ProcessorThreads,
                RamSize = item.Object.RamSize,
                SsdSize = item.Object.SsdSize,
                HddSize = item.Object.HddSize,
                PsuPower = item.Object.PsuPower,
                Price = item.Object.Price,
                Image = new CloudFileData
                {
                    FileName = item.Object.Image?.FileName ?? "",
                    DownloadUrl = item.Object.Image?.DownloadUrl ?? "https://www.generationsforpeace.org/wp-content/uploads/2018/03/empty.jpg"
                },
                Video = new CloudFileData
                {
                    FileName = item.Object.Video?.FileName ?? "",
                    DownloadUrl = item.Object.Video?.DownloadUrl ?? ""
                }
            }).ToList();
        }
    }
}