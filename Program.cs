using C_sharp_egzaminas.Entity;
using C_sharp_egzaminas.Repository;
using C_sharp_egzaminas.Service.Generate;
using C_sharp_egzaminas.Service.Import;


Import import = new Import();
StudentRepository students = import.ImportStudents();
TeacherRepository teachers = import.ImportTeachers();
RecordRepository records = import.ImportRecords();
LessonRepository lessons = import.ImportLessons();

ReportGenerator reportGenerator = new ReportGenerator(students, teachers, records, lessons);

var rec = records.GetAllByStudentId(1);
var mex = reportGenerator.GenerateFullYearStudentReportByStudentIdAndSemester(1, 2002);

List<ReportItem> reportItems = reportGenerator.GenerateFullSemesterStudentReportByStudentIdAndSemester(1, 2, 2021);

Console.WriteLine(mex[0].Id);

