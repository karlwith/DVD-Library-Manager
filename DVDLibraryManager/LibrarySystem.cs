using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DVDLibraryManager
{
    class LibrarySystem : ToolLibrarySystem
    {
        // add a copy of existing movie to movie collection
        public void addExistingMovie()
        {
            // find title and check if movie already exists
            Console.WriteLine("\nEnter the name of the movie to increase in quantity ==>");
            string title = Console.ReadLine();
            if (!Home.movieCollection.MovieTable.ContainsKey(title))
            {
                Console.WriteLine("Movie does not already exist in the system. Please create the movie first.");
                return;
            }
            // parse number of copies to be added
            bool valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter how many copies are to be added to the system ==>");
                string copiesString = Console.ReadLine();
                int copies;
                valueFound = Int32.TryParse(copiesString, out copies);
                if (!valueFound)
                {
                    Console.WriteLine("Wrong input detected, try again.");
                }
                else
                {
                    (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies += copies;    // increase AvailableCopies for movie object by the amount specified by the user
                    Console.WriteLine("\n{0} copies of {1} added to the system, giving a total of {2}.", copies, title, (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies);     // display output
                    valueFound = true;
                }
            }
        }

        // add a new member to the member collection
        public void addMember()
        {
            Member tempMember = new Member();

            // find contact number and check for duplicate
            Console.WriteLine("\nEnter the contact number of the new member ==>");
            tempMember.ContactNumber = Console.ReadLine();
            if (Home.memberCollection.search(tempMember.ContactNumber))
            {
                Console.WriteLine("Member is already registered");
                return;
            }

            // find name of the member
            Console.WriteLine("\nEnter the first name of the new member ==>");
            tempMember.FirstName = Console.ReadLine();
            Console.WriteLine("\nEnter the last name of the new member ==>");
            tempMember.LastName = Console.ReadLine();

            // parse pin of the member
            bool valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter the 4 digit pin of the new member ==>");
                string PinString = Console.ReadLine();
                int pin;
                if (PinString.Length == 4)   // impose length limit to 4
                {
                    valueFound = Int32.TryParse(PinString, out pin);
                    if (valueFound) tempMember.Pin = pin;
                }
                if (!valueFound)
                {
                    Console.WriteLine("Wrong input detected, try again.");
                }
            }
            Home.memberCollection.add(tempMember);
        }

        // add a new movie to the movie collection
        public void addNewMovie()
        {
            Movie tempMovie = new Movie();

            // parse title
            Console.WriteLine("\nEnter the title of the new movie ==>");
            tempMovie.Title = Console.ReadLine();
            if (Home.movieCollection.search(tempMovie.Title))
            {
                Console.WriteLine("Movie is already registered");
                return;
            }

            // parse classification to be G, PG, M15+ or MA15+
            bool valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter the classification of the new movie out of G, PG, M15+ or MA15+ ==>");
                tempMovie.Classification = Console.ReadLine();
                if (tempMovie.Classification == "G" || tempMovie.Classification == "PG" || tempMovie.Classification == "M15+" || tempMovie.Classification == "MA15+")
                {
                    valueFound = true;
                }
                else
                {
                    Console.WriteLine("\nIncorrect input detected.");
                }
            }

            // parse genre to be Drama, Adventure, Family, Action, Sci-Fi, Comedy, Animated, Thriller, or Other
            valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter the genre out of Drama, Adventure, Family, Action, Sci-Fi, Comedy, Animated, Thriller, or Other ==>");
                tempMovie.Genre = Console.ReadLine();
                if (tempMovie.Genre == "Drama" || tempMovie.Genre == "Adventure" || tempMovie.Genre == "Family" || tempMovie.Genre == "Action" || tempMovie.Genre == "Sci-Fi" || tempMovie.Genre == "Comedy" || tempMovie.Genre == "Animated" || tempMovie.Genre == "Thriller" || tempMovie.Genre == "Other")
                {
                    valueFound = true;
                }
                else
                {
                    tempMovie.Genre = "Other";
                    Console.WriteLine("\nGenre unknown, set to 'Other'.");
                    valueFound = true;
                }
            }

            // parse duration of the movie
            valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter the duration of the movie as a whole number of minutes ==>");
                string durationString = Console.ReadLine();
                int duration;
                valueFound = Int32.TryParse(durationString, out duration);
                if (!valueFound)
                {
                    Console.WriteLine("Wrong input detected, try again.");
                }
                else
                {
                    tempMovie.Duration = duration;
                    valueFound = true;
                }
            }

            // parse number of copies to be added
            valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter how many copies are to be added to the system ==>");
                string copiesString = Console.ReadLine();
                int copies;
                valueFound = Int32.TryParse(copiesString, out copies);
                if (!valueFound)
                {
                    Console.WriteLine("Wrong input detected, try again.");
                }
                else
                {
                    tempMovie.AvailableCopies = copies;
                    valueFound = true;
                }
            }
            Home.movieCollection.add(tempMovie);
        }

        // assign a movie to a customer
        public void borrowMovie(int memberIndex)
        {           
            if (Home.memberCollection.MemberArray[memberIndex].BorrowedMovies.Count < 4)   // enforce maximum of 4 DVD's borrowed at a time limit
            {
                Console.WriteLine("\nEnter the title of the movie to borrow ==>");
                string title = Console.ReadLine();
                if (Home.movieCollection.search(title))     // check if movie exists in library
                {
                    Home.memberCollection.MemberArray[memberIndex].addMovie(Home.movieCollection.MovieTable[title] as Movie);   // send movie object to member from movie table
                }
                else
                {
                    Console.WriteLine("\nMovie not in the system.");
                }
            }
            else
            {
                Console.WriteLine("\nBorrow limit of 4 DVD's has been reached.");
            }
        }

        // delete existing member from the collection
        public void deleteMember()
        {
            Console.WriteLine("\nEnter the contact number of the member to be removed.");
            string contactNumber = Console.ReadLine();
            for (int i = 0; i < Home.memberCollection.MemberArray.Length; i++)
            {
                if (Home.memberCollection.MemberArray[i].ContactNumber == contactNumber)  // check member exists with that contact number 
                {
                    if (Home.memberCollection.MemberArray[i].BorrowedMovies.Count > 0) // check member is not currently borrowing anything
                    {
                        Console.WriteLine("\nMember is currently borrowing a movie(s). Unable to delete.");
                        return;
                    }
                    else
                    {
                        Home.memberCollection.delete(i);    // remove member
                        return;
                    }
                }
            }                 
            Console.WriteLine("\nMember does not exist in the system.");
        }

        // remove a copy of an existing movie from the collection
        public void deleteMovie()
        {
            // find title and check if movie already exists
            Console.WriteLine("\nEnter the name of the movie to decrease in quantity ==>");
            string title = Console.ReadLine();
            if (!Home.movieCollection.MovieTable.ContainsKey(title))
            {
                Console.WriteLine("Movie does not exist in the system.");
                return;
            }

            // parse number of copies to be removed
            bool valueFound = false;
            while (!valueFound)
            {
                Console.WriteLine("\nEnter how many copies are to be removed from the system ==>");
                string copiesString = Console.ReadLine();
                int copies;
                valueFound = Int32.TryParse(copiesString, out copies);
                if (!valueFound)
                {
                    Console.WriteLine("Wrong input detected, try again.");
                }
                else
                {
                    (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies -= copies;    // reduce availablecopies by number entered by staff
                    if ((Home.movieCollection.MovieTable[title] as Movie).AvailableCopies < 0)      // if that removes all dvd movies from the library, remove the movie object
                    {
                        Home.movieCollection.MovieTable.Remove(title);
                        Console.WriteLine("\nAll copies were removed from the system. Movie removed from the library.");
                        return;
                    }
                    Console.WriteLine("\n{0} copies of {1} were removed to the system, giving a total of {2}.", copies, title, (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies);      // display output
                    valueFound = true;
                }
            }
        }

        // print all the details of a given movie
        public void displayOneMovie()
        {
            Console.WriteLine("Enter the title of the movie you want to view details of ==>");
            string title = Console.ReadLine();
            if (Home.movieCollection.search(title))
            {
                Console.WriteLine("\nMovie details:");
                Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -10} {4, -5} {5, -10}", "TITLE", "RATING", "GENRE", "DURATION", "QTY", "No. Borrowings");
                Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -10} {4, -5} {5, -10}",
                    (Home.movieCollection.MovieTable[title] as Movie).Title,
                    (Home.movieCollection.MovieTable[title] as Movie).Classification,
                    (Home.movieCollection.MovieTable[title] as Movie).Genre,
                    (Home.movieCollection.MovieTable[title] as Movie).Duration,
                    (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies,
                    (Home.movieCollection.MovieTable[title] as Movie).borrowCount);
            }
        }

        // find a contact number of a member given first and last name
        public void getConnectPhone()
        {
            Console.WriteLine("\nEnter the first name of the member");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter the last name of the member");
            string lastName = Console.ReadLine();
            Home.memberCollection.findNumber(firstName, lastName);
        }

        // print list of all movies borrowed by a member
        public void listBorrowed(int memberIndex)
        {
            if (Home.memberCollection.MemberArray[memberIndex].BorrowedMovies.Count > 0)    // making sure member has borrowed movies
            {
                Console.WriteLine("\nCurrently borrowed movies:");
                foreach (var movie in Home.memberCollection.MemberArray[memberIndex].getBorrowingMovieDVDs)     // using the method defined in the interface how it was intended
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine("\nNo movies currently borrowed.");
            }
        }

        // return a borrowed movie
        public void returnMovie(int memberIndex)
        {
            Console.WriteLine("\nEnter the name of the movie to be returned ==>");
            string title = Console.ReadLine();
            if (Home.memberCollection.MemberArray[memberIndex].BorrowedMovies.ContainsKey(title))   // confirm member has this movie currently borrowed                                                       
            {
                Home.memberCollection.MemberArray[memberIndex].deleteMovie(Home.memberCollection.MemberArray[memberIndex].BorrowedMovies[title] as Movie);   // delete movie from member record, send to library record
            }
            else
            {
                Console.WriteLine("\nMovie not currently borrowed");
            }
        }

        // print top 3 most borrowed movies in descending order by frequency
        public void displayTop3()
        {
            //
            // sorting algorithm for paired string and int values into corrosponding string and int arrays
            //
            string[] topMovieTitles = new string[3];   // create an array to store top 3 movie titles
            int[] topMovieBorrowCounts = new int[3];   // create array to store corrosponding top 3 movie borrow counts
            foreach (Movie movie in Home.movieCollection.MovieTable.Values) // iterate though all movies in the movie collection
            {
                if (movie.borrowCount > topMovieBorrowCounts[0])  // case of movie having the highest borrow count in topMovieBorrowCounts
                {
                    topMovieBorrowCounts[2] = topMovieBorrowCounts[1];  // push existing value at [1] down to [2]
                    topMovieBorrowCounts[1] = topMovieBorrowCounts[0];  // push existing value at [0] down to [1]
                    topMovieBorrowCounts[0] = movie.borrowCount;   // assign current movie borrow count to [0] 
                    topMovieTitles[2] = topMovieTitles[1];   // push existing value at [1] down to [2]
                    topMovieTitles[1] = topMovieTitles[0];   // push existing value at [0] down to [1]
                    topMovieTitles[0] = movie.Title;    // assign current movie title to [0]                  
                }
                else if (movie.borrowCount > topMovieBorrowCounts[1]) // case of movie having 2nd highest borrow count in topMovieBorrowCounts
                {
                    topMovieBorrowCounts[2] = topMovieBorrowCounts[1];  // push existing value at [1] down to [2]
                    topMovieBorrowCounts[1] = movie.borrowCount;   // assign current movie borrow count to [0] 
                    topMovieTitles[2] = topMovieTitles[1];   // push existing value at [1] down to [2]
                    topMovieTitles[1] = movie.Title;    // assign current movie title to [0]           
                }
                else if (movie.borrowCount > topMovieBorrowCounts[2])  // case of movie having 3rd largest borrow count in topMovieBorrowCounts
                {
                    topMovieBorrowCounts[2] = movie.borrowCount;   // assign current movie count to [2]
                    topMovieTitles[2] = movie.Title; // assign current movie title to [2]
                }
            }

            // print sorted array
            Console.WriteLine("\nTop 3 most borrowed movies:");
            Console.WriteLine("{0, -15} {1, -10}", "TITLE", "TIMES BORROWED");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0, -15} {1, -10}", topMovieTitles[i], topMovieBorrowCounts[i]);
            }
        }

        // print list of all movies available with all information
        public void displayAllMovies()
        {
            int numMovies = Home.movieCollection.Number;
            if (numMovies > 0)  // if there are movies in the library
            {   
                string[] titles = new string[numMovies];    // create array to store all titles
                Home.movieCollection.MovieTable.Keys.CopyTo(titles, 0); // copy titles from movie collection to array
                Array.Sort(titles); // sort titles 
                Console.WriteLine("\nMovies currently available:");
                Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -10} {4, -5} {5, -15}", "TITLE", "RATING", "GENRE", "DURATION", "QTY", "TIMES BORROWED");
                foreach (string title in titles)    // iterate through sorted movie titles printing all details
                {
                    Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -10} {4, -5} {5, -15}", 
                        (Home.movieCollection.MovieTable[title] as Movie).Title, 
                        (Home.movieCollection.MovieTable[title] as Movie).Classification, 
                        (Home.movieCollection.MovieTable[title] as Movie).Genre, 
                        (Home.movieCollection.MovieTable[title] as Movie).Duration, 
                        (Home.movieCollection.MovieTable[title] as Movie).AvailableCopies, 
                        (Home.movieCollection.MovieTable[title] as Movie).borrowCount);
                }
            }
            else
            {
                Console.WriteLine("\nNo movies available.");
            }
        }

        // printt list of all members borrowing a particular movie
        public void getBorrowers()
        {
            Console.WriteLine("\nEnter the title of the movie you want to search ==>");
            string title = Console.ReadLine();
            List<string> borrowingMembers = new List<string>();   // create list to store member
            for (int i = 0; i < Home.memberCollection.Number; i++)  // iterate through all members
            {
                foreach (string movie in Home.memberCollection.MemberArray[i].BorrowedMovies.Keys)  // iterate through movies currently borrowed
                {
                    if (movie == title)
                    {
                        borrowingMembers.Add(Home.memberCollection.MemberArray[i].FirstName + " " + Home.memberCollection.MemberArray[i].LastName); // record name (first and last name) of member
                    }
                }
            }
            Console.WriteLine("\nMembers currently borrowing {0}:", title);
            if (borrowingMembers.Count > 0)    // print all entries in list 
            {
                borrowingMembers.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("\nNo one is currently borrowing {0}", title);
            }
        }
    }
} 