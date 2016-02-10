using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Student
    {
        //Encapsulation - Grouping stuff together
        //Variables encapsulate a piece of data
        //Methods encapsulate a piece of logic
        //Objects encapsulate variables and methods
        //Projects encapsulate classes
        //Solutions encapsulate projects
        //Applications encapsulate solutions and projects
        //Encapsulation is not equal to data hiding
        //Encapsulation is true whether the 'stuff' is public or private
        public string name { get; set; }
        public int id { get; set; }
        public string course { get; set; }
        public string schedule { get; set; }
        public double averageGrade { get; set; }
    }
}
