using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Labb3_NET22.DataModels;

namespace Labb3_NET22
{
    public class FileManager
    {
        public static string Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SavedQuizes");

        public static async Task SaveQuiz(Quiz quiz)
        {
            Directory.CreateDirectory(Folder);
            string title = string.Join("_", quiz.Title.Split(Path.GetInvalidFileNameChars()));
            var path = Path.Combine(Folder, title + ".json");
            var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        public static List<string> GetTitle()
        {
            if(!Directory.Exists(Folder))
            {
                return new List<string>();
            }

            return Directory.GetFiles(Folder, "*.json")
                .Select(Path.GetFileNameWithoutExtension)
                .OrderBy(x => x)
                .ToList();
        }

        public static async Task<Quiz?> GetFiles(string title)
        {
            Directory.CreateDirectory(Folder);
            var filePath = Path.Combine(Folder, title + ".json");
            if(!File.Exists(filePath))
            {
                return null;
            }

            var json = await File.ReadAllTextAsync(filePath);
            Console.WriteLine(json);
            return JsonSerializer.Deserialize<Quiz>(json);

        }



    }
}
