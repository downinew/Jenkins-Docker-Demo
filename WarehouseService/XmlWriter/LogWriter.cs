using System;
using System.IO;

namespace Tools
{

    public class LogWriter
    {

        static string BaseDir = @"D:\Bitbucket\WarehouseService\LogFiles\";

        public static void WriteLog(string message)
        {
            try
            {
                string filename = BaseDir
                + GetFilenameYYYMMDD("_Demo", ".log");
                using (StreamWriter sw = File.AppendText(filename))
                {
                    string logEntry = $"[{DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm:ss")}] {message}";
                    sw.WriteLine(logEntry);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        private static string GetFilenameYYYMMDD(string suffix, string extension)
        {
            return DateTime.Now.ToString(@"MMddyyyy") + suffix + extension;
        }

    }

}
