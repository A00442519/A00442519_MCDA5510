using log4net;
using System;
using System.IO;
using System.Reflection;

namespace Assignment1
{



    public class Exceptions
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //static void Main()
        //{
        //     var sw = OpenStream(@".\sampleFile.csv");
        //    if (sw is null)
        //        return;
        //    sw.WriteLine("This is the first line.");
        //    sw.WriteLine("This is the second line.");
        //    sw.Close();
        //}

        static StreamWriter OpenStream(string path)
        {
            if (path is null)
            {
                log.Error("You did not supply a file path.");
                return null;
            }

            try
            {
                var fs = new FileStream(path, FileMode.CreateNew);
                return new StreamWriter(fs);
            }
            catch (FileNotFoundException)
            {
                log.Error("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                log.Error("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                log.Error("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                log.Error("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                log.Error("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                log.Error("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                log.Error("The file already exists.");
            }
            catch (IOException e)
            {
                log.Error($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }

    }




}
