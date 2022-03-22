namespace XamarinApp.Models
{
    /// <summary>
    ///     Filters container
    /// </summary>
    public static class Filters
    {
        /// <summary>
        ///     Is filters active
        /// </summary>
        public static bool isFilter = false;

        /// <summary>
        ///     Available filters
        /// </summary>
        public static int? ProcessorGenerationMin { get; set; } = null;
        public static int? ProcessorGenerationMax { get; set; } = null;
        public static int? ProcessorCoresMin { get; set; } = null;
        public static int? ProcessorCoresMax { get; set; } = null;
        public static int? ProcessorThreadsMin { get; set; } = null;
        public static int? ProcessorThreadsMax { get; set; } = null;
        public static int? RamSizeMin { get; set; } = null;
        public static int? RamSizeMax { get; set; } = null;
        public static int? SsdSizeMin { get; set; } = null;
        public static int? SsdSizeMax { get; set; } = null;
        public static int? HddSizeMin { get; set; } = null;
        public static int? HddSizeMax { get; set; } = null;
        public static int? PsuPowerMin { get; set; } = null;
        public static int? PsuPowerMax { get; set; } = null;
        public static float? PriceMin { get; set; } = null;
        public static float? PriceMax { get; set; } = null;
    }
}
