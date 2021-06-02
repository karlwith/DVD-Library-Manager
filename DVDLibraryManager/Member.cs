using System;
using System.Collections;
using System.Collections.Generic;

namespace DVDLibraryManager
{
    class Member : iMember
    {
        // get and set the first name of this member
        public string FirstName { get; set; }

        // get and set the last name of this member
        public string LastName { get; set; }

        // get and set the contact number of this member
        public string ContactNumber { get; set; }

        // get and set the pin of this member
        public int Pin { get; set; }

        // Hashtable to hold movies currently borrowed
        public Hashtable BorrowedMovies = new Hashtable();

        //get a list of movies that this memebr is currently borrowing
        public List<string> getBorrowingMovieDVDs
        {
            get
            {
                List<string> borrowedMoviesTitles = new List<string>();     // create list to store hashtable keys in
                foreach (string movie in BorrowedMovies.Keys)
                {
                    borrowedMoviesTitles.Add(movie);
                }
                return borrowedMoviesTitles;    // return list
            }
        }

        //add a given movie DVD to the list of movies DVDs that this member is currently holding and remove from library collection
        public void addMovie(iMovie aMovie)
        {
            // check if already borrowed
            if (BorrowedMovies.ContainsKey(aMovie.Title))
            {
                Console.WriteLine("\nYou are already borrowing this movie.");
                return;
            }
            // add to borrowed list and remove from library
            else
            {
                BorrowedMovies.Add(aMovie.Title, (Movie)aMovie);    // add to customer object 
                (BorrowedMovies[aMovie.Title] as Movie).borrowCount += 1;  // increment borrowing counter
                Home.movieCollection.delete(aMovie);    // remove from library collection
                Console.WriteLine("\n{0} borrowed to user.", aMovie.Title);
            }
        }

        //delete a given movie DVD from the list of movie DVDs that this member is currently holding and add back to library collection
        public void deleteMovie(iMovie aMovie)
        {
            // check if already borrowed
            if (BorrowedMovies.ContainsKey(aMovie.Title))
            {
                Home.movieCollection.add(aMovie);  // add movie back to library collection
                BorrowedMovies.Remove(aMovie.Title);        // remove library from member object
                Console.WriteLine("\nMovie returned.");
                return;
            }
            // handle exception
            else
            {
                Console.WriteLine("\nMovie not currently borrowed");
            }
        }
    }
}
