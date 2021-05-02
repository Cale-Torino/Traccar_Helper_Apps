![Logo](https://cms.safe-tvigil.com/img/vigillogo/logosmwhite.png)

---

# Hex Traccar (SAFE-TVIGIL Hex Traccar)

*Developed by C.A Torino, SAFE-TVIGIL*
* Links to SAFE-TVIGIL(llc) USA.
    * [Website](https://safe-tvigil.com)
    * [CMS portal](https://cms.safe-tvigil.com)
    * [ELD portal](https://eld.safe-tvigil.com)
    * [F&Q](https://tickets.safe-tvigil.com)
    

### Setup

Use the HexConvertClass.cs ConvertHex(string hexString) methoud to convert the strings from **HEX** to **ANCII**.
Below is an example of the main element of this program:

```
    // HexConvertClass Allows us to input a HEX string and return ANCII.
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

    // Example of converting a single string.
    private void Convert_single()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox5.Clear();
                string _Converted = HexConvertClass.ConvertHex(textBox4.Text);
                textBox5.Text = _Converted;
                toolStripStatusLabel1.Text = "Converted Single String. Time: "+ DateTime.Now;
                Logger.WriteLine(" ***Converted Single String*** ");
                Logger.WriteLine("Un-Converted String:"+ textBox4.Text);
                Logger.WriteLine(" Converted String:"+ _Converted);
            }
            else
            {
                MessageBox.Show("The Textbox Can't Be Empty.", "Fill In Textbox!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Single Convert Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

```

**NOTE**

This app is written in **C#** but uses the ```sed.exe``` to process the regular expressions used in this application. 
The applications purpose is to make browsing and parsing ```Server.log``` files from the ```traccar``` server more efficient.
The application has been created with Windows Forms .NET Framework 4.7.2.

* Requirements are:
    * Visual studio (2019 is preferred but you can try 2015 or 2017).
    * Windows machine (this app is for windows clients).

### Required dll's

Place the following executable in the Applications root directory.

* sed.exe

### Development History

**Application version v1.0.0 (11-May-2020)**

Improving code and usability

* Form resized textboxes, groupboxes etc. are all anchored.
* **Temp** and **Logs** folders created in  the application root directory.
* ```LoggerClass.CS``` added to allow logging of all actions and events.
* ```SedClassV2.CS``` added removed unnecessary redundant code.

---

**Initial (10-May-2020)**

Researched old batch scripts and C++ Hex binary.

* C# application to improve on old batch scripts.
* Unfortunately sed.exe must still be used to deal with regular expressions.


* Design as follows:
    * Main form, about box form.
    * Save and Save As functionality.
    * Allow users to change the font of the memo.
    * OpenFileDialog function to choose ```Server.log``` file in whatever path it resides in.
    * OpenFileDialog saved to propertys.
    * Convert a single string from **HEX** to **ANCII** functionality.
    * Convert Bulk from **Hex** to **ANCII**.
    * Custom query added.
    * Certain Commands get their own button like ```+RESP:GTERI``` and ```+RESP:GTFSD``` for example.
    * Memo to show the output of each action.
    * Status strip, allowing us to display the progress of occuring events.

---
* Useful resources
    * [Traccar modern GPS tracking platform](https://www.traccar.org/).
    * [SED for windows](https://github.com/mbuilov/sed-windows).
    * [C# HEX to ASCII](https://stackoverflow.com/questions/5613279/c-sharp-hex-to-ascii).
    * [C# simple event logger](http://csharphelper.com/blog/2017/03/make-a-simple-event-logger-in-c/).


* Useful links
    * [view markdown files offline](https://stackoverflow.com/questions/9843609/view-markdown-files-offline).
    * [mastering markdown tutorial](https://guides.github.com/features/mastering-markdown/).
    * [markdown to pdf](https://www.markdowntopdf.com/).