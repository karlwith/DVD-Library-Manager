using System;
using System.Collections;

namespace DVDLibraryManager
{
    class MovieCollection : iMovieCollection
    {
        // initialize MovieArray for movie objects
        public Hashtable MovieTable = new Hashtable();

        // get the number of movies in the community library
        public int Number{ get { return MovieTable.Count; } }

        //add a given movie to this tool collection
        public void add(iMovie aMovie)
        {
            if (MovieTable.ContainsKey(aMovie.Title))
            {
                (MovieTable[aMovie.Title] as Movie).AvailableCopies += 1;       // increase quantity if already in library
            }
            else
            {
                MovieTable.Add(aMovie.Title, (Movie)aMovie);                    // add movie object if not aready in library
                Console.WriteLine("\nMovie #{0} successfully added.", Number);  
            }
        }

        //delete a given movie from this movie collection
        public void delete(iMovie aMovie)
        {
            if (aMovie.AvailableCopies <= 1)
            {
                MovieTable.Remove(aMovie.Title);    // remove movie from library
            }
            else
            {
                aMovie.AvailableCopies -= 1;    // reduce available quantity from library
                aMovie.borrowCount += 1;    // increment borrowing counter
            }
        }

        //search a given movie in this movie collection. Return true if this movie is in the movie collection; return false otherwise
        public bool search(string title)
        {
            if (MovieTable.ContainsKey(title))
            {
                return true;
            }
            return false;
        }

        //output the movies in this collection to an array of iMovies
        public iMovie[] toArray()
        {
            iMovie[] MovieArray = new iMovie[MovieTable.Count];     // create array of correct size
            MovieTable.Keys.CopyTo(MovieArray, 0);
            return MovieArray;
        }
    }
}
