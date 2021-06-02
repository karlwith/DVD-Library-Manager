using System;

namespace DVDLibraryManager
{
    //The specification of Movie ADT
    interface iMovie
    {

        string Title // get and set the tile of this movie
        {
            get;
            set;
        }
        string Genre //get and set the genre of this movie
        {
            get;
            set;
        }

        string Classification //get and set the classification of this movie
        {
            get;
            set;
        }

        int Duration //get and set the duration of this movie
        {
            get;
            set;
        }

        int AvailableCopies //get and set the number of the copies of this movie currently available to lend
        {
            get;
            set;
        }

        int borrowCount //get and set the number of times that this movie has been borrowed
        {
            get;
            set;
        }
    }
}

