
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.Model;
using System.Collections.ObjectModel;
using StudentAttendanceApp;



public partial class StudentViewModel : ObservableObject
{
    private StudentService service = new StudentService ();

    public ObservableCollection<Student> Students => service.Students;

    [ObservableProperty]
    string name;

    public StudentViewModel()
    {
        AddCommand = new RelayCommand(AddStudent);
        DeleteCommand = new RelayCommand<Student>(DeleteStudent);
        PresentCommand = new RelayCommand<Student>(MarkPresent);
        AbsentCommand = new RelayCommand<Student>(MarkAbsent);
        ShowPopupCommand = new RelayCommand(ShowPopup);
    }

    public IRelayCommand AddCommand { get; }
    public IRelayCommand<Student> DeleteCommand { get; }
    public IRelayCommand<Student> PresentCommand { get; }
    public IRelayCommand<Student> AbsentCommand { get; }
    public IRelayCommand ShowPopupCommand { get; }

    public event Action ShowPopupAction;

    private void ShowPopup()
    {
        ShowPopupAction?.Invoke();
    }

    private void AddStudent()
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            service.Add(new Student
            {
                Id = Students.Count + 1,
                Name = Name
            });
            OnPropertyChanged(nameof(Students));

            Name = string.Empty;
        }
    }

    private void DeleteStudent(Student s)
    {
        service.Delete(s);
        OnPropertyChanged(nameof(Students));
    }
    private void MarkPresent(Student s)
    {
        service.Present(s);
        OnPropertyChanged(nameof(Students));
    }

    private void MarkAbsent(Student s)
    {
        service.Absent(s);
        OnPropertyChanged(nameof(Students));
    }

    private class StudentService
    {
        public ObservableCollection<Student> Students { get; internal set; }
    }
}