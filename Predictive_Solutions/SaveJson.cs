
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Predictive_Solutions
{
    class SaveJson
    {
        public async Task SaveAsync(string pathFolder, JsonInfo json)
        {
            string pathToSave = pathFolder + @"\Resul.json";
            using (FileStream createStream = File.Create(pathToSave))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };
                await JsonSerializer.SerializeAsync(createStream, json, options);
            }
        }
    }
}
