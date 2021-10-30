using System.Collections.Generic;
using System.IO;

namespace Predictive_Solutions
{
    class Reader
    {
        public string ReadAllTxt(string pathToRead)
        {
            string text = "";

            using (FileStream fs = File.Open(pathToRead, FileMode.Open, FileAccess.Read)) 
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(fs))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }

        public IEnumerable<string> ReadFileByLine(string pathToRead)
        {
            using (StreamReader sr = new StreamReader(pathToRead))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    yield return line;
                    line = sr.ReadLine();
                }
            }
        }
    }
}
