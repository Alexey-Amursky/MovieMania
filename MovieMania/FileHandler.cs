using Filmography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filmography
{
    public class FileHandler : IFileHandler
    {
        public void SaveMovies(string filePath, List<Movie> movies)
        {
            string json = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, json);
        }

        public List<Movie> LoadMovies(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Movie>>(json);
            }
            else
            {
                return new List<Movie>();
            }
        }
    }
}
