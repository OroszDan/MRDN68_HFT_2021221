using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public interface IMovieLogic
    {
        IEnumerable<KeyValuePair<string, int>> CountOfMoviesAfter2000ByDirectorNamesAndOrderedbyDirectorNames();
        void Create(Movie movie);
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        void Update(Movie movie);
        void Delete(int movieId);
    }
}
