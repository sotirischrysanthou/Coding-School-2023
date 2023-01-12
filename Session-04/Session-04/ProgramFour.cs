using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class ProgramFour
    {
        public string AgeAndGender()
        {
            int age = 25;
            string gender = "male";
            
            string message = "You are " + gender + " and llok younger than" + age;
            
            return message;
        }
    }
}
