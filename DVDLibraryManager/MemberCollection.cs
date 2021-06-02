using System;
using System.Collections.Generic;
using System.Linq;

namespace DVDLibraryManager
{
    class MemberCollection : iMemberCollection
    {
        // initialize MemberArray
        public Member[] MemberArray = new Member[0];

        // get the number of members in the community library
        public int Number { get { return MemberArray.Length; } }

        // add a new member to this member collection, make sure there are no duplicates in the member collection
        public void add(iMember aMember)
        {
            Array.Resize(ref MemberArray, MemberArray.Length + 1);  // increase size of array by 1
            MemberArray[MemberArray.Length - 1] = (Member)aMember;  // add member to end of array
            Console.WriteLine("\nMember #{0} successfully added.", MemberArray.Length);
        }

        // remove all the members in this member collection
        public void clear()
        {
            MemberArray = new Member[0];
        }

        // delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        public void delete(int memberIndex)
        {
            List<Member> memberlist = MemberArray.ToList<Member>();     // convert to list
            memberlist.RemoveAt(memberIndex);                           // remove list element
            MemberArray = memberlist.ToArray();                         // rebuild array
            Console.WriteLine("\nMember deleted.");
        }

        // search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise
        public bool search(string contactNumber)
        {
            if (MemberArray.Length > 0)
            {
                for (int i = 0; i < MemberArray.Length; i++)
                {                  
                    if ((MemberArray[i].ContactNumber == contactNumber))    // check if complete match is found (same contact number which is unique to each member)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // print contact number given first and last name
        public void findNumber(string firstName, string lastName)
        {
            for (int i = 0; i < MemberArray.Length; i++)
            {
                if ((MemberArray[i].FirstName == firstName) & (MemberArray[i].LastName == lastName))    // check member array for a matching set of names
                {
                    Console.WriteLine("\nThe contact number for {0} {1} is {2}", firstName, lastName, MemberArray[i].ContactNumber);    // output contact number
                    return;
                }
            }
            Console.WriteLine("\nCustomer not found.");
            return;
        }
    }
}
