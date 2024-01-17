﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface IMovieEditor
    {
        void AddMovie(Movie movie);
        void DeleteMovie(int index);
    }
}
