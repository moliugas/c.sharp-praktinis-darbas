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
var mex = reportGenerator.GenerateFullYearStudentReportByStudentId(1, 2021);

List<ReportItem> reportItems = reportGenerator.GenerateFullSemesterStudentReportByStudentIdAndSemester(1, 2, 2021);

string htmlTable = HTMLGenerator.GenerateHTML(reportItems);

Console.WriteLine(htmlTable);

