namespace C_sharp_egzaminas.Entity
{
    public class ReportItem
    {
        public int Id { get; }
        public int Grade { get; }
        public double GradeAverage { get; }
        public DateTime Date { get; }
        public string Message { get; }
        public string TeacherName { get; }
        public string StudentName { get; }
        public string Lesson { get; }
        public string Type { get; }
        public int TitleId { get; }
        public bool IsActive { get; private set; }


        public ReportItem(int id, int grade, double gradeAverage, DateTime date, string message, string teacherName, string studentName, string lesson, string type, int titleId =  0, bool isActive = true)
        {
            Id = id;
            Grade = grade;
            Date = date;
            Message = message;
            TeacherName = teacherName;
            StudentName = studentName;
            Lesson = lesson;
            Type = type;
            GradeAverage = gradeAverage;
            TitleId = titleId;
            IsActive = isActive;
        }

        public ReportItem()
        {
            Delete();
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}
