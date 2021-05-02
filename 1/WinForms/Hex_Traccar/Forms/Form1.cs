using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Hex_Traccar.LoggerClass1;

namespace Hex_Traccar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Reallyexit()
        {
            //exit YES/NO
            string _text = "Do you really want to exit the application?";
            string _caption = "Exit Application?";
            var selectedOption = MessageBox.Show(_text, _caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (selectedOption == DialogResult.Yes)
            {
                try
                {
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exit Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return;
                }

            }
            else if (selectedOption == DialogResult.No)
            {
                //Do nothing
            }
        }
        private void CreateFolder()
        {
            try
            {
                //CreatFolder
                //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //Directory.CreateDirectory(path + "\\Hex_Traccar\\Logs");
                string path = Application.StartupPath;
                Directory.CreateDirectory(path + "\\Logs");
                Directory.CreateDirectory(path + "\\Temp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //load
            CreateFolder();
            textBox2.Text = "Please Select An Input Directory";
            Logger.WriteLine(" ***- APPLICATION STARTED -*** ");
            string path = Application.StartupPath + "\\Temp";
            DirectoryInfo di = new DirectoryInfo(path);
            if (Properties.Settings.Default.pathname != string.Empty)
            {
                textBox2.Text = Properties.Settings.Default.pathname;
            }
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit
            Logger.WriteLine(" ***Exit Clicked*** ");
            Reallyexit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //exit YES/NO
            Logger.WriteLine(" ***Exit Form Closing Clicked*** ");
            string _text = "Do you really want to exit the application?";
            string _caption = "Exit Application?";
            var selectedOption = MessageBox.Show(_text, _caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (selectedOption == DialogResult.Yes)
            {
                Logger.WriteLine(" ***Exiting Form...X *** ");
                //don't need to call Application.Exit(); because the form is already closing
            }
            else if (selectedOption == DialogResult.No)
            {
                //cancle closing
                Logger.WriteLine(" ***Cancel Exiting Form...X *** ");
                e.Cancel = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //font
            Logger.WriteLine(" ***Font Box Clicked*** ");
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = textBox1.Font = new Font(fontDialog1.Font, fontDialog1.Font.Style);
                textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //about
            Logger.WriteLine(" ***About Box Clicked*** ");
            Form f2 = new Form2();
            f2.ShowDialog();
        }

        string path = "";
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save
            Logger.WriteLine(" ***Save Clicked*** ");
            if (path != "")
            {
                File.WriteAllText(path, textBox1.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save as
            Logger.WriteLine(" ***Save As Clicked*** ");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(path = saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Copy All Clicked*** ");
            Clipboard.Clear();
            textBox1.SelectAll();
            textBox1.Copy();
        }

        private void cutAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Cut All Clicked*** ");
            Clipboard.Clear();
            textBox1.SelectAll();
            textBox1.Copy();
            textBox1.Clear();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Clear All Clicked*** ");
            Clipboard.Clear();
            textBox1.SelectAll();
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //input
             var dlg = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "Log Files(*.log)|*.log|Text Files(*.txt) | *.txt"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = Path.GetFullPath(path = dlg.FileName);
                Properties.Settings.Default.pathname = textBox2.Text;
                Properties.Settings.Default.Save();
                Logger.WriteLine(" ***Input File Chosen*** ");
                Logger.WriteLine(" Input File Chosen:" + textBox2.Text);
            }
        }
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
        private void button3_Click(object sender, EventArgs e)
        {
            Convert_single();
        }
        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Copy Selected Clicked*** ");
            Clipboard.Clear();
            try
            {
                Clipboard.SetText(textBox1.SelectedText);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" ***Copy Selected Error*** " + ex);
                return;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Copy Single String*** ");
            Logger.WriteLine(" Copy Single String:" + textBox5.Text);
            textBox5.SelectAll();
            textBox5.Copy();
        }

        private void ReadLines(string file)
        {
            backgroundWorker1.RunWorkerAsync(argument: file);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string file = (string)e.Argument;
                Invoke((MethodInvoker)(() => textBox1.Clear()));
                using (StreamReader sr = File.OpenText(file))
                {
                    foreach (string line in File.ReadAllLines(file))
                    {
                        string _line = HexConvertClass.ConvertHex(line);
                        Invoke((MethodInvoker)(() => textBox1.AppendText(_line + Environment.NewLine)));
                    }
                    File.WriteAllText("Temp\\Converted.log", textBox1.Text);
                }
                File.Delete("Temp\\Input.txt");
                ProgressC();
                MessageBox.Show("StreamReader Has Completed!", "StreamReader Has Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ProgressC();
                MessageBox.Show(ex.ToString(), "ReadLines StreamReader Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ConvertedLines(string file)
        {
            backgroundWorker2.RunWorkerAsync(argument: file);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)(() => textBox1.Clear()));
                string file = (string)e.Argument;
                using (StreamReader sr = File.OpenText(file))
                {
                    foreach (string line in File.ReadAllLines(file))
                    {
                        Invoke((MethodInvoker)(() => textBox1.AppendText(line + Environment.NewLine)));
                    }
                }
                ProgressC();
                MessageBox.Show("ConvertedLines Has Completed!", "ConvertedLines Has Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ProgressC();
                MessageBox.Show(ex.ToString(), "ConvertedLines StreamReader Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Please Select An Input Directory")
            {
                MessageBox.Show("Please Select An Input Directory", "Input Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Logger.WriteLine(" ***HEX to ANCII*** ");
                Logger.WriteLine(" HEX to ANCII Clicked");
                Progressw();
                Classes.SedClassV2.SedActions("/c SED -n /HEX:/p " + textBox2.Text + " > Temp\\processedA.temp");
                Classes.SedClassV2.SedActions("/c SED s/.*HEX// Temp\\processedA.temp > Temp\\processedB.temp");
                File.Delete("Temp\\processedA.temp");
                Classes.SedClassV2.SedActions("/c SED \"s/: /&\\n/g\" Temp\\processedB.temp > Temp\\processedC.temp");
                File.Delete("Temp\\processedB.temp");
                Classes.SedClassV2.SedActions("/c SED -i \"s/: /0A/g\" Temp\\processedC.temp");
                Classes.SedClassV2.SedActions("/c SED \"/0A/d\" Temp\\processedC.temp > Temp\\Input.txt");
                File.Delete("Temp\\processedC.temp");
                ReadLines("Temp\\Input.txt");
            }
        }

        private void Progressw()
        {
            Invoke((MethodInvoker)(() => toolStripProgressBar1.Value = 50));
            Invoke((MethodInvoker)(() => toolStripStatusLabel1.Text = "Working..."));
        }

        private void ProgressC()
        {
            Invoke((MethodInvoker)(() => toolStripProgressBar1.Value = 100));
            Invoke((MethodInvoker)(() => toolStripStatusLabel1.Text = "Completed Time: " + DateTime.Now));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" ***Clear Memo*** ");
            Logger.WriteLine(" Clear Clicked");
            textBox1.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTERI/p\" Temp\\Converted.log > Temp\\GTERI_Only.log");
            Logger.WriteLine(" ***+RESP:GTERI*** ");
            Logger.WriteLine(" +RESP:GTERI Clicked");
            ConvertedLines("Temp\\GTERI_Only.log");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTFSD/p\" Temp\\Converted.log > Temp\\GTFSD_Only.log");
            Logger.WriteLine(" ***+RESP:GTFSD*** ");
            Logger.WriteLine(" +RESP:GTFSD Clicked");
            ConvertedLines("Temp\\GTFSD_Only.log");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTFRI/p\" Temp\\Converted.log > Temp\\GTFRI_Only.log");
            Logger.WriteLine(" ***+RESP:GTFRI*** ");
            Logger.WriteLine(" +RESP:GTFRI Clicked");
            ConvertedLines("Temp\\GTFRI_Only.log");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTEPS/p\" Temp\\Converted.log > Temp\\GTEPS_Only.log");
            Logger.WriteLine(" ***+RESP:GTEPS*** ");
            Logger.WriteLine(" +RESP:GTEPS Clicked");
            ConvertedLines("Temp\\GTEPS_Only.log");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTINF/p\" Temp\\Converted.log > Temp\\GTINF_Only.log");
            Logger.WriteLine(" ***+RESP:GTINF*** ");
            Logger.WriteLine(" +RESP:GTINF Clicked");
            ConvertedLines("Temp\\GTINF_Only.log");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Progressw();
            Classes.SedClassV2.SedActions("/c SED -n \"/^+RESP:GTMPF/p\" Temp\\Converted.log > Temp\\GTMPF_Only.log");
            Logger.WriteLine(" ***+RESP:GTMPF*** ");
            Logger.WriteLine(" +RESP:GTMPF Clicked");
            ConvertedLines("Temp\\GTMPF_Only.log");
        }
        private void Custom_Query()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    string _query = textBox6.Text;
                    Classes.SedClassV2.SedActions("/c SED -n \"/^" + _query + "/p\" Temp\\Converted.log > Temp\\Custom_Only.log");
                    Logger.WriteLine(" ***Custom Query*** ");
                    Logger.WriteLine(" Custom Query:" + _query);
                    ConvertedLines("Temp\\Custom_Only.log");
                }
                else
                {
                    ProgressC();
                    MessageBox.Show("The Textbox Can't Be Empty.", "Fill In Textbox!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ProgressC();
                MessageBox.Show(ex.ToString(), "Custom Query Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Progressw();
            Custom_Query();
        }
    }
}
