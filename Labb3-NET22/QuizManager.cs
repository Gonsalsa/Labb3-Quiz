using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb3_NET22.DataModels;

namespace Labb3_NET22
{
    public static class QuizStorage
    {
        public static string appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Labb3-NET22");

        public static async Task SaveQuizAsJSONAsync(Quiz quiz, string fileNameWithoutExtension)
        {
            if (quiz == null) throw new ArgumentNullException(nameof(quiz));
            if (string.IsNullOrWhiteSpace(fileNameWithoutExtension))
                throw new ArgumentException("Namnet får inte vara tomt!", nameof(fileNameWithoutExtension));

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Labb3-NET22");

            Directory.CreateDirectory(folder);

            string filePath = Path.Combine(folder, fileNameWithoutExtension + ".json");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string json = JsonSerializer.Serialize(quiz, options);

            await File.WriteAllTextAsync(filePath, json).ConfigureAwait(false);
        }
    }
}
