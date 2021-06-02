using System;
using System.Collections;
using System.Text;

namespace DVDLibraryManager
{
    class MemberMenu
    {
        public static int memberIndex; // value used to identify the member when searching member collection

        // set the member menu environment
        public static void Menu(int arrayIndex)
        {
            memberIndex = arrayIndex;
            Console.WriteLine("\nAccess Granted.");
            PrintMenu();
            ParseInput();
        }

        // print the member menu options
        static void PrintMenu()
        {
            Console.WriteLine("\n\nMember Menu");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Select from the following:");
            Console.WriteLine("\n\n1. Browse all the movies");
            Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
            Console.WriteLine("3. Borrow a movie DVD");
            Console.WriteLine("4. Return a movie DVD");
            Console.WriteLine("5. List current borrowing movies");
            Console.WriteLine("6. Display the top 3 movies rented by the members");
            Console.WriteLine("0. Return to main menu");
        }

        // parse input for the member menu
        static void ParseInput()
        {
            while (true)
            {
                Console.WriteLine("\nEnter your choice ==>");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1": // display all movies
                        Home.tools.displayAllMovies();
                        break;
                    case "2":   // display all the information about a movie, given the title
                        Home.tools.displayOneMovie();
                        break;
                    case "3":   // borrow a movie dvd
                        Home.tools.borrowMovie(memberIndex);
                        break;
                    case "4":   // return a movie dvd
                        Home.tools.returnMovie(memberIndex);
                        break;
                    case "5":   // list current borrowing movies
                        Home.tools.listBorrowed(memberIndex);
                        break;
                    case "6":   // display the top 3 movies rented by the members
                        Home.tools.displayTop3();
                        break;
                    case "0":   // return to main menu
                        Home.PrintMenu();
                        Home.ParseInput();
                        break;
                    default:
                        Console.WriteLine("\nWrong input detected, try again.");
                        break;
                }
            }
        }
    }
}
