using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Predictive_Solutions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string pathToRead = @""; // путь до входного файла
            string pathFolderToSave = @""; // путь к папке, где будут сохранены результаты обработки

            PrepareData prepareData = new PrepareData(pathToRead, pathFolderToSave);
            var listUser = prepareData.CreatingListUser();

            JsonInfo json = new JsonInfo(listUser);

            await new SaveJson().SaveAsync(pathFolderToSave, json);               
        }
    }
}
