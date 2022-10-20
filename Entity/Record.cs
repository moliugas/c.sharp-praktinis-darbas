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

        public string Lesson { get; }

        public Record(int id, int grade, string date, int teacherId, int studentId, string lesson, string message)
        {
            Id = id;
            SetGrade(grade);
            SetDate(date);
            TeacherId = teacherId;
            StudentId = studentId;
            Lesson = lesson;
            Message = message;
        }
        public Record(int id, int grade, string date, int teacherId, int studentId, string lesson)
        {
            Id = id;
            SetGrade(grade);
            SetDate(date);
            TeacherId = teacherId;
            StudentId = studentId;
            Lesson = lesson;
            Message = "";
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


    }
}
