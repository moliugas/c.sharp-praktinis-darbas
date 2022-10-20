using C_sharp_egzaminas.Repository;
using C_sharp_egzaminas.Service.Import;


Import import = new Import();
StudentRepository students = import.ImportStudents();
TeacherRepository teachers = import.ImportTeachers();
RecordRepository records = import.ImportRecords();

Console.WriteLine(students.GetById(1).FirstName == "Kane");