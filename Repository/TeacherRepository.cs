using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class TeacherRepository
    {
        List<Teacher> Teachers { get; set; }

        public TeacherRepository()
        {
            Teachers = new List<Teacher>();
        }

        public void AddItem(Teacher item)
        {
            Teachers.Add(item);
        }

        public void AddItems(List<Teacher> items)
        {
            Teachers.Concat(items);
        }

        public void DeleteById(int id)
        {
            Teachers.Remove(Teachers[id]);
        }

        public Teacher GetById(int id)
        {
            return Teachers.SingleOrDefault(x => x.Id == id);
        }

        public List<Teacher> GetAll()
        {
            return Teachers;
        }
    }
}
