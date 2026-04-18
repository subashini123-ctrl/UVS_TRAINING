using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAttendanceApp.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PresentDays { get; set; }
        public int TotalDays { get; set; }

        public double Percentage =>
            TotalDays == 0 ? 0 : (double)PresentDays / TotalDays * 100;
    }
}
