using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class StudentRepository
    {
        List<Student> Students { get; set; }

        public StudentRepository()
        {
            Students = new List<Student>();
        }

        public void AddItem(Student item)
        {
            Students.Add(item);
        }

        public void AddItems(List<Student> items)
        {
            Students.Concat(items);
        }

        public void DeleteById(int id)
        {
            GetById(id).Delete();
        }

        public Student GetById(int id)
        {
            return Students.SingleOrDefault(x => x.Id == id);
        }

        public List<Student> GetAll()
        {
            return Students;
        }

        public string GetFullName(int id)
        {
            Student student = GetById(id);

            return $"{student.FirstName} {student.LastName}";
        }
    }
}
