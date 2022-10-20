using C_sharp_egzaminas.Entity;
using C_sharp_egzaminas.Repository;

namespace C_sharp_egzaminas.Service.Import
{
    public class Import
    {
        public Import() { }

        public StudentRepository ImportStudents(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\students.csv")
        {
            StudentRepository repository = new StudentRepository();
            using (var reader = new StreamReader(file))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    string[] values = line.Split(',');
                    repository.AddItem(new Student(int.Parse(values[0]), values[1], values[2], values[3]));
                }
            }
            return repository;
        }

        public TeacherRepository ImportTeachers(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\teachers.csv")
        {
            TeacherRepository repository = new TeacherRepository();
            using (var reader = new StreamReader(file))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    string[] values = line.Split(',');
                    repository.AddItem(new Entity.Teacher(int.Parse(values[0]), values[1], values[2], values[3]));
                }
            }
            return repository;
        }

        public RecordRepository ImportRecords(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\records.csv")
        {
            RecordRepository repository = new RecordRepository();
            using (var reader = new StreamReader(file))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    string[] values = line.Split(',');
                    repository.AddItem(new Entity.Record(int.Parse(values[0]), int.Parse(values[1]), values[2], int.Parse(values[3]), int.Parse(values[4]), values[5]));
                }
            }
            return repository;
        }
    }
}
