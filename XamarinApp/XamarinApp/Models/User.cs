namespace XamarinApp.Models
{
    /// <summary>
    ///     Users container
    /// </summary>
    public class User
    {
        /// <summary>
        ///      Users characteristics
        /// </summary>
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
    }
}