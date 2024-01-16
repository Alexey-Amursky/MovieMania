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
            if (movie != null)
            {
                Process.Start(movie?.Path);
            }
        }
    }
}
