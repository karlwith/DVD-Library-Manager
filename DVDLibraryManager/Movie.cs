using System;

namespace DVDLibraryManager
{
    class Movie : iMovie
    {
        // get and set the tile of this movie
        public string Title { get; set; }

        //get and set the genre of this movie
        public string Genre { get; set; }

        //get and set the classification of this movie
        public string Classification { get; set; }

        //get and set the duration of this movie
        public int Duration { get; set; }

        //get and set the number of the copies of this movie currently available to lend
        public int AvailableCopies { get; set; }

        //get and set the number of times that this movie has been borrowed
        public int borrowCount { get; set; }
    }
}
