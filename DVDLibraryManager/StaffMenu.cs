using System;

namespace DVDLibraryManager
{
    class StaffMenu
    {
        // set the staff menu environment
        public static void Menu()
        {
            Console.WriteLine("\nAccess Granted.");
            PrintMenu();
            ParseInput();        
        }

        // print the staff menu options
        static void PrintMenu()
        {
            Console.WriteLine("\n\nStaff Menu");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Select from the following:");
            Console.WriteLine("\n\n1. Add DVDs of a new movie to the system");
            Console.WriteLine("2. Add new DVDs of an existing movie to the system");
            Console.WriteLine("3. Remove a DVD from the system");
            Console.WriteLine("4. Register a new member to the system");
            Console.WriteLine("5. Remove a registered member from the system");
            Console.WriteLine("6. Find a member's contact phone number, given the member's name");
            Console.WriteLine("7. Find members who are currently renting a particular movie");
            Console.WriteLine("0. Return to main menu");
        }

        // parse input for the staff menu
        static void ParseInput()
        {
            while (true)
            {
                Console.WriteLine("\nEnter your choice ==>");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":   // create a movie
                        Home.tools.addNewMovie();
                        break;
                    case "2":   // add copy of existing movie
                        Home.tools.addExistingMovie();
                        break;
                    case "3":   // remove a copy of existing movie
                        Home.tools.deleteMovie();
                        break;
                    case "4":   // register a new member
                        Home.tools.addMember();
                        break;
                    case "5":   // remove a registered member
                        Home.tools.deleteMember();
                        break;
                    case "6":   // find members contact number
                        Home.tools.getConnectPhone();
                        break;
                    case "7":   // find members renting a given movie
                        Home.tools.getBorrowers();
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
