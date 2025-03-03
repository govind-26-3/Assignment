using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    internal class User
    {
        static int userCount;


        static User()
        {
            userCount++;
        }

        //public User()
        //{
        //    userCount++;

        //}
        public void Display() { Console.WriteLine($"number of users :{userCount}"); }



    }
}
