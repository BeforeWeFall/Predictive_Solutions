using System;
using System.IO;
using System.Threading.Tasks;

namespace Predictive_Solutions
{
    class WriteError
    {
        public void WriteAsync(string pathToFolder, string text, string description)
        {
            string pathToFile = pathToFolder + @"\Error.txt";
            CreateTxt(pathToFile);

            using (var sw = new StreamWriter(pathToFile, true))
            {
                 sw.WriteLine(text + " - " + description + Environment.NewLine);
            }
        }

        private void CreateTxt(string pathToFile)
        {
            if (!File.Exists(pathToFile))
                File.Create(pathToFile).Close();           
        }
    }
}
