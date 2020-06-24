using System;
using System.IO;

namespace BOAPlugins.HideSuccessCheck
{
    public static class Logger
    {
        #region Properties
        static string FilePath => Path.GetDirectoryName(typeof(Logger).Assembly.Location) + Path.DirectorySeparatorChar + "Logger.txt";
        #endregion

        #region Public Methods
        public static void Push(Exception exception)
        {
            try
            {
                var fs = new FileStream(FilePath, FileMode.Append);

                var sw = new StreamWriter(fs);
                sw.Write(exception.ToString());
                sw.Write(Environment.NewLine);
                sw.Close();
                fs.Close();
            }
            catch
            {
                // ignored
            }
        }
        #endregion
    }
}