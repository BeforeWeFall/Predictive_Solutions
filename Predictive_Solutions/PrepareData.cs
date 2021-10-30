using System;
using System.Collections.Generic;
using System.IO;

namespace Predictive_Solutions
{
    class PrepareData
    {
        public string PathToRead { get; set; }
        public string FolderToSave { get; set; }
        private CreatingUser cr ;
        private List<User> lUser ;
        private WriteError writeError;

        public PrepareData(string pathToRead, string folderToSave)
        {
            PathToRead = pathToRead;
            FolderToSave = folderToSave;
            cr = new CreatingUser();
            lUser = new List<User>();
            writeError = new WriteError();
        }

        public List<User> CreatingListUser()
        {
            if (new FileInfo(PathToRead).Length < 1)
            {
                var text = new Reader().ReadAllTxt(PathToRead).Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < text.Length - 1; i++)
                {
                    AddUser(text[i], i+1);
                }
            }
            else
            {
                int i = 0;
                foreach (var t in new Reader().ReadFileByLine(PathToRead))
                {
                    i++;
                    AddUser(t, i);
                }
            }
            return lUser;
        }

        private void AddUser(string text, int number)
        {
            try
            {
                lUser.Add(cr.Create(text, number));
            }
            catch(Exception ex)
            {
                writeError.WriteAsync(FolderToSave, text, ex.Message);
            }
        }
    }
}
