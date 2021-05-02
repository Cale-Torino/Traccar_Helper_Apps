using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Traccar
{
    //https://stackoverflow.com/questions/5613279/c-sharp-hex-to-ascii
    class HexConvertClass
    {
        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = Convert.ToUInt32(hs, 16);
                    char character = Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), "ConvertHex Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

    }
}
