using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information
{
    class Student
    {
        public string Name { get; set; }
        public string FavoriteFood { get; set; }
        public string HomeTown { get; set; }
        public Student (string Name, string FavoriteFood, string HomeTown)
        {
            this.Name = Name;
            this.FavoriteFood = FavoriteFood;
            this.HomeTown = HomeTown;
        }
    }
}
