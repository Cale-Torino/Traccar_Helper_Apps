using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Traccar
{
    //http://csharphelper.com/blog/2017/03/make-a-simple-event-logger-in-c/
    //https://stackoverflow.com/questions/10242061/c-sharp-best-method-to-create-a-log-file
    class LoggerClass1
    {
        public static class Logger
        {
            //private static string LogFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Hex_Traccar\\Logs\\Hex_Traccar_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";
            private static string LogFile = Application.StartupPath + "\\Logs\\Hex_Traccar_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";

            public static void WriteLine(string txt)
            {
                try
                {
                    File.AppendAllText(LogFile, "[" + DateTime.Now.ToString() + "] : " + txt + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could Not Append Text To Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            public static void DeleteLog()
            {
                try
                {
                    File.Delete(LogFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could Not Delete Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
