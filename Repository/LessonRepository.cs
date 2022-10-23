using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class LessonRepository
    {
        List<Lesson> Lessons { get; set; }

        public LessonRepository()
        {
            Lessons = new List<Lesson>();
        }

        public void AddItem(Lesson item)
        {
            Lessons.Add(item);
        }

        public void AddItems(List<Lesson> items)
        {
            Lessons.Concat(items);
        }

        public void DeleteById(int id)
        {
            GetById(id).Delete();
        }

        public Lesson GetById(int id)
        {
            return Lessons.SingleOrDefault(x => x.Id == id);
        }

        public string GetNameById(int id)
        {
            return Lessons.SingleOrDefault(x => x.Id == id).LessonName;
        }

        public List<Lesson> GetAll()
        {
            return Lessons;
        }
    }
}
