using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Storage;
using XamarinApp.Services;

namespace XamarinApp.Droid.Services
{
    /// <summary>
    ///     Firebase storage for images and video
    /// </summary>
    public class FirebaseStorageService : IFirebaseStorageService
    {
        /// <summary>
        ///     Firebase storage instance
        /// </summary>
        private readonly FirebaseStorage FirebaseStorage = new FirebaseStorage("URL");

        /// <summary>
        ///     Load image
        /// </summary>
        ///
        /// <param name="fileStream">File stream</param>
        /// <param name="fileName">File name</param>
        /// <param name="extension">File extension</param>
        ///
        /// <returns>Task<string></returns>
        public async Task<string> LoadImage(Stream fileStream, string fileName, string extension)
        {
            return await FirebaseStorage
                .Child("images")
                .Child($"{fileName}.{extension}")
                .PutAsync(fileStream, CancellationToken.None, "image/jpeg");
        }

        /// <summary>
        ///     Load video
        /// </summary>
        ///
        /// <param name="fileStream">File stream</param>
        /// <param name="fileName">File name</param>
        /// <param name="extension">File extension</param>
        ///
        /// <returns>Task<string></returns>
        public async Task<string> LoadVideo(Stream fileStream, string fileName, string extension)
        {
            return await FirebaseStorage
                .Child("videos")
                .Child($"{fileName}.{extension}")
                .PutAsync(fileStream, CancellationToken.None, "video/mp4");
        }

        /// <summary>
        ///     Remove image
        /// </summary>
        ///
        /// <param name="fileName">File name</param>
        ///
        /// <returns>Task</returns>
        public async Task RemoveImage(string fileName)
        {
            await FirebaseStorage
                .Child("images")
                .Child($"{fileName}.jpg")
                .DeleteAsync();
        }

        /// <summary>
        ///     Remove video
        /// </summary>
        ///
        /// <param name="fileName">File name</param>
        ///
        /// <returns>Task</returns>
        public async Task RemoveVideo(string fileName)
        {
            await FirebaseStorage
                .Child("videos")
                .Child($"{fileName}.mp4")
                .DeleteAsync();
        }
    }
}