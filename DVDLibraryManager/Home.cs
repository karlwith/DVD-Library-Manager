using System;

namespace DVDLibraryManager
{
    class Home
    {
        // instantiate movie collection, member collection and tools instances
        public static MemberCollection memberCollection = new MemberCollection();
        public static MovieCollection movieCollection = new MovieCollection();
        public static LibrarySystem tools = new LibrarySystem();

        public static void Main(string[] args)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("\t  COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM");
            Console.WriteLine("====================================================================");
            //testdata();
            PrintMenu();
            ParseInput();          
        }

        // print the menu
        public static void PrintMenu()
        {
            Console.WriteLine("\n\nMain Menu");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Select from the following:");
            Console.WriteLine("\n\n1. Staff");
            Console.WriteLine("2. Member");
            Console.WriteLine("0. End the program");
        }

        // parse input from menu
        public static void ParseInput()
        {
            while (true) 
            {
                Console.WriteLine("\nEnter your choice ==>");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":   // staff login
                        StaffLogin();
                        break;
                    case "2":   // member login
                        MemberLogin();
                        break;
                    case "0":   // end the program
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong input detected, try again.");
                        break;
                }
            }
        }

        // login process for staff
        static void StaffLogin()
        {
            Console.WriteLine("\n\nStaff Login");
            Console.WriteLine("--------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("\nEnter your username or 'exit' to return to the main menu ==>");
                string username = Console.ReadLine();
                switch (username)
                {
                    case "exit":
                        PrintMenu();
                        ParseInput();
                        break;
                    case "staff":
                        Console.WriteLine("\nEnter your password, 1 attempt remaining ==>");
                        string password = Console.ReadLine();
                        if (password == "today123")
                        {
                            StaffMenu.Menu();
                        }                          
                        break;
                    default:
                        Console.WriteLine("Username not recognized, try again.");
                        break;
                }
            }
        }

        // login process for a member
        static void MemberLogin()
        {
            Console.WriteLine("\n\nMember Login");
            Console.WriteLine("--------------------------------------------------------------------");
            while (true)
            {
                // find first and last name
                Console.WriteLine("\nEnter your first name or 'exit' to return to the main menu ==>");
                string firstName = Console.ReadLine();
                if (firstName == "exit")
                {
                    PrintMenu();
                    ParseInput();
                }
                Console.WriteLine("\nEnter your last name ==>");
                string lastName = Console.ReadLine();

                // find pin of the member
                bool valueFound = false;
                int pin;
                while (!valueFound)
                {
                    Console.WriteLine("\nEnter your 4 digit pin ==>");
                    string PinString = Console.ReadLine();
                    valueFound = Int32.TryParse(PinString, out pin);
                    if (!valueFound)
                    {
                        Console.WriteLine("Wrong input detected, try again.");
                    }
                    else
                    {
                        if (memberCollection.MemberArray.Length > 0)
                        {
                            // validate details
                            for (int i = 0; i < memberCollection.MemberArray.Length; i++)
                            {
                                if ((memberCollection.MemberArray[i].FirstName == firstName) & (memberCollection.MemberArray[i].LastName == lastName) & (memberCollection.MemberArray[i].Pin == pin))
                                {
                                    MemberMenu.Menu(i);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Details do not match any existing registered members. Access denied.");
            }
        }

        // test data for debugging
        public static void testdata()
        {
            Member tempMember = new Member();
            tempMember.ContactNumber = "1111";
            tempMember.FirstName = "A";
            tempMember.LastName = "Name";
            tempMember.Pin = 1111;
            memberCollection.add(tempMember);

            Member temp2Member = new Member();
            temp2Member.ContactNumber = "1234";
            temp2Member.FirstName = "Fake";
            temp2Member.LastName = "Person";
            temp2Member.Pin = 4321;
            memberCollection.add(temp2Member);

            Movie tempMovie = new Movie();
            tempMovie.AvailableCopies = 5;
            tempMovie.Classification = "G";
            tempMovie.Duration = 50;
            tempMovie.Genre = "Thriller";
            tempMovie.Title = "A Movie";
            tempMovie.borrowCount = 5;
            movieCollection.add(tempMovie);

            Movie temp1Movie = new Movie();
            temp1Movie.AvailableCopies = 6;
            temp1Movie.Classification = "PG";
            temp1Movie.Duration = 100;
            temp1Movie.Genre = "Adventure";
            temp1Movie.Title = "Jumanji";
            temp1Movie.borrowCount = 3;
            movieCollection.add(temp1Movie);

            Movie temp3Movie = new Movie();
            temp3Movie.AvailableCopies = 5;
            temp3Movie.Classification = "MA15+";
            temp3Movie.Duration = 550;
            temp3Movie.Genre = "Drama";
            temp3Movie.Title = "Bee Movie";
            temp3Movie.borrowCount = 32;
            movieCollection.add(temp3Movie);

            Movie temp4Movie = new Movie();
            temp4Movie.AvailableCopies = 5;
            temp4Movie.Classification = "PG";
            temp4Movie.Duration = 40;
            temp4Movie.Genre = "Thriller";
            temp4Movie.Title = "Sky Movie";
            temp4Movie.borrowCount = 66;
            movieCollection.add(temp4Movie);

            Movie temp5Movie = new Movie();
            temp5Movie.AvailableCopies = 444;
            temp5Movie.Classification = "G";
            temp5Movie.Duration = 4000;
            temp5Movie.Genre = "Action";
            temp5Movie.Title = "Sea Movie";
            temp5Movie.borrowCount = 25;
            movieCollection.add(temp5Movie);
        }
    }
}
