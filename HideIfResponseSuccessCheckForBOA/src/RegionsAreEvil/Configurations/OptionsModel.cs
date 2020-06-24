namespace ___.RegionsAreEvil.Configurations
{
    /// <summary>
    ///     The options model
    /// </summary>
    public class OptionsModel
    {
        #region Fields
        /// <summary>
        ///     The minimize regions is enabled
        /// </summary>
        public bool MinimizeRegionsIsEnabled { get; set; }
        #endregion

        #region Public Properties
        /// <summary>
        ///     Gets or sets the active region opacity.
        /// </summary>
        public double ActiveRegionOpacity { get; set; } = 0.5;

        /// <summary>
        ///     Gets or sets the size of the active region.
        /// </summary>
        public int ActiveRegionSize { get; set; } = 10;

        /// <summary>
        ///     Gets or sets the in active region opacity.
        /// </summary>
        public double InActiveRegionOpacity { get; set; } = 0.5;

        /// <summary>
        ///     Gets or sets the size of the in active region.
        /// </summary>
        public int InActiveRegionSize { get; set; } = 10;
        #endregion
    }
}