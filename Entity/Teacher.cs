namespace C_sharp_egzaminas.Entity
{
    public class Teacher
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Group { get; }

        public Teacher(int id, string firstName, string lastName, string group)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
        }
    }
}