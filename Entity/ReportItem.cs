namespace C_sharp_egzaminas.Entity
{
    public class ReportItem
    {
        public int Id { get; }
        public int Grade { get; }
        public string Date { get; }
        public string Message { get; }
        public string TeacherName { get; }
        public string StudentName { get; }
        public string Lesson { get; }

        public ReportItem(int id, int grade, string date, string message, string teacherName, string studentName, string lesson)
        {
            Id = id;
            Grade = grade;
            Date = date;
            Message = message;
            TeacherName = teacherName;
            StudentName = studentName;
            Lesson = lesson;
        }
    }
}
