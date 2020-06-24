using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegionsAreEvil.Classifications
{
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