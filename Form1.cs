using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shell32;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
 
        

namespace WTVConverter
{

    public partial class Form1 : Form
    {


        public  bool GetDuration(String filename, out TimeSpan duration)
        {
            try
            {
                var shl = new Shell();
                var fldr = shl.NameSpace(Path.GetDirectoryName(filename));
                var itm = fldr.ParseName(Path.GetFileName(filename));

                // Index 27 is the video duration [This may not always be the case]
                var propValue = fldr.GetDetailsOf(itm, 27);

                return TimeSpan.TryParse(propValue, out duration);
            }
            catch (Exception)
            {
                duration = new TimeSpan();
                return false;
            }
        }


        Dictionary<String, double> fileDurations = new Dictionary<string, double>();
        Dictionary<String, double> fail = new Dictionary<string, double>();
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> getStartupProperties()
        {
            var data = new Dictionary<string, string>();
            try
            {
                foreach (var row in File.ReadAllLines("config.prop"))
                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            }
            catch
            {
                //mostlikely file does not exist empty data :( TODO:: fix bad design
            }
            return data;
        }
        private void saveStartupProperties(Dictionary<string, string> prop)
        {
            var fStream= new System.IO.StreamWriter("config.prop");
            try
            {
                foreach (var item in prop)
                {
                    fStream.WriteLine(item.Key + "=" + item.Value);
                }
            }
            catch(Exception e)
            {
                listBox1.Items.Insert(0, "Error while saving: "+e.ToString());
            }
            finally
            {
                fStream.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var data = getStartupProperties();
            String fromTextTmp;
            data.TryGetValue("fromText", out fromTextTmp);
            fromText.Text = fromTextTmp;
            String toTextTmp;
            data.TryGetValue("toText", out toTextTmp);
            toText.Text = toTextTmp;
            String errorTextTmp;
            data.TryGetValue("errorText", out errorTextTmp);
            backupText.Text = errorTextTmp;
            String autoStartupTmp;
            data.TryGetValue("autoStartup", out autoStartupTmp);
            if (autoStartupTmp!=null && autoStartupTmp.Equals("true"))
            {
                autostartupChk.Checked = true;
            }
            else
            {
                autostartupChk.Checked = false;
            }
            if (autostartupChk.Checked)
            {
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] files=Directory.GetFiles(fromText.Text);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".wtv", true, null))
                {
                    
                    double min=getTime(files[i]);
                    try
                    {
                        if (fileDurations.ContainsKey(files[i]) && !fail.ContainsKey(files[i]) && min == fileDurations[files[i]] && min != 0
                            && !File.Exists("" + toText.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".dvr-ms")
                            && !File.Exists("" + fromText.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".dvr-ms"))
                        {
                            try
                            {
                                convertFile(files[i]);
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " was converted");
                                
                            }
                            catch
                            {
                                fail.Add(files[i],1);
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " has errors while converting");
                            }
                            /*try
                            {
                                moveToBackup(files[i]);
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " was moved to backup");
                            }
                            catch
                            {
                                fail.Add(files[i], 1);
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " has errors while moving");
                            }*/
                            
                            fileDurations.Remove(files[i]);
                        }
                        else if (File.Exists("" + fromText.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".dvr-ms"))
                        {
                            try
                            {
                                deleteFile(files[i]);
                            }
                            catch
                            {
                                fail.Add(files[i], 1);
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " unable to delete");
                            }
                        }
                        else
                        {
                            fileDurations.Remove(files[i]);
                            fileDurations.Add(files[i], min);
                            if (File.Exists("" + toText.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".dvr-ms"))
                            {
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " is waiting for comskip " + min + " min");
                            }
                            else if (File.Exists("" + fromText.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".dvr-ms"))
                            {
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " is waiting to be deleted " + min + " min");
                            }
                            else
                            {
                                listBox1.Items.Insert(0, "File " + Path.GetFileName(files[i]) + " has duration of " + min + " min");
                            }
                        }
                    }
                    catch
                    {
                        
                        listBox1.Items.Insert(0,"File " + Path.GetFileName(files[i]) + " error at 0x000104");
                    }
                }
                
            }
        }

        private void moveToBackup(string p)
        {
            File.Move(p, backupText.Text + "\\" + Path.GetFileName(p));
        }
        private void deleteFile(string p)
        {
            File.Delete(p);
        }
        private void convertFile(string p)
        {
            Process wtv = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //wtv.StartInfo.CreateNoWindow = false;
            //wtv.StartInfo.UseShellExecute = false;
            //startInfo.WorkingDirectory="C:\\Windows\\ehome\\";
            wtv.StartInfo.FileName = "C:\\Windows\\ehome\\WTVConverter.exe";
            //wtv.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            wtv.StartInfo.Arguments = "\"" + p + "\" \"" + toText.Text + "\\"+Path.GetFileNameWithoutExtension(p)+".dvr-ms\"";
            wtv.StartInfo.RedirectStandardError = true;
            wtv.StartInfo.RedirectStandardInput = true;
            wtv.StartInfo.RedirectStandardOutput = true;
            wtv.StartInfo.UseShellExecute = false;
            try
            {
                wtv.Start();
                listBox1.Items.Insert(0, "File " + Path.GetFileName(p) + " convert started");
                wtv.WaitForExit(12000000);
                String errorMsg=wtv.StandardError.ReadToEnd();
                
                if (!wtv.HasExited)
                {
                    wtv.Kill();
                    moveToBackup(p);
                }
                if (errorMsg != "")
                {
                    listBox1.Items.Insert(0, "File " + Path.GetFileName(p) + " has error " + wtv.StandardError.ReadToEnd());
                    moveToBackup(p);
                }
                if(!File.Exists("" + toText.Text + "\\"+Path.GetFileNameWithoutExtension(p)+".dvr-ms")){
                    throw new Exception("Something bad happened.. " + "\"" + toText.Text + "\\" + Path.GetFileNameWithoutExtension(p) + ".dvr-ms\"");
                }
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                /*using (Process exeProcess = Process.Start(startInfo))
                {
                    listBox1.Items.Insert(0, "File " + Path.GetFileName(p) + " convert started");
                    exeProcess.WaitForExit();
                    listBox1.Items.Insert(0, "File " + Path.GetFileName(p) + " has error " + exeProcess.StandardError.ReadToEnd());
                }*/
            }
            catch(Exception e)
            {
                listBox1.Items.Insert(0, "File " + Path.GetFileName(p) + " convert error: "+ e.ToString());
                throw e;
                // Log error.
            }
        }
        public double getTime(String file)
        {
            try
            {
                TimeSpan ts = new TimeSpan();
                GetDuration(file, out ts);
                return ts.TotalMinutes;
            }
            catch
            {
                return 0;
            }
           // return 0;
        }

        public static double Convert100NanosecondsToMilliseconds(double nanoseconds)
        {
            // One million nanoseconds in 1 millisecond, 
            // but we are passing in 100ns units...
            return nanoseconds * 0.0001;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1_Click(sender, e);
            //cleanup listbox1
            if (listBox1.Items.Count > 5000)
            {
                for(int i =4000; i<listBox1.Items.Count; i++){
                    listBox1.Items.RemoveAt(i);
                }
            }
            timer1.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                fromText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void toButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                toText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                backupText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            if (optionsPnl.Visible == false)
            {
                this.Height = this.Height + optionsPnl.Height;
                optionsPnl.Visible = true;
            }
            else
            {
                this.Height = this.Height - optionsPnl.Height;
                optionsPnl.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveOptnsBtn_Click(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>();
            data.Add("fromText", fromText.Text);
            data.Add("toText", toText.Text);
            data.Add("errorText", backupText.Text);
            String autoStartupTmp=autostartupChk.Checked==true?"true":"false";
            data.Add("autoStartup", autoStartupTmp);
            saveStartupProperties(data);
            if (autostartupChk.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

    }
}
