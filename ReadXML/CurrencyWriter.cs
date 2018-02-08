using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ReadXML
{
    class CurrencyWriter
    {
        private string currentDate;
        private string currentLogDirectory;
        private string filePath;
        private int fileNo;
        private int logNo;

        public CurrencyWriter()
        {
            fileNo = 0;
            logNo = 1;
            currentDate = DateTime.Now.ToString("ddMMyy");
            currentLogDirectory = Directory.GetCurrentDirectory() + @"\CurrecyLog";
        }

        public void WriteToFile(List<string> lines, bool zipLogs)
        {
            try
            {
                setFilePath();
                System.IO.File.WriteAllLines(filePath , lines);
                if (zipLogs) ZipFile.CreateFromDirectory(currentLogDirectory, returnZipFilePath());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string returnZipFilePath()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\logArchive";
            while (File.Exists(filePath + logNo.ToString() + ".zip")) logNo++;
            return filePath + logNo + ".zip";
        }

        private void setFilePath()
        {
            if (currentDate == DateTime.Now.ToString("ddMMyy")) fileNo++;
            else
            {
                currentDate = DateTime.Now.ToString("ddMMyy");
                fileNo = 1;
            }
            while(File.Exists(currentLogDirectory + returnFileName() )) fileNo++;
            filePath = currentLogDirectory + returnFileName();
        }

        private string returnFileName()
        {
            return string.Format(@"\currencies{0}_{1}.txt", currentDate, fileNo);
        }
    }
}
