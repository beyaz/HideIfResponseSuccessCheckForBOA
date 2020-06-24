using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegionsAreEvil.Classifications
{
    /// <summary>
    ///     The options
    /// </summary>
    public static class Options
    {
        #region Static Fields
        /// <summary>
        ///     The active region opacity
        /// </summary>
        public static double ActiveRegionOpacity = 0.5;

        /// <summary>
        ///     The active region size
        /// </summary>
        public static int ActiveRegionSize = 10;

        /// <summary>
        ///     The in active region opacity
        /// </summary>
        public static double InActiveRegionOpacity = 0.5;

        /// <summary>
        ///     The in active region size
        /// </summary>
        public static int InActiveRegionSize = 10;

        /// <summary>
        ///     The is read from file
        /// </summary>
        public static bool IsReadFromFile;

        /// <summary>
        ///     The minimize regions is enabled
        /// </summary>
        public static bool MinimizeRegionsIsEnabled;
        #endregion

        #region Constructors
        /// <summary>
        ///     Initializes the <see cref="Options" /> class.
        /// </summary>
        static Options()
        {
            if (File.Exists(OptionFilePath))
            {
                var lines = File.ReadAllText(OptionFilePath).Split(Environment.NewLine.ToCharArray()).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();

                MinimizeRegionsIsEnabled = bool.Parse(GetValue(lines, "MinimizeRegionsIsEnabled:"));

                InActiveRegionSize    = int.Parse(GetValue(lines, "InActiveRegionSize:"));
                InActiveRegionOpacity = double.Parse(GetValue(lines, "InActiveRegionOpacity:"));

                ActiveRegionSize    = int.Parse(GetValue(lines, "ActiveRegionSize:"));
                ActiveRegionOpacity = double.Parse(GetValue(lines, "ActiveRegionOpacity:"));

                IsReadFromFile = true;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the option file path.
        /// </summary>
        static string OptionFilePath => Path.GetDirectoryName(typeof(Options).Assembly.Location) + Path.DirectorySeparatorChar + "HideIfResponseSuccessCheckForBOA.Options.txt";
        #endregion

        #region Methods
        /// <summary>
        ///     Gets the value.
        /// </summary>
        static string GetValue(IEnumerable<string> lines, string key)
        {
            return lines.FirstOrDefault(x => x.StartsWith(key))?.Substring(key.Length);
        }
        #endregion
    }

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

    /// <summary>
    ///     The options reader
    /// </summary>
    public class OptionsReader
    {
        #region Properties
        /// <summary>
        ///     Gets the option file path.
        /// </summary>
        string OptionFilePath => Path.GetDirectoryName(typeof(OptionsReader).Assembly.Location) + Path.DirectorySeparatorChar + "HideIfResponseSuccessCheckForBOA.Options.txt";
        #endregion

        #region Public Methods
        /// <summary>
        ///     Reads from file.
        /// </summary>
        public OptionsModel ReadFromFile(string filePath)
        {
            var lines = File.ReadAllText(filePath).Split(Environment.NewLine.ToCharArray()).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();

            return new OptionsModel
            {
                MinimizeRegionsIsEnabled = bool.Parse(GetValue(lines, "MinimizeRegionsIsEnabled:")),

                InActiveRegionSize    = int.Parse(GetValue(lines, "InActiveRegionSize:")),
                InActiveRegionOpacity = double.Parse(GetValue(lines, "InActiveRegionOpacity:")),

                ActiveRegionSize    = int.Parse(GetValue(lines, "ActiveRegionSize:")),
                ActiveRegionOpacity = double.Parse(GetValue(lines, "ActiveRegionOpacity:"))
            };
        }

        /// <summary>
        ///     Tries the read from file.
        /// </summary>
        public OptionsModel TryReadFromFile()
        {
            if (File.Exists(OptionFilePath))
            {
                return ReadFromFile(OptionFilePath);
            }

            return null;
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Gets the value.
        /// </summary>
        static string GetValue(IEnumerable<string> lines, string key)
        {
            return lines.FirstOrDefault(x => x.StartsWith(key))?.Substring(key.Length);
        }
        #endregion
    }
}