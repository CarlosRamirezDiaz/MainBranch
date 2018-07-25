using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace AmxColombia.Console.PurgeData
{
    public class Logger
    {
        private string fileName { get; set; }
        private string prefix { get; set; }

        private string _logDirectory = null;
        private string logDirectory
        {
            get
            {
                if (this._logDirectory == null)
                {
                    this._logDirectory = ConfigurationManager.AppSettings["LogDirectory"];
                    if (string.IsNullOrEmpty(this._logDirectory))
                        this._logDirectory = Environment.CurrentDirectory.ToString() + @"\Log";
                }
                return this._logDirectory;
            }
        }

        public Logger(string prefixo)
        {
            if (!Directory.Exists(this.logDirectory))
                Directory.CreateDirectory(this.logDirectory);

            this.prefix = prefixo;

            this.fileName = logDirectory + @"\" + prefixo + DateTime.Now.ToString("_yyyy-MM-dd HHmmss") + ".txt";

            if (!File.Exists(this.fileName))
            {
                File.CreateText(this.fileName).Close();
            }
        }

        public Logger(string fileName, bool deleteIfExists)
        {
            if (!Directory.Exists(this.logDirectory))
                Directory.CreateDirectory(this.logDirectory);

            this.fileName = this.logDirectory + @"\" + fileName + DateTime.Now.ToString("_yyyy-MM-dd HHmmss") + ".txt";

            if (!File.Exists(this.fileName))
            {
                File.CreateText(this.fileName).Close();
            }
            else if (deleteIfExists)
            {
                File.Delete(this.fileName);
                File.CreateText(this.fileName).Close();
            }
        }

        public void Write(string message, bool showMessageInConsole)
        {
            lock (this.fileName)
            {
                message = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] " + message;

                using (var sw = File.AppendText(this.fileName))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }

                if (showMessageInConsole)
                {
                    System.Console.WriteLine(message);
                }
            }
        }

        public void Purge(int days)
        {
            var pattern = DateTime.Now.AddDays((-1) * days).Date;
            var filesToRemove = System.IO.Directory.GetFiles(this.logDirectory, this.prefix + "*.txt");

            foreach (var item in filesToRemove)
            {
                var fileName = System.IO.Path.GetFileName(item);
                string sFileDate = fileName.Remove(0, this.prefix.Length + 1).Substring(0, 10);

                DateTime fileDate;
                if (DateTime.TryParse(sFileDate, out fileDate))
                {
                    if (fileDate.Date < pattern)
                    {
                        System.IO.File.Delete(item);
                        this.Write(string.Format("Deleted: {0}", fileName), true);
                    }
                }
            }
        }
    }
}

