using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface IFileHandler
    {
        List<Movie> LoadMovies(string filePath);
        void SaveMovies(string filePath, List<Movie> movies);
    }
}
