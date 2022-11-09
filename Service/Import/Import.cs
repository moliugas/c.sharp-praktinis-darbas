using C_sharp_egzaminas.Entity;
using C_sharp_egzaminas.Repository;

namespace C_sharp_egzaminas.Service.Import
{
    public class Import
    {
        StudentRepository students;
        TeacherRepository teachers;
        RecordRepository records;
        LessonRepository lessons;

        public Import(ref StudentRepository studentRepository, ref TeacherRepository teacherRepository, ref RecordRepository recordRepository, ref LessonRepository lessonRepository)
        {
            students = studentRepository;
            teachers = teacherRepository;
            records = recordRepository;
            lessons = lessonRepository;
        }

        public void ImportStudents(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\students.csv")
        {
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
                    students.AddItem(new Student(int.Parse(values[0]), values[1], values[2], values[3]));
                }
            }
        }

        public void ImportTeachers(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\teachers.csv")
        {
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
                    teachers.AddItem(new Entity.Teacher(int.Parse(values[0]), values[1], values[2], values[3]));
                }
            }
        }

        public void ImportRecords(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\records.csv")
        {
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
                    records.AddItem(new Entity.Record(int.Parse(values[0]), int.Parse(values[1]), values[2], int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5])));
                }
            }
        }

        public void ImportLessons(string file = @"C:\Users\Audrius\source\repos\C_sharp_egzaminas\Data\lessons.csv")
        {
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
                    lessons.AddItem(new Entity.Lesson(int.Parse(values[0]), values[1]));
                }
            }
        }

        public void ImportAll()
        {
            ImportStudents();
            ImportTeachers();
            ImportRecords();
            ImportLessons();
        }
    }


}
