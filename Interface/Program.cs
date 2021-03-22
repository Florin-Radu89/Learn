using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface GuestInterface
    {
        void GuestWelcomeMessage();
        void NoofGuestes();
    }
    interface FriendsandRelationsInterface
    {
        void friendwelcomemessage();
        void FriendName();
    }

    class HouseOwnerClass : GuestInterface, FriendsandRelationsInterface
    {
        public void GuestWelcomeMessage()
        {
            Console.WriteLine("All guests are well come to our home");
        }

        public void NoofGuestes()
        {
            Console.WriteLine("Total 15 Guestes has visited");
        }

        public void friendwelcomemessage()
        {
            Console.WriteLine("Welcome to our Home");
        }
        public void FriendName()
        {
            Console.WriteLine("Friend  name is: Afraz");
        }
        static void Main(string[] args)
        {
            HouseOwnerClass obj = new HouseOwnerClass();
            obj.GuestWelcomeMessage();
            obj.NoofGuestes();
            obj.friendwelcomemessage();
            obj.FriendName();
            Console.ReadLine();
        }
    }


}
