using System.Xml.Serialization;

namespace C_sharp_egzaminas.Entity
{
    public class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Group { get; }

        public Student(int id, string firstName, string lastName, string group)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
        }
        public Student() { }
    }
}