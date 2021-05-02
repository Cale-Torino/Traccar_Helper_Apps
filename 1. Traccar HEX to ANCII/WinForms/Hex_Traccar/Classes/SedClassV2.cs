using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Traccar.Classes
{
    class SedClassV2
    {
        public static void SedActions(string genArgs)
        {
            string pathToFile = @"C:\windows\system32\cmd.exe";
            Process runProg = new Process();
            try
            {
                runProg.StartInfo.FileName = pathToFile;
                runProg.StartInfo.Arguments = genArgs;
                runProg.StartInfo.CreateNoWindow = true;
                runProg.Start();
                runProg.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Could Not Complete: SED ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
