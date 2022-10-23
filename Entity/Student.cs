namespace C_sharp_egzaminas.Entity
{
    public class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Group { get; }
        public bool IsActive { get; private set; }

        public Student(int id, string firstName, string lastName, string group, bool isActive = true)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            IsActive = isActive;
        }
        public Student() { }

        public void Delete()
        {
            IsActive = false;
        }
    }
}