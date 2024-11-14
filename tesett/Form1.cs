using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace tesett
{
    public partial class Form1 : Form
    {

        static bool IsIsoFile(string filePath)
        {
            return Path.GetExtension(filePath).Equals(".iso", StringComparison.OrdinalIgnoreCase);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string iso = openFileDialog1.FileName;
            richTextBox1.Text = iso;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string disk = folderBrowserDialog1.SelectedPath;
            richTextBox2.Text = disk;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string iso = richTextBox1.Text;
            string Disk = richTextBox2.Text;
            if (!String.IsNullOrEmpty(iso) && !String.IsNullOrEmpty(Disk) && IsIsoFile(iso) && Path.GetFileName(Disk).Length == 0)
            {

         

                // Define the process and its start info
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "isoburn.exe"; // Path to isoburn.exe
                processInfo.Arguments = $"/Q {iso} {Disk}"; // Arguments to pass
                processInfo.RedirectStandardOutput = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;

                // Start the process and read the output
                using (Process process = Process.Start(processInfo))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
