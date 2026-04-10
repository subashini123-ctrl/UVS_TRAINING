using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementApp.MVVM.Model
{
    public class Student
    {
        public string Name { get; set; }

        public int Mathematics { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }


        public int Total => Mathematics + Physics + Chemistry;


        public double Percentage => Total / 3.0;


        public string Result => Percentage >= 40 ? "PASS" : "FAIL";
    }
}
