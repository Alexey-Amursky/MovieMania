using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public static class Procedure
    {
        public static void RunMovie(Movie? movie)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\VideoLAN\VLC\vlc.exe",
                Arguments = movie?.Path
            };
            if (movie != null)
            {
                Process.Start(processInfo);
            }
        }
    }
}
