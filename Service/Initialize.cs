using C_sharp_egzaminas.Repository;
using C_sharp_egzaminas.Service.Import;
using C_sharp_egzaminas.Service.UI;

namespace C_sharp_egzaminas
{
    public class Initialize
    {
        StudentRepository students = new StudentRepository();
        TeacherRepository teachers = new TeacherRepository();
        RecordRepository records = new RecordRepository();
        LessonRepository lessons = new LessonRepository();

        public Initialize()
        {

            Import import = new Import(ref students, ref teachers, ref records, ref lessons);
            import.ImportAll();

            //ReportGenerator reportGenerator = new ReportGenerator(students, teachers, records, lessons);

            //var rec = records.GetAllByStudentId(1);
            //var mex = reportGenerator.GenerateFullYearStudentReportByStudentId(1, 2021);

            //List<ReportItem> reportItems = reportGenerator.GenerateFullSemesterStudentReportByStudentIdAndSemester(1, 2, 2021);

            //string htmlTable = HTMLGenerator.GenerateHTML(reportItems);

            //Console.WriteLine(htmlTable);

            //Console.WriteLine(Menus.GetChoice());
        }

        public void Start()
        {

            while (true)
            {
            Menus.MainMenu();
            }
        }
    }
}
