using StudentAttendanceApp;
using StudentAttendanceApp.Model;
using System;
using System.Collections.ObjectModel;

namespace StudentAttendanceApp;

public class StudentService
{
    public ObservableCollection<Student> Students { get; set; } = new();

    public void Add(Student s) => Students.Add(s);

    public void Delete(Student s) => Students.Remove(s);

    public void Present(Student s)
    {
        s.PresentDays++;
        s.TotalDays++;
    }

    public void Absent(Student s)
    {
        s.TotalDays++;
    }
}
