using System.IO;
using System.Threading.Tasks;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Firebase storage for images and video interface
    /// </summary>
    public interface IFirebaseStorageService
    {
        /// <summary>
        ///     Load image
        /// </summary>
        ///
        /// <param name="fileStream">File stream</param>
        /// <param name="fileName">File name</param>
        /// <param name="extension">File extension</param>
        ///
        /// <returns>Task<string></returns>
        Task<string> LoadImage(Stream fileStream, string fileName, string extension);

        /// <summary>
        ///     Load video
        /// </summary>
        ///
        /// <param name="fileStream">File stream</param>
        /// <param name="fileName">File name</param>
        /// <param name="extension">File extension</param>
        ///
        /// <returns>Task<string></returns>
        Task<string> LoadVideo(Stream fileStream, string fileName, string extension);

        /// <summary>
        ///     Remove image
        /// </summary>
        ///
        /// <param name="fileName">File name</param>
        ///
        /// <returns>Task</returns>
        Task RemoveImage(string fileName);

        /// <summary>
        ///     Remove video
        /// </summary>
        ///
        /// <param name="fileName">File name</param>
        ///
        /// <returns>Task</returns>
        Task RemoveVideo(string fileName);
    }
}