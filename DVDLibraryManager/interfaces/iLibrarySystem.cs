
using System;
using System.Collections.Generic;
using System.Text;

namespace DVDLibraryManager
{
    interface ToolLibrarySystem
    {
        void addNewMovie(); // add DVDs of a new movie to the system

        void addExistingMovie(); //add new DVDs of an existing movie to the system

        void deleteMovie(); //remove a given movie from the system

        void addMember(); //add a new memeber to the system

        void deleteMember(); //delete a member from the system

        void getConnectPhone(); //given a member's first name and last name, find the contact phone number of this member

        void getBorrowers(); //given the title of a movie, return all thoe memebrs wo are currently borrowing that movie

        void displayAllMovies(); //display the information about all the movies in the library

        void displayOneMovie(); //display all the information about about amovie, given the title of the movie 

        void borrowMovie(int memberIndex); //a member borrows a movie DVD from the library

        void returnMovie(int memberIndex); //a member returns a movie DVD to the library

        void listBorrowed(int memberIndex); //get a list of movie DVDs that are currently held by a given member

        void displayTop3(); //Display top three most frequently borrowed movies by the members in the library in the descending order by the number of times the movie has been borrowed.

    }
}
