namespace XamarinApp.Models
{
    /// <summary>
    ///     Computers container
    /// </summary>
    public class Computer
    {
        /// <summary>
        ///     Computers characteristics
        /// </summary>
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ProcessorGeneration { get; set; }

        public int ProcessorCores { get; set; }

        public int ProcessorThreads { get; set; }

        public int RamSize { get; set; }

        public int SsdSize { get; set; }

        public int HddSize { get; set; }

        public int PsuPower { get; set; }

        public float Price { get; set; }

        public CloudFileData Image { get; set; }

        public CloudFileData Video { get; set; }
    }
}