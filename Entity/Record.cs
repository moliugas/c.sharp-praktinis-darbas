namespace C_sharp_egzaminas.Entity
{
    public class Record
    {
        public int Id { get; }
        public int Grade { get; private set; }
        public DateTime Date { get; private set; }

        public string Message { get; }

        public int TeacherId { get; }

        public int StudentId { get; }

        public int LessonId { get; }
        public bool IsActive { get; private set; }

        public Record(int id, int grade, string date, int teacherId, int studentId, int lessonId, string message, bool isActive = true)
        {
            Id = id;
            SetGrade(grade);
            SetDate(date);
            TeacherId = teacherId;
            StudentId = studentId;
            LessonId = lessonId;
            Message = message;
            IsActive = isActive;
        }
        public Record(int id, int grade, string date, int teacherId, int studentId, int lessonId, bool isActive = true)
        {
            Id = id;
            SetGrade(grade);
            SetDate(date);
            TeacherId = teacherId;
            StudentId = studentId;
            LessonId = lessonId;
            Message = "";
            IsActive = isActive;
        }

        public Record(int id, int grade, int teacherId, int studentId, int lessonId, string message, bool isActive = true)
        {
            Id = id;
            SetGrade(grade);
            Date = DateTime.Now;
            TeacherId = teacherId;
            StudentId = studentId;
            LessonId = lessonId;
            Message = message;
            IsActive = isActive;
        }

        public void SetGrade(int item)
        {
            if (item < 0 || item > 10)
            {
                Grade = 0;
                return;
            }

            Grade = item;
        }

        void SetDate(string item)
        {
            Date = DateTime.Parse(item);
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}
