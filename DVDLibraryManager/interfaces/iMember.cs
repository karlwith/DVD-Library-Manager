using System;


namespace DVDLibraryManager
{
    //The specification of Member ADT
    interface iMember
    {
        
        string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        int Pin //get and set a four-digit pin number
        {
            get;
            set;
        }
    }
}
