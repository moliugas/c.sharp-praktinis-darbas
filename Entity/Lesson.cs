namespace C_sharp_egzaminas.Entity
{
    public class Lesson
    {
        public int Id { get; }
        public string LessonName { get; }
        public bool IsActive { get; private set; }

        public Lesson(int id, string lessonName, bool isActive = true)
        {
            Id = id;
            LessonName = lessonName;
            IsActive = isActive;
        }
        public Lesson() { }

        public void Delete()
        {
            IsActive = false;
        }
    }
}
