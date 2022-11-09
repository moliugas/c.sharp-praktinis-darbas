using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class RecordRepository
    {
        List<Record> Records { get; }

        public RecordRepository()
        {
            Records = new List<Record>();
        }

        public void AddItem(Record item)
        {
            Records.Add(item);
        }

        public void AddItems(List<Record> items)
        {
            Records.Concat(items);
        }

        public void DeleteById(int id)
        {
            GetById(id).Delete();
        }

        public Record GetById(int id)
        {
            return Records.SingleOrDefault(x => x.Id == id);
        }

        public List<Record> GetAll()
        {
            return Records;
        }

        public List<Record> GetByPeriod(DateTime from, DateTime to)
        {
            return Records.FindAll(x => x.Date.CompareTo(from) >= 0 && x.Date.CompareTo(to) <= 0);
        }

        public List<Record> GetAllByStudentId(int id)
        {
            return Records.FindAll(x => x.StudentId == id);
        }

        public List<Record> GetAllByTeacherId(int id)
        {
            return Records.FindAll(x => x.TeacherId == id);
        }

        public List<Record> GetAllByLessonId(int id)
        {
            return Records.FindAll(x => x.LessonId == id);
        }

        public int GetNextId()
        {
            return Records.Max(x => x.Id) + 1;
        }


    }
}