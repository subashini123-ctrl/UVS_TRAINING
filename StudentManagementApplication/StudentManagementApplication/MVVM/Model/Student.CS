namespace StudentManagementApplication.MVVM.Model
{
    public class Student
    {
        public string Name { get; set; }
        public string RegisterNumber { get; set; }
        public string Department { get; set; }
        public int Tamil { get; set; }
        public int English { get; set; }
        public int Mathematics { get; set; }

        public int Science { get; set; }


        public int Total => Tamil + English + Mathematics + Science;
    }
}
